using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using OA.Moel;

namespace OA.UI.API
{
    public class UserInfoView
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string FullName { get; set; }
        public int DelFlag { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public System.DateTime JoinTime { get; set; }
    }
    public class UserInfoController : ApiController
    {
        private readonly OAEntities dbcontext = new OAEntities();
        //api/UserInfo
        public IQueryable<UserInfoView> GetUserInfo()
        {
            var userinfoList = dbcontext.UserInfo.Select(u => new UserInfoView
            {
                id = u.id,
                UserName = u.UserName,
                UserPassword = u.UserPassword,
                DateOfBirth = u.DateOfBirth,
                Address = u.Address,
                Nationality = u.Nationality,
                Email = u.Email,
                Occupation = u.Occupation,
                FullName = u.FullName,
                DelFlag = u.DelFlag,
                ModifiedTime = u.ModifiedTime,
                JoinTime = u.JoinTime
            });
            return userinfoList;
        }

    }
}
