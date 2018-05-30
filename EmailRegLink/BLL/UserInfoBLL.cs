using EmailRegLink.DAL;
using EmailRegLink.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailRegLink.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL userDal = new UserInfoDAL();
        public void Insert(UserInfo user)
        {
            userDal.Insert(user);
        }
        public void update(int id)
        {
            userDal.update(id);
        }
        public UserInfo QueryId(string UserName)
        {
            return userDal.QueryId(UserName);
        }
        public void DeleteById(int id)
        {
            userDal.DeleteById(id);
        }
        public UserInfo isUser(string userName, string Email)
        {
            return userDal.isUser(userName,Email);
        }
    }
}