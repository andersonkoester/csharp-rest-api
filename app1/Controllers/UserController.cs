using System.Collections.Generic;
using System.Linq;
using app1.Models;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers {

    [Route("api/user")]
    public class UserController : Controller {
        
        private static List<UserModel> userList = new List<UserModel>();

        // GET: api/user
        [HttpGet]
        public IActionResult getUserList(HttpRequestMessage request) {
            return new ObjectResult(userList);
        }

        // GET api/user/5
        [HttpGet("{code}")]
        public UserModel getUser(int code) {
            UserModel user = userList.Where(n => n.Code == code)
                .Select(n => n)
                .First();
            return user;
        }

        // POST api/user
        [HttpPost]
        public UserModel createUser([FromBody] UserModel user) {
            userList.Add(user);
            return user;
        }

        // PUT api/user/5
        [HttpPut("{code}")]
        public UserModel updateUser(int code, [FromBody] UserModel user) {
            UserModel userResult = new UserModel();
            userList.Where(n => n.Code == code)
                .Select(s => {
                    s.Code = user.Code;
                    s.Login = user.Login;
                    s.Name = user.Name;
                    userResult = s;
                    return s;
                }).ToList();

            return userResult;
        }

        // DELETE api/user/5
        [HttpDelete("{code}")]
        public string deleteUser(int code) {
            UserModel user = userList.Where(n => n.Code == code)
                .Select(n => n)
                .First();

            userList.Remove(user);

            return "Registro excluido";
        }
    }
}
