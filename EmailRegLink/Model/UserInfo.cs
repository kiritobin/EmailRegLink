using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailRegLink.Model
{
    public class UserInfo
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int state { get; set; }
        public string actiCode { get; set; }
        public DateTime expTime { get; set; }
    }
}