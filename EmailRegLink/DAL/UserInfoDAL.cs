using EmailRegLink.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmailRegLink.DAL
{
    public class UserInfoDAL
    {
        SQLHelper sqlHelp = new SQLHelper();
        public void Insert(UserInfo user)
        {
            sqlHelp.ExecuteNonQuery(@"INSERT INTO regUser
                       (userName, password,Email,state,actiCode,expTime)
                        VALUES
                       (@userName, @password,@Email,@state,@actiCode,@expTime)",
                       new SqlParameter("@userName", user.userName),
                       new SqlParameter("@password", user.password),
                       new SqlParameter("@Email",user.email),
                       new SqlParameter("@state",user.state=0),
                        new SqlParameter("@actiCode", user.actiCode),
                         new SqlParameter("@expTime", user.expTime));
        }

        public void update(int id)
        {
            sqlHelp.ExecuteNonQuery(@"update regUser set state=1,expTime='9999/12/31 00:00:00' where id=@id",
                new SqlParameter("@id", id));
        }

        public UserInfo QueryId(string userName)
        {
            UserInfo user = new UserInfo();
            SqlDataReader reader = sqlHelp.ExecuteSqlReader("select id,userName,Email,actiCode,expTime,state from regUser where userName=@userName",
                new SqlParameter("@userName", userName));
            while (reader.Read())
            {
                user.id = reader.GetInt32(0);
                user.userName = reader.GetString(1);
                user.email = reader.GetString(2);
                user.actiCode = reader.GetString(3);
                user.expTime = reader.GetDateTime(4);
                user.state = reader.GetInt32(5);
            }
            reader.Close();
            return user;
        }

        public void DeleteById(int id)
        {
            sqlHelp.ExecuteNonQuery("delete from regUser where id=@id",
                new SqlParameter("@id", id));
        }

        public UserInfo isUser(string userName,string Email)
        {
            UserInfo user = new UserInfo();
            SqlDataReader reader = sqlHelp.ExecuteSqlReader("select userName,Email from regUser where userName=@userName or Email=@Email",
                new SqlParameter("@userName", userName),
                new SqlParameter("@Email", Email));
            while (reader.Read())
            {
                user.userName = reader.GetString(0);
                user.email = reader.GetString(1);
            }
            reader.Close();
            return user;
        }
    }
}