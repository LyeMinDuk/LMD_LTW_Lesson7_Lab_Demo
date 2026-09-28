using LMD_Day7_Lab.Models;
using LMD_Day7_Lab.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LMD_Day7_Lab.Controllers
{
    public class LmdMemberController : Controller
    {
        public static readonly List<LmdMember> members = new List<LmdMember>();

        public IActionResult LmdIndex()
        {
            return View(members);
        }

        [HttpGet]
        public IActionResult LmdCreate()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult LmdCreate(LmdMember m)
        //{
        //    string msg = null;
        //    bool validate = true;
        //    if(m.UserName.Length < 3 || m.UserName.Length > 20)
        //    {
        //        msg = "<li>Tên đăng nhập phải có độ dài từ 3-20 kí tự </li>";
        //        validate = false;
        //    }
        //    string patternEmail = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2, 4}$";
        //    if (!Regex.IsMatch(m.Email, patternEmail))
        //    {
        //        msg = "<li>Email không đúng định dạng </li>";
        //        validate = false;
        //    }
        //    if (m.Birthday.AddYears(18) > DateTime.Now)
        //    {
        //        msg = "<li>Bạn chưa đủ 18 tuổi </li>";
        //        validate = false;
        //    }
        //    if (validate)
        //    {
        //        m.MemberId = Guid.NewGuid().ToString();
        //        members.Add(m);
        //        return RedirectToAction("LmdIndex");
        //    }
        //    else
        //    {
        //        ViewBag.msg = "<div class='alert alert-danger'>" + msg + "</div>";
        //        return View(m);
        //    }
        //}

        [HttpPost]
        public IActionResult LmdCreate(LmdRegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                LmdMember m = new LmdMember
                {
                    MemberId = Guid.NewGuid().ToString(),
                    UserName = register.UserName,
                    Email = register.Email,
                    Password = register.Password,
                    Phone = register.Phone,
                    Birthday = register.Birthday
                };
                members.Add(m);
                return RedirectToAction("LmdIndex");
            }
            else
            {
                return View(register);
            }
        }
    }
}
