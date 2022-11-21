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

namespace Penalty.Penalty.PaySystems.Services
{
    public class PaySystemDomainService : IPaySystemDomainService
    {
        private readonly IRepository<PaySystem, Guid> _paySystemRepository;
        private readonly IRepository<Bet, Guid> _Betrepository;

        public PaySystemDomainService(IRepository<PaySystem, Guid> paySystemRepository, IRepository<Bet, Guid> betrepository)
        {
            _paySystemRepository = paySystemRepository;
            _Betrepository = betrepository;
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
    }
}
