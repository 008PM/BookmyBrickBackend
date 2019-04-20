using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyBrickDomain.UserAccount;
using BookMyBrickDomain;
using Microsoft.AspNetCore.Cors;
using BookMyBrickDomain.Service.DeliveryCost;

namespace BookMyBrickBackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [Route("userLogin")]
        [HttpPost]
        [HttpOptions]
        public bool userLogin([FromBody]UserCredentials logindetails)
        {
            var loginData = logindetails;
            AccountManagement logobj = new AccountManagement();
            return logobj.UserLogging(loginData);
        }

        [Route("GetUserDetails")]
        [HttpPost]
        [HttpOptions]
        public double getUserDetails([FromBody] string usermail)
        {
            var userMail = usermail;
            DelivaryCostManagement userdetails = new DelivaryCostManagement();
            return userdetails.GetUserInfo(userMail);
        }
    }
}