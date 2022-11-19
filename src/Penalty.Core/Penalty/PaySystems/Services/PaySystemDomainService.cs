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

namespace Penalty.Penalty.PaySystems.Services
{
    public class PaySystemDomainService : IPaySystemDomainService
    {
        private readonly IRepository<PaySystem, Guid> _paySystemRepository;
        private readonly IRepository<Bet, Guid> _Betrepository;

        public PaySystemDomainService(IRepository<PaySystem, Guid> paySystemRepository)
        {
            _paySystemRepository = paySystemRepository;
        }

        public string AddNewPayment(PaySystem paySystem)
        {
           return GenerateUrl(paySystem);
        }
        public string PayExistingPayment(Guid BetId)
        {
            PaySystem paySystem = _Betrepository.Get(BetId).PaySystem;
            return GenerateUrl(paySystem);
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string GenerateUrl(PaySystem paySystem)
        {
            var orderId = 1;
            var payments = _paySystemRepository.GetAll();
            if (payments != null)
            {
                orderId = payments.Select(x => x.m_orderid).LastOrDefault();
            }
            paySystem.m_orderid = orderId;
            paySystem.isCompleted = false;
            _paySystemRepository.InsertOrUpdate(paySystem);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(paySystem.MerchantUrl);
            stringBuilder.Append("/?m_shop=");
            stringBuilder.Append(paySystem.m_shop + "&");
            stringBuilder.Append("m_orderid=");
            stringBuilder.Append(paySystem.m_orderid + "&");
            stringBuilder.Append("m_amount=");
            stringBuilder.Append(paySystem.m_amount + "&");
            stringBuilder.Append("m_curr=");
            stringBuilder.Append(paySystem.m_curr + "&");
            stringBuilder.Append("m_desc=");
            stringBuilder.Append(paySystem.m_desc + "&");
            stringBuilder.Append("m_sign=");
            var arr = new string[] { paySystem.m_shop.ToString(), paySystem.m_orderid.ToString()
                , paySystem.m_amount.ToString(), paySystem.m_curr, paySystem.m_desc, paySystem.m_key.ToString() };
            var newsign = sign_hash(arr);
            stringBuilder.Append(newsign);
            stringBuilder.Append("&lang=en");
            paySystem.sign = newsign;
            _paySystemRepository.InsertOrUpdateAsync(paySystem);

            return stringBuilder.ToString();
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
