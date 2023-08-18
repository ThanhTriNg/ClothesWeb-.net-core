using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesWeb.Models
{
    public class UserManager
    {
        ClothesWebContext ctx = new ClothesWebContext();
        public bool CheckCustomerName(String UserName)
        {
            List<User> userlist = (from user in ctx.Users where user.UserName == UserName select user).ToList();
            if (userlist.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckCustomerEmail(String Email)
        {
            List<User> emaillist = (from user in ctx.Users where user.UserEmail == Email select user).ToList();
            if (emaillist.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool CheckCustomerPassword(String Password)
        {
            List<User> Passwordlist = (from user in ctx.Users where user.UserPassword == Password select user).ToList();
            if (Passwordlist.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool CheckLogin(String Email, String Password)
        {
            User user = ctx.Users.Where(m => m.UserEmail == Email).FirstOrDefault();
            if (user != null)
            {
                if (user.UserPassword == Encrypt.MD5Hash(Password))
                    return true;
                else return false;

            }

            return false;
        }
    }
}
