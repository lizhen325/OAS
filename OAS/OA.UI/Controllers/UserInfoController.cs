using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.BLL;

namespace OA.UI.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly UserInfoBLL bll = new UserInfoBLL();
        //
        // GET: /UserInfo/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserInfo()
        {
            int pageIndex, pageSize;
            if (Request["page"] != null) pageIndex = int.Parse(Request["page"]);
            else pageIndex = 1;
            if (Request["rows"] != null) pageSize = int.Parse(Request["rows"]);
            else pageSize = 5;

            int totalCount;
            var userInfoList = bll.LoadPageEntities(pageIndex, pageSize, out totalCount, u => u.DelFlag == (int)OA.Moel.Enum.DelFlagEnum.Normal, u => u.id, true);
            var temp = from u in userInfoList
                       select new
                       {
                           ID = u.id,
                           UserName = u.UserName,
                           DateOfBirth = u.DateOfBirth,
                           Address = u.Address,
                           Nationality = u.Nationality,
                           Email = u.Email,
                           Occupation = u.Occupation,
                           FullName = u.FullName,
                           JoinTime = u.JoinTime
                       };
            //bll.Dispose();
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);
        }
    }
}
