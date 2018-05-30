using EmailRegLink.BLL;
using EmailRegLink.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailRegLink
{
    public partial class Regist : System.Web.UI.Page
    {
        UserInfo user = new UserInfo();
        UserInfoBLL userBll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool isUser()
        {
            string userName = txtName.Text.Trim();
            string mail = txtMail.Text.Trim();
            string password = txtPwd.Text.Trim();

            user = userBll.isUser(userName, mail);

            if (userName=="")
            {
                Response.Write("用户名不能为空");
                return false;
            }
            if (password == "")
            {
                Response.Write("密码不能为空");
                return false;
            }
            if (mail == "")
            {
                Response.Write("邮箱不能为空");
                return false;
            }
            if (userName == user.userName)
            {
                Response.Write("用户名已存在");
                return false;
            }
            if (mail == user.email)
            {
                Response.Write("邮箱已存在");
                return false;
            }
            else
            {
                userName = "";
                mail = "";
                password = "";
                return true;
            }

        }
        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (isUser() == true)
            {
                user.userName = txtName.Text.Trim();
                user.password = txtPwd.Text.Trim();
                user.email = txtMail.Text.Trim();

                DateTime now = DateTime.Now;
                string strTime = DateTime.Now.AddMinutes(1).ToString() + "." + now.Millisecond;
                DateTime dt = Convert.ToDateTime(strTime);
                user.expTime = dt;

                string strCode = user.userName + dt;
                user.actiCode = EnDecrypt.Encrypt(strCode);

                userBll.Insert(user);
                sendMail();
                Response.Write("邮件已发送");
            }

        }

        private void sendMail()
        {
            string addresser = "user@idaobin.com";
            string recipient = txtMail.Text.Trim();
            string userName = txtName.Text.Trim();
            string emailPwd = "daobin@123";

            user = userBll.QueryId(userName);
            string id = EnDecrypt.Encrypt(user.id.ToString());
            string code = user.actiCode;

            string title = "感谢您注册,请验证邮箱（邮箱注册）";
            string str = string.Format("http://localhost:9312/RegistSuccess.aspx?userName={0}&id={1}&token={2}", userName, id, code); //激活码链接
            string content = "请点击下面的链接完成邮箱验证 " + str;
            MailMessage message = new MailMessage(addresser, recipient);
            message.Subject = title;
            message.Body = content;
            message.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient("smtp.mxhichina.com", 25);
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(addresser, emailPwd);
            client.Send(message);
        }
    }
}