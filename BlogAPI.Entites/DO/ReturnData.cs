using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Entites.DO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
    }

    public class LoginResponseData : ReturnData
    {
        public User user { get; set; }
        public string token { get; set; }
    }

}
