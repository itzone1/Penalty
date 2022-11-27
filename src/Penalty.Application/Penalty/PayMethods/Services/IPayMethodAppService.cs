using Abp.Application.Services;
using Penalty.Penalty.PayMethods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PayMethods.Services
{
    public interface IPayMethodAppService : IApplicationService
    {
        IList<PayMethodDto> GetAll();
        Task<IList<PayMethodDto>> GetAllPayMethodsAsync();
        Task<PayMethodDto> GetbyId(Guid id);
        Task<PayMethodDto> Insert(PayMethodDto payMethodDto);
        Task<PayMethodDto> Update(PayMethodDto payMethodDto);
        void Delete(Guid id);
        Task<PayMethodDto> CheckAccount(PayMethodDto payMethodDto);
        Task<string> GetAccountNumberbyUser();
    }
}
