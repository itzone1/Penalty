using System.Threading.Tasks;
using Penalty.Models.TokenAuth;
using Penalty.Web.Controllers;
using Shouldly;
using Xunit;

namespace Penalty.Web.Tests.Controllers
{
    public class HomeController_Tests: PenaltyWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}