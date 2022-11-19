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
        public string AddNewPayment(PaySystem paySystem);
        public string sign_hash(string[] arr);
        public string Base64Encode(string plainText);
        public string GenerateUrl(PaySystem paySystem);
        public string PayExistingPayment(Guid BetId);
    }
}
