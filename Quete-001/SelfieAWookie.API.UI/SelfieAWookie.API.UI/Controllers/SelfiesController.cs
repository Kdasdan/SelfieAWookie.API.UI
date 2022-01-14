using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        #region Fields
        private readonly ISelfieRepository? _repository;
        #endregion

        #region Constructors
        public SelfiesController(ISelfieRepository repository)
        {
            this._repository = repository;
        }
        #endregion

        #region Public methods
        //[HttpGet]
        //public IEnumerable<Selfie> TestAMoi()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        //}

        [HttpGet]
        public IActionResult TestAMoi()
        {
            //var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
            //return this.StatusCode(StatusCodes.Status204NoContent);

            var selfiesList = this._repository.GetAll();
            var model = selfiesList.Select(item => new { Title = item.Title, WookieId = item.WookieId, NbSelfiesFromeWookie = item.Wookie.Selfies.Count }).ToList();

            return this.Ok(model);
        }
        #endregion 
    }
}
