namespace Application.Web.Controllers
{
    using Application.Data;
    using System.Linq;
    using System.Web.Http;

    [Authorize]
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        private IApplicationData data;

        public UserController(IApplicationData data)
        {
            this.data = data;
        }

        [Route("Count")]
        public IHttpActionResult GetUsersCount()
        {
            var count = this.data.Users.All().Count();
            return Ok(count);
        }
    }
}
