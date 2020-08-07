using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AplicacionWeb.ActionFilters;
using BusinessEntities;
using BussinessServices;

namespace AplicacionWeb.Controllers
{
    [System.Web.Http.RoutePrefix("v1")]
    public class UserController : ApiController
    {
        private readonly IUserServices _userServices;
        // GET: User
       public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost, Route("user")]
        public int Post([FromBody] UserEntity userEntity)
        {
            //return _userServices.create CreateProduct(productEntity);
            return _userServices.CreateUser(userEntity);
        }
    }
}