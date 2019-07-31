using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccessLayer;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
  public  class RepositoryBase
  {

      private static DatabaseContext _db;
        private  static  object _lookSync=new object();
      protected RepositoryBase()//constructer ın protected olması demek bu class new lenemez demek miras alan sadece newleyebilir demektir.
      {

      }
      public static DatabaseContext CreateContext()
      {
          if (_db==null)
          {


              lock (_lookSync)
              {

                  if (_db==null)
                  {
                      _db = new DatabaseContext();
                    }
                  
                }
              

          }

          return _db;


      }

  }
}
