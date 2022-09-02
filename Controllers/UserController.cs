using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace backend.Controllers
{
    public class UserController : ApiController
    {
        CrpEntities db = new CrpEntities();
        [Route("api/User/AddUser")]
        [HttpPost]
        public Response AddUser(User_Model userModel)
        {
            Response response = new Response();
            tblcrpdb user = new tblcrpdb();
            user.name = userModel.name;
            user.password = userModel.password;
            user.confirmpassword = userModel.confirmpassword;
            user.email = userModel.email;
            if (user != null)
            {
                db.tblcrpdb.Add(user);
                db.SaveChanges();
                response.ResponseCode = "200";
                response.ResponseMessage = "User added";
            }
            else
            {
                response.ResponseCode = "100";
                response.ResponseMessage = "Error" +
                    "";
            }
            return response;
        }

        [Route("api/User/GetUser")]
        [HttpGet]
        public Response GetUsers()
        {
            Response response = new Response();
            List<tblcrpdb> listUsers = new List<tblcrpdb>();
            listUsers = db.tblcrpdb.ToList();
            response.ResponseCode = "200";
            response.ResponseMessage = "Data fetched";
            response.listUsers = listUsers;
            return response;
        }
        [Route("api/login")]
        [HttpPost]
        public string UserLogin(Login login)

        {
            string output;
            var log = db.tblcrpdb.Where(x => x.ID.Equals(login.ID) && x.password.Equals(login.password)).FirstOrDefault();
            if (log == null)
            {
                output = "UserId or password is invalid";
            }
            else
            {
                output = "success";
            }
            return output;
        }
    }
}

