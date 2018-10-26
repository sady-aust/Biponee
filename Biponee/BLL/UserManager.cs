using Biponee.DLL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.BLL
{
    public class UserManager
    {
        UserGetway userGetway = new UserGetway();
        public Boolean insertUserInfo(UserC user)
        {
            if (userGetway.InsertUser(user)>0)
            {
                return true;
            }

            return false;
        }

        public UserC getAUser(String email,String password)
        {
            List<UserC> list = userGetway.getUser(email, password);

            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        public UserC getAUser(int Uid)
        {
            List<UserC> list = userGetway.getUser(Uid);

            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        public List<UserC> getAllUser()
        {
            return userGetway.getAllUser();
        }
    }
}