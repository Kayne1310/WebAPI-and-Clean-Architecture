using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Entites.ViewModel
{
    public class AccountLoginRequestData
    {

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class AccountLogOutRequestData
    {
        public string Token { get; set; }

    }

    public class Account_UpdateRefeshTokenRequestData
    {
        public int UserId { get; set; }
        public string RefeshToken { get; set; }
        public DateTime Exprired { get; set; }
    }
}
