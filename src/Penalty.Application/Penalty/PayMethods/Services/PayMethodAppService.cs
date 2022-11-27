using Penalty.Penalty.Classes.RootEntities.Bets.Dto;
using Penalty.Penalty.Classes.RootEntities.Bets;
using Penalty.Penalty.PayMethods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Penalty.Authorization;

namespace Penalty.Penalty.PayMethods.Services
{
    public class PayMethodAppService : PenaltyAppServiceBase, IPayMethodAppService
    {
        private readonly IPayMethodDomainService _domainService;

        public PayMethodAppService(IPayMethodDomainService domainService)
        {
            _domainService = domainService;
        }

        public Task<PayMethodDto> CheckAccount(PayMethodDto payMethodDto)
        {
            throw new NotImplementedException();
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(Guid id)
        {
           // var payMethod = ObjectMapper.Map<PayMethod>(id);
            _domainService.Delete(id);
        }

        public Task<string> GetAccountNumberbyUser()
        {
           return _domainService.GetAccountNumberbyUser();
        }

        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public IList<PayMethodDto> GetAll()
        {
            var payMethods = _domainService.GetAll();
            return ObjectMapper.Map<List<PayMethodDto>>(payMethods);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<IList<PayMethodDto>> GetAllPayMethodsAsync()
        {
            var payMethods = await _domainService.GetAllPayMethodsAsync();
            return ObjectMapper.Map<List<PayMethodDto>>(payMethods);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<PayMethodDto> GetbyId(Guid id)
        {
            var payMethod = await _domainService.GetbyId(id);
            return ObjectMapper.Map<PayMethodDto>(payMethod);
        }

        public async Task<PayMethodDto> Insert(PayMethodDto payMethodDto)
        {
            var payMethod = ObjectMapper.Map<PayMethod>(payMethodDto);
            var createdPayMethod = await _domainService.Insert(payMethod);
            return ObjectMapper.Map<PayMethodDto>(payMethod);
        }

        public async Task<PayMethodDto> Update(PayMethodDto payMethodDto)
        {
            var payMethod = await _domainService.GetbyId(payMethodDto.Id);
            ObjectMapper.Map<PayMethodDto, PayMethod>(payMethodDto, payMethod);
            var updatedPayMethod = await _domainService.Update(payMethod);
            return ObjectMapper.Map<PayMethodDto>(updatedPayMethod);
        }
    }
}
