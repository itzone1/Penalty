using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Penalty.Penalty.Classes.RootEntities.Teams.Services;
using Penalty.Penalty.ODDSApiMatches.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.worker
{
    public class BackGroundWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IODDSApiDoaminService _ODDSApiDomainService;

        public BackGroundWorker(AbpTimer timer, IODDSApiDoaminService oDDSApiDomainService) : base(timer)
        {
            Timer.Period = 20000;
            _ODDSApiDomainService = oDDSApiDomainService;
        }

        [UnitOfWork]
        protected override void DoWork()
        {
            _ODDSApiDomainService.GetAll();
            //using (var httpclient = new HttpClient())
            //{
            //    try
            //    {
            //        var response = httpclient.GetAsync("https://bcda-37-48-178-113.ngrok.io/api/services/app/Team/BackGroundWorker");
            //    }
            //    catch (Exception ex)
            //    {
            //        var message = ex.Message;
            //    }
            //    // var responseString =  response.Content.ReadAsStringAsync();
            //}

        }
    }
}
