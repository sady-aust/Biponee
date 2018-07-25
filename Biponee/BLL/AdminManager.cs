using Biponee.DLL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.BLL
{
    public class AdminManager
    {
        AdminGetway adminGetway = new AdminGetway();
        public int isExist(String email,String Password)
        {
            List<AdminC> list = adminGetway.getAdminByEmailAnsPassword(email, Password);

            if (list.Count == 1)
            {
                return list[0].ID;
            }

            return -1;

        }

        public AdminC getAdminInfo(int adminId)
        {
            List<AdminC> list = adminGetway.getAdminById(adminId);

            return list[0];
        }



       

    }
}