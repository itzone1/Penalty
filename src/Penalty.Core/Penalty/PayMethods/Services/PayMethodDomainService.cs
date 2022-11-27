using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Penalty.Authorization.Users;
using Penalty.Penalty.Classes.RootEntities.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PayMethods.Services
{
    public class PayMethodDomainService : IPayMethodDomainService
    {
        private readonly IRepository<PayMethod, Guid> _repository;
        private readonly UserManager _userManager;
        private IAbpSession AbpSession { get; set; }

        public PayMethodDomainService(IRepository<PayMethod, Guid> repository, UserManager userManager, IAbpSession abpSession)
        {
            _repository = repository;
            _userManager = userManager;
            AbpSession = abpSession;
        }

        public void Delete(Guid id)
        {
          _repository.Delete(id);
        }

        public IList<PayMethod> GetAll()
        {
            return _repository.GetAllIncluding(x => x.User).ToList();
        }

        public async Task<IList<PayMethod>> GetAllPayMethodsAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<PayMethod> GetbyId(Guid id)
        {
            return _repository.GetAllIncluding(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public async Task<PayMethod> Insert(PayMethod payMethod)
        {
            var Exist = _repository.GetAllIncluding(x => x.User).Where(x => x.UserId == AbpSession.UserId).FirstOrDefault();
            if(Exist != null)
            {
                Exist.AccountNumber = payMethod.AccountNumber;
                return await _repository.UpdateAsync(Exist);
            }
            if (AbpSession.UserId != null)
            {
                payMethod.User = _userManager.GetUserById((long)AbpSession.UserId);
            }
            return await _repository.InsertAsync(payMethod);
        }

        public async Task<PayMethod> Update(PayMethod payMethod)
        {
            return await _repository.InsertOrUpdateAsync(payMethod);
        }

        public Task<PayMethod> CheckAccount(PayMethod payMethod)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAccountNumberbyUser()
        {
            var Exist =  _repository.GetAllIncluding(x => x.User).Where(x => x.UserId == AbpSession.UserId).FirstOrDefault();
            return Exist.AccountNumber.ToString();
        }
    }
}
