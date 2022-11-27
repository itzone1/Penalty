using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Newtonsoft.Json.Linq;
using Penalty.Authorization.Users;
using Penalty.Penalty.PayMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.Classes.RootEntities;

namespace Penalty.Penalty.Classes.Entities.BetResults.Services
{
    public class BetResultDomainService : IBetResultDomainService
    {
        private readonly IRepository<BetResult, Guid> _repository;
        private readonly IRepository<GeneralSettings, Guid> _settings;
        private readonly IRepository<PayMethod, Guid> _PayMethod;
        private readonly UserManager _userManager;
        private IAbpSession AbpSession
        {
            get; set;
        }

        public BetResultDomainService(IRepository<BetResult, Guid> repository, UserManager userManager, IAbpSession abpSession, IRepository<GeneralSettings, Guid> settings, IRepository<PayMethod, Guid> payMethod)
        {
            _repository = repository;
            _userManager = userManager;
            AbpSession = abpSession;
            _settings = settings;
            _PayMethod = payMethod;
        }

        public void Delete(BetResult betResult)
        {
            _repository.Delete(betResult);
        }

        public IList<BetResult> GetAll()
        {
            return _repository.GetAllIncluding(x=>x.Bet.Match.League,x=>x.Bet.Match.HomeTeam,x=>x.Bet.Match.AwayTeam,x => x.Bet.User).ToList();
        }

        public IList<BetResult> GetAllUserBets()
        {
            return _repository.GetAllIncluding(x => x.Bet.Match.League, x => x.Bet.Match.HomeTeam, x => x.Bet.Match.AwayTeam, x => x.Bet.User).Where(x => x.Bet.User.Id == AbpSession.UserId).ToList();
        }

        public async Task<IList<BetResult>> GetAllBetResultsAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<BetResult> GetBetResultbyBetId(Guid id)
        {
            return _repository.GetAllIncluding(x => x.Bet.Match.League, x => x.Bet.Match.HomeTeam, x => x.Bet.Match.AwayTeam, x => x.Bet.User).FirstOrDefault(x => x.Bet.Id == id);
        }

        public async Task<BetResult> GetbyId(Guid id)
        {
            return _repository.GetAllIncluding(x => x.Bet.Match.League, x => x.Bet.Match.HomeTeam, x => x.Bet.Match.AwayTeam, x => x.Bet.User).FirstOrDefault(x => x.Id == id);
        }

        public async Task<BetResult> Insert(BetResult betResult)
        {
            return await _repository.InsertAsync(betResult);
        }

        public async Task<BetResult> Update(BetResult betResult)
        {
            return await _repository.InsertOrUpdateAsync(betResult);
        }

        public async Task<bool> PayForUserBet(Guid BetResultId, double Balance)
        {
            var betResult = _repository.GetAllIncluding(x => x.Bet.User).FirstOrDefault(x => x.Id == BetResultId);
            var UserId = betResult.Bet.UserId;
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
                betResult.isPaid = true;
                await _repository.UpdateAsync(betResult);
                return true;
            }
            return false;
        }
    }
}
