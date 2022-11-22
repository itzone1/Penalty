using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Nito.AsyncEx.Synchronous;
using Penalty.Penalty.Classes.RootEntities.Teams.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.ODDSApiMatches.Services
{
    public class BackGroundWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {

        public BackGroundWorker(AbpTimer timer) : base(timer)
        {
            Timer.Period = 3600000;
            //Timer.Period = 20000;
        }

        [UnitOfWork]
        protected override void DoWork()
        {
            using (var httpclient = new HttpClient())
            {
                try
                {

                    var response = httpclient.GetAsync("http://penalty-bet.com:81/api/services/app/Team/BackGroundWorker");
                    var result = response.WaitAndUnwrapException();
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }
                // var responseString =  response.Content.ReadAsStringAsync();
            }
        }
    }
}
