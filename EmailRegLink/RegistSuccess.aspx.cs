using EmailRegLink.BLL;
using EmailRegLink.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailRegLink
{
    public partial class RegistSuccess : System.Web.UI.Page
    {
        UserInfo user = new UserInfo();
        UserInfoBLL userBll = new UserInfoBLL();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string strTime = DateTime.Now.ToString() + "." + now.Millisecond;
            DateTime dt = Convert.ToDateTime(strTime);
            string userName = Request.QueryString["userName"];
            string id =Request.QueryString["id"];
            string token = Request.QueryString["token"];

            string url = Request.Url.AbsoluteUri.ToString();
            if (url=="http://localhost:9312/RegistSuccess.aspx" || userName == null || id == null || token == null)
            {
                Response.Write("无效链接");
                return;
            }
            if (!IsPostBack)
            {
                user = userBll.QueryId(userName);
                string name = user.userName;
                DateTime exptime = user.expTime;
                string code = user.actiCode;
                int flag = user.state;
                
                if (name == userName && flag == 0 && dt < exptime)
                {
                    userBll.update(Convert.ToInt32(EnDecrypt.Decrypt(id)));
                    Response.Write("注册成功");
                }
                else
                {
                    if (code == token && name == userName && flag == 1)
                    {
                        Response.Write("用户已激活");
                        return;
                    }
                    if (name == userName && flag == 0 && dt > exptime)
                    {
                        userBll.DeleteById(Convert.ToInt32(EnDecrypt.Decrypt(id)));
                        Response.Write("失效，请重新注册");
                        return;
                    }
                    else
                    {
                        Response.Write("无效链接");
                    }
                }
            }
        }
    }
}