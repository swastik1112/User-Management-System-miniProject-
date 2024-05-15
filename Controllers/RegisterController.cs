using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using miniProject.Models;
using miniProject.ViewModels;
using System.Collections.Generic;

namespace miniProject.Controllers
{
    public class RegisterController : Controller
    {

        public ActionResult Login()
        {
            if (Request.Cookies["mycookie1"] != null && Request.Cookies["mycookie2"] != null)
            {
                HttpContext.Session.SetString("LoginName", Request.Cookies["mycookie1"]);
                return RedirectToAction(nameof(Index));
            }  

            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel reguser)
        {
            try
            {
                if (Register.GetLoginUser(reguser.LoginName, reguser.Password))
                {
                    HttpContext.Session.SetString("LoginName", reguser.LoginName);

                    if (reguser.CheckBox)
                    {
                        Response.Cookies.Append("mycookie1", reguser.LoginName);
                        Response.Cookies.Append("mycookie2", reguser.Password);
                    }

                    return RedirectToAction(nameof(Index));
                }

                ViewBag.message = "Please Provide Correct Credentials";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }


        // GET: RegisterController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("LoginName") != null)
            {
                List<Register> list = Register.GetAllRegUser();

                foreach (Register item in list)
                {

                    ViewData[item.LoginName] = City.GetCityName(item.CityNo);

                }
                return View(list);
            }
               return RedirectToAction(nameof(Login));
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("LoginName") != null)
            {

                Register regUser = Register.GetSingleUser(id);

                ViewData["CityName"] = City.GetCityName(regUser.CityNo);

                return View(regUser);
            }
            return RedirectToAction(nameof(Login));
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            
                RegisterViewModel o = new RegisterViewModel();

                List<SelectListItem> objcity = City.GetAllCity();

                o.City = objcity;

                ViewBag.City = objcity;

                return View(o);
           
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Register reguser)
        {
            try
            {
                Register.InsertUser(reguser);
                ViewBag.message = "Inserted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("LoginName") != null)
            {

                Register obj = Register.GetSingleUser(id);
                RegisterViewModel o = new RegisterViewModel();
                o.UserNo = obj.UserNo;
                o.LoginName = obj.LoginName;
                o.FullName = obj.FullName;
                o.Gender = obj.Gender;
                o.EmailId = obj.EmailId;
                o.Mobile = obj.Mobile;
                o.CityNo = obj.CityNo;

                List<SelectListItem> objcity = City.GetAllCity();
                
                o.City = objcity;
                ViewBag.City = objcity;

                return View(o);
            }
            return RedirectToAction(nameof(Login));
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RegisterViewModel reguser)
        {
            Register obj = new Register { UserNo = reguser.UserNo, LoginName = reguser.LoginName, FullName = reguser.FullName, EmailId = reguser.EmailId, Gender = reguser.Gender, Mobile = reguser.Mobile, Password = reguser.Password, CityNo = reguser.CityNo };
            try
            {
                Console.WriteLine(obj.CityNo);
                Register.UpdateUser(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewBag.message = ex.Message;
                return View();

            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("LoginName") != null)
            {
                Register regUser = Register.GetSingleUser(id);
                return View(regUser);
            }
            return RedirectToAction(nameof(Login));
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Register regUser,int UserNo)
        {
            try
            {
                Register.DeleteUser(UserNo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("LoginName");
            if (Request.Cookies["mycookie1"]!= null && Request.Cookies["mycookie2"] != null)
            {
                Response.Cookies.Delete("mycookie1");
                Response.Cookies.Delete("mycookie2");
            }

            return RedirectToAction(nameof(Login));
        }

        public ActionResult ViewAll()
        {
            List<Register> regList = Register.GetAllRegUserSorted();
            List<ViewAll> viewAllList = new List<ViewAll>();

            foreach(Register reg in regList) 
            {
                viewAllList.Add(new ViewAll { UserNo = reg.UserNo, LoginName = reg.LoginName, FullName = reg.FullName, Gender = reg.Gender, EmailId = reg.EmailId, Mobile = reg.Mobile, CityName = City.GetCityName(reg.CityNo) });
            }
            return View(viewAllList);
        }
    }
}
