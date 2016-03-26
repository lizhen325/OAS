using OA.Moel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OA.BLL;

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

    public class UserInfosController : ApiController
    {
        private readonly OAEntities dbcontext = new OAEntities();
        private readonly UserInfoBLL bll = new UserInfoBLL();
        // GET api/<controller>
        public IQueryable<UserInfoView> Get()
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

        // GET api/UserInfos/id
        public UserInfoView Get(int id)
        {
            var userinfo = dbcontext.UserInfo.FirstOrDefault(u => u.id == id);
            UserInfoView uiv = new UserInfoView();
            uiv.UserName = userinfo.UserName;
            uiv.UserPassword = userinfo.UserPassword;
            uiv.DateOfBirth = userinfo.DateOfBirth;
            uiv.Address = userinfo.Address;
            uiv.Nationality = userinfo.Nationality;
            uiv.Email = userinfo.Email;
            uiv.Occupation = userinfo.Occupation;
            uiv.FullName = userinfo.FullName;
            uiv.DelFlag = userinfo.DelFlag;
            uiv.ModifiedTime = userinfo.ModifiedTime;
            uiv.JoinTime = userinfo.JoinTime;
            return uiv;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}