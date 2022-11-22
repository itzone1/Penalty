using Abp.Domain.Entities.Auditing;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PaySystems.Services
{
    public interface IPaySystemDomainService : IDomainService
    {
        public Task<string> AddNewPayment(Guid BetId);
        public string sign_hash(string[] arr);
        public string Base64Encode(string plainText);
        public Task<string> GenerateUrl(PaySystem paySystem);
        public Task<string> PayExistingPayment(Guid BetId);
        public Task<bool> CheckPayment(Guid BetId);
        IList<PaySystem> GetAll();
    }
}
