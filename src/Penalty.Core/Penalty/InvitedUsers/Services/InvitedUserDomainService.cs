using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using Penalty.Authorization.Users;
using Penalty.Penalty.Classes.RootEntities;
using Penalty.Penalty.InvitationLinks;
using Penalty.Penalty.PaySystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.PayMethods;

namespace Penalty.Penalty.InvitedUsers.Services
{
    public class InvitedUserDomainService : IInvitedUserDomainService
    {
        private readonly IRepository<InvitedUser, Guid> _repository;
        private readonly UserManager _userManager;
        private readonly UserRegistrationManager _userRegistrationManager;

        private IAbpSession AbpSession { get; set; }
        private readonly IRepository<InvitationLink, Guid> _inviteLinkRepository;
        private readonly IRepository<InvitedUser, Guid> _InvitedRepository;
        private readonly IRepository<GeneralSettings, Guid> _settings;
        private readonly IRepository<PayMethod, Guid> _PayMethod;


        public InvitedUserDomainService(IRepository<InvitedUser, Guid> repository, IAbpSession abpSession, UserManager userManager, IRepository<InvitationLink, Guid> inviteLinkRepository, UserRegistrationManager userRegistrationManager, IRepository<InvitedUser, Guid> invitedRepository, IRepository<GeneralSettings, Guid> settings, IRepository<PayMethod, Guid> payMethod)
        {
            _repository = repository;
            AbpSession = abpSession;
            _userManager = userManager;
            _inviteLinkRepository = inviteLinkRepository;
            _userRegistrationManager = userRegistrationManager;
            _InvitedRepository = invitedRepository;
            _settings = settings;
            _PayMethod = payMethod;
        }


        public async Task<InvitedUser> RegisterNewInvitedUser(string name, string surname, string emailAddress, string userName, string plainPassword, long inviterId)
        {
            var user = await _userRegistrationManager.RegisterAsync(
              name,
              surname,
              emailAddress,
              userName,
              plainPassword,
              true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
          );
            var invitedDataExists = _repository.GetAllIncluding(x => x.User).FirstOrDefault(x => x.UserId == user.Id);
            if(invitedDataExists != null)
            {
                return null;
            }

            InvitedUser invitedUser = new InvitedUser
            {
                User = _userManager.GetUserById(user.Id),
                UserId = user.Id,
                InvitedByUser = _userManager.GetUserById(inviterId),
                InvitedByUserId = inviterId,
<<<<<<< Updated upstream
                IsActivated = false
=======
                isActivated = false,
                PaidForUser = false,
>>>>>>> Stashed changes
            };
            return await _repository.InsertOrUpdateAsync(invitedUser);
        }

        public async Task<double> GetUserDeservedBalance(long UserId)
        {
            var settings = _settings.GetAll().FirstOrDefault();
            var invitedUsers = _InvitedRepository.GetAllIncluding(x => x.User).Where(x => x.InvitedByUserId == (long)AbpSession.UserId && x.isActivated == false && x.PaidForUser == false);
            double balance = 0;
            foreach (var user in invitedUsers)
            {
                balance += settings.BalancePerUser;
            }
            return balance;
        }

        public async Task<bool> PayForUserInvitations(long UserId, double Balance)
        {
            var settings = _settings.GetAll().FirstOrDefault();
            var userAccount = _PayMethod.GetAll().FirstOrDefault(x => x.UserId == UserId).AccountNumber;
            var cl = new HttpClient();
            cl.BaseAddress = new Uri("https://payeer.com/ajax/api/api.php");
            int _TimeoutSec = 90;
            cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
            string _ContentType = "application/form-data";
            cl.DefaultRequestHeaders.Add("account", settings.MainAccount);
            cl.DefaultRequestHeaders.Add("apiId", settings.ApiKey);
            cl.DefaultRequestHeaders.Add("apiPass", settings.ApiPass);
            cl.DefaultRequestHeaders.Add("action", "transfer");
            cl.DefaultRequestHeaders.Add("curIn", settings.DefaultCurrency);
            cl.DefaultRequestHeaders.Add("sum", Balance.ToString() + ".00");
            cl.DefaultRequestHeaders.Add("curOut", settings.DefaultCurrency);
            cl.DefaultRequestHeaders.Add("to", userAccount);
            cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
            var _UserAgent = "d-fens HttpClient";
            cl.DefaultRequestHeaders.Add("User-Agent", _UserAgent);

            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("key of content", "value"));
            nvc.Add(new KeyValuePair<string, string>("account", settings.MainAccount));
            nvc.Add(new KeyValuePair<string, string>("apiId", settings.ApiKey));
            nvc.Add(new KeyValuePair<string, string>("apiPass", settings.ApiPass));
            nvc.Add(new KeyValuePair<string, string>("action", "transfer"));
            nvc.Add(new KeyValuePair<string, string>("curIn", settings.DefaultCurrency));
            nvc.Add(new KeyValuePair<string, string>("sum", Balance.ToString() + ".00"));
            nvc.Add(new KeyValuePair<string, string>("curOut", settings.DefaultCurrency));
            nvc.Add(new KeyValuePair<string, string>("to", userAccount));
            var req = new HttpRequestMessage(HttpMethod.Post, "https://payeer.com/ajax/api/api.php") { Content = new FormUrlEncodedContent(nvc) };
            var res = cl.SendAsync(req).Result.Content.ReadAsStringAsync();

            dynamic data = JObject.Parse(res.Result);
            bool success = data.success;
            if (success == true)
            {
                var invitedUsers = _InvitedRepository.GetAllIncluding(x => x.User).Where(x => x.InvitedByUserId == (long)AbpSession.UserId && x.isActivated == false && x.PaidForUser == false);
                foreach (var user in invitedUsers)
                {
                    user.PaidForUser = true;
                    await _InvitedRepository.UpdateAsync(user);
                }
                return true;
            }
            return false;
        }
    }
}
