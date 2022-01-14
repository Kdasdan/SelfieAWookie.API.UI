using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.UI.Controllers;
using Xunit;

namespace TestWebApi
{
    public class SelfieControllerUnitTest
    {
        #region Public methods
        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            // ARRANGE
            var controller = new SelfiesController(null);

            // ACT
            var result = controller.TestAMoi();

            // ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = (OkObjectResult)result; 
            Assert.NotNull(okResult.Value);
        }
        #endregion
    }
}