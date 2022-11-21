using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Abp.Domain.Entities.Auditing;
using System;
using System.Security.Cryptography;
using System.Text;
using Abp.Domain.Repositories;
using Penalty.Penalty.Classes.RootEntities.Bets;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using Nito.AsyncEx.Synchronous;
using System.Net;
using Penalty.Penalty.Classes.RootEntities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Penalty.Penalty.PaySystems.Services
{
    public class PaySystemDomainService : IPaySystemDomainService
    {
        private readonly IRepository<PaySystem, Guid> _paySystemRepository;
        private readonly IRepository<Bet, Guid> _Betrepository;
        private readonly IRepository<GeneralSettings, Guid> _generalSettings;

        public PaySystemDomainService(IRepository<PaySystem, Guid> paySystemRepository, IRepository<Bet, Guid> betrepository, IRepository<GeneralSettings, Guid> generalSettings)
        {
            _paySystemRepository = paySystemRepository;
            _Betrepository = betrepository;
            _generalSettings = generalSettings;
        }

        public async Task<string> AddNewPayment(Guid BetId)
        {
            var bet = _Betrepository.FirstOrDefault(x => x.Id == BetId);
           var paySystemId = _Betrepository.FirstOrDefault(x => x.Id == BetId).PaySystemId;
            var paySystem = _paySystemRepository.FirstOrDefault(x => x.Id == paySystemId);
            return await GenerateUrl(paySystem);
        }
        public async Task<string> PayExistingPayment(Guid BetId)
        {
            PaySystem paySystem = _Betrepository.Get(BetId).PaySystem;
            return await GenerateUrl(paySystem);
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public async Task<string> GenerateUrl(PaySystem paySystem)
        {
            var orderId = 1;
            var payments = _paySystemRepository.GetAll();
            if (payments.ToList().Count > 0)
            {
                try
                {
                    orderId = payments.OrderBy(x => x.m_orderid).Select(x => x.m_orderid).LastOrDefault() + 1;
                }
                catch (Exception ex)
                {

                }
            }
            paySystem.m_orderid = orderId;
            paySystem.isCompleted = false;

            var m_shop = paySystem.m_shop.ToString();
            var m_orderid = paySystem.m_orderid.ToString();
            var m_amount = paySystem.m_amount.ToString() + ".00" ;
            var m_curr = "USD";
            var m_desc = Base64Encode(paySystem.m_desc.ToString());
            var m_key = paySystem.m_key.ToString();
            var arr = new string[] { m_shop, m_orderid, m_amount, m_curr, m_desc, m_key };
            var sign = sign_hash(arr);
            await _paySystemRepository.InsertOrUpdateAsync(paySystem);
            return paySystem.MerchantUrl.ToString() + "?m_shop="+ m_shop +"&m_orderid="+ m_orderid +"&m_amount="+ m_amount +"&m_curr=USD&m_desc="+ m_desc +"&m_sign=" + sign +"&lang=en";

        }

        public string sign_hash(string[] arr)
        {
            var signdata = String.Join(":", arr);
            byte[] data = Encoding.Default.GetBytes(signdata);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToUpper();
        }

        public async Task<bool> CheckPayment(Guid BetId)
        {
            var bet = _Betrepository.GetAllIncluding(x => x.PaySystem).FirstOrDefault(x => x.Id == BetId);
            var paySystemId = _Betrepository.FirstOrDefault(x => x.Id == BetId).PaySystemId;
            var paySystem = _paySystemRepository.FirstOrDefault(x => x.Id == paySystemId);
            var settings = _generalSettings.GetAll().FirstOrDefault();

            var cl = new HttpClient();
            cl.BaseAddress = new Uri("https://payeer.com/ajax/api/api.php");
            int _TimeoutSec = 90;
            cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
            string _ContentType = "application/form-data";
            cl.DefaultRequestHeaders.Add("merchantId", settings.MerchantId);
            cl.DefaultRequestHeaders.Add("account", settings.MainAccount);
            cl.DefaultRequestHeaders.Add("apiId", settings.ApiKey);
            cl.DefaultRequestHeaders.Add("apiPass", settings.ApiPass);
            cl.DefaultRequestHeaders.Add("action", "paymentDetails");
            cl.DefaultRequestHeaders.Add("referenceId", paySystem.m_orderid.ToString());
            cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
            var _UserAgent = "d-fens HttpClient";
            cl.DefaultRequestHeaders.Add("User-Agent", _UserAgent);

            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("key of content", "value"));
            nvc.Add(new KeyValuePair<string, string>("merchantId", settings.MerchantId));
            nvc.Add(new KeyValuePair<string, string>("account", settings.MainAccount));
            nvc.Add(new KeyValuePair<string, string>("apiId", settings.ApiKey));
            nvc.Add(new KeyValuePair<string, string>("apiPass", settings.ApiPass));
            nvc.Add(new KeyValuePair<string, string>("action", "paymentDetails"));
            nvc.Add(new KeyValuePair<string, string>("referenceId", paySystem.m_orderid.ToString()));
            var req = new HttpRequestMessage(HttpMethod.Post, "https://payeer.com/ajax/api/api.php") { Content = new FormUrlEncodedContent(nvc) };
            var res = cl.SendAsync(req).Result.Content.ReadAsStringAsync();

            dynamic data = JObject.Parse(res.Result);
            bool success = data.success;
            if(success == true)
            {
                paySystem.isCompleted = true;
                await _paySystemRepository.UpdateAsync(paySystem);
                return true;
            }
            return false;
        }
    }
}
