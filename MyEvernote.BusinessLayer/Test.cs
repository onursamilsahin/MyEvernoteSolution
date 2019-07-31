using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccessLayer;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;

namespace MyEvernote.BusinessLayer
{
  public  class Test
    {

        private Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        private Repository<Category> repo = new Repository<Category>();
        private Repository<Note> repo_note=new Repository<Note>();
        private  Repository<Comment> repo_comment=new Repository<Comment>();
        public Test()
        {



          List<Category> categories=repo.List();
        //  List<Category> categories_filtered = repo.List(x => x.Id > 5);



        }

        public void InsertTest()
        {


            Repository<EvernoteUser> repo_user=new Repository<EvernoteUser>();

            EvernoteUser data=new EvernoteUser()
            {
                Name = "qq ",
                Surname = "qq",
                Email = "saqqqqsahin4118@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "qqwww",
                Password = "111",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "qqwww"



            };

            int result = repo_user.Insert(data);
        }

        public void UpdateTest()
        {


            EvernoteUser user = repo_user.Find(x => x.Username =="qqwww");

            if (user != null)
            {

                user.Username = "xxx";
               int result=repo_user.Save();

                
            }

        }

        public void DeleteTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "xxx");
            if (user!=null)
            {

            int result=repo_user.Delete(user);
            }


        }

        public void CommentTest()
        {

            EvernoteUser user = repo_user.Find(x => x.Id == 1);
            Note note = repo_note.Find(x => x.Id == 3);

            Comment comment=new Comment()
            {
                Text = "Bu bir test'dir",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "samilsahin",
                Note = note,
                Owner = user,



            };

            repo_comment.Insert(comment);

        }

    }
}
