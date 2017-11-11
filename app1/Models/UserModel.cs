using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app1.Models{
    public class UserModel{
        private int code;
        private string name;
        private string login;

        public UserModel(){}

        public UserModel(int code, string name, string login) {
            this.Code = code;
            this.Name = name;
            this.Login = login;
        }

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Login { get => login; set => login = value; }
    }
}
