using Abp.Domain.Services;
using Penalty.Penalty.Classes.RootEntities.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PayMethods.Services
{
    public interface IPayMethodDomainService : IDomainService
    {
        IList<PayMethod> GetAll();
        Task<IList<PayMethod>> GetAllPayMethodsAsync();
        Task<PayMethod> GetbyId(Guid id);
        Task<PayMethod> Insert(PayMethod payMethod);
        Task<PayMethod> Update(PayMethod payMethod);
        void Delete(PayMethod payMethod);
        Task<PayMethod> CheckAccount(PayMethod payMethod);

    }
}
