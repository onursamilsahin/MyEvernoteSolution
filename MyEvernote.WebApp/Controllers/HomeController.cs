using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using MyEvernote.Entities.ValueObjects;
 
namespace MyEvernote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

          //   test.InsertTest();  //Bunlar veri eklemek güncellemek için yazılmış kodlar Test class ında herşey var incelenebilir.
           //  test.UpdateTest();
          //  test.DeleteTest();
           // test.CommentTest();

            //if (TempData["mm"] != null)
            //{
            //    return View(TempData["mm"] as List<Note>);

            //}
            NoteManager nm=new NoteManager();

            return View(nm.GetAllNote().OrderByDescending(x => x.ModifiedOn));
            //return View(nm.GetAllNoteQueryable().OrderByDescending(x=>x.ModifiedOn).ToList());


        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            CategoryManager cm = new CategoryManager();

            Category cat = cm.GetCategoryById(id.Value);
            if (cat == null)
            {
                return HttpNotFound();

            }


            return View("Index", cat.Notes.OrderByDescending(x=>x.ModifiedOn));
        }



        public ActionResult MostLiked()
        {
            NoteManager nm1 = new NoteManager();




            return View("Index", nm1.GetAllNote().OrderByDescending(x => x.LikeCount).ToList());
        }

        public ActionResult About()
        {


            return View();
        }


        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public  ActionResult Login(LoginViewModel model)
        {
            //giriş kontrolü ve yönlendirme
            //Session a bilgileri tutma

            return View();

        }

        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            // Bool en kullanılarak kontrol sağlanabilir.
            //if (ModelState.IsValid)
            //{
            //    bool hasError = false;

            //    if (model.Username=="aaa")
            //    {
            //        ModelState.AddModelError("","Kullanıcı Adı Kullanılıyor");

            //        hasError = true;
            //    }

            //    if (model.EMail=="aaa@aa.com")
            //    {

            //        ModelState.AddModelError("","E-posta Kullanılıyor.");

            //        hasError = true;
            //    }

            //    if (hasError)
            //    {
            //        return View(model);
            //    }

            //    return RedirectToAction("RegisterOK");




            //}

            if (ModelState.IsValid)
            {


                EverNoteUserManager eum =new EverNoteUserManager();
                EvernoteUser user = null;

                try
                {
                user=eum.RegisterUser(model);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("",e.Message);
                    throw;
                }


                if (user==null)
                {
                    return View(model);
                }


                return RedirectToAction("RegisterOk");


            }


            //model de hata olup olmadığını modelstate i kontrol ederek de bulabiliyoruz ve buna göre de işlem veya yönlendirme yapabiliyoruz.
            //if (ModelState.IsValid)
            //{
                

            //    if (model.Username == "aaa")
            //    {
            //        ModelState.AddModelError("", "Kullanıcı Adı Kullanılıyor");

                  
            //    }

            //    if (model.EMail == "aaa@aa.com")
            //    {

            //        ModelState.AddModelError("", "E-posta Kullanılıyor.");

                
            //    }

            //    foreach (var item in ModelState)
            //    {


            //        if (item.Value.Errors.Count>0)
            //        {
            //            return View(model);

            //        }
            //    }

            //    return RedirectToAction("RegisterOK");




            //}
            //kullanıcı username kontrolü 
            //kullanıcı e-posta kontrolu
            //Kayıt işlemi
            // Aktivasyon işlemi eposta gönderimi 

            return View(model);
        }

        public ActionResult RegisterOk()
        {

            return View();

        }    

        public ActionResult UserActivate(Guid active_id)
        {
            //Kullanıcı Aktivasyonu yapılacak

            return View();
        }

        public ActionResult Logout()
        {

            return View();
        }






    }
}