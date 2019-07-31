using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using MyEvernote.Entities.ValueObjects;

namespace MyEvernote.BusinessLayer
{
  public  class EverNoteUserManager
    {
        private Repository<EvernoteUser> repo_user=new Repository<EvernoteUser>();

        public EvernoteUser RegisterUser(RegisterViewModel data)
        {
            //kullanıcı Username kontrolü
            //kullanıcı E-posta kontrolü 
            //Kayıt işlemi 
            //Aktivasyon e-postası gönderimi..


            repo_user.Find(x => x.Username == data.Username || x.Email == data.EMail);
            if (repo_user != null)
            {

                throw new Exception("Kayıtlı kullanıcı adı yada e-posta adresi");
            }







        }
    }
}
