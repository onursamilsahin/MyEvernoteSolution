using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccessLayer;
using MyEvernote.DataAccessLayer.Abstract;
using MyEvernote.Entities;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
   public  class Repository<T>:IRepository<T> where T:class //Tipini belirtmen lazım, new lenen bir nesne olmak zorunda 
    {
        //kontrollü bir biçimde nesne oluşturmak için singleton pattern kullandık .Burada birden fazla newleyerek veri eklemeye açlışırken sorun çıktı.
        //private DatabaseContext db=new DatabaseContext();  
        private DatabaseContext db;
        private DbSet<T> _objectSet;

        public Repository()
        {

          db=RepositoryBase.CreateContext();
            _objectSet = db.Set<T>();
        }
        public List<T> List()
        {

          return _objectSet.ToList();


        }
        public IQueryable<T> ListQueryable()
        {
             
            return _objectSet.AsQueryable<T>();


        }

        public List<T> List(Expression<Func<T,bool>> where)
        {


            return _objectSet.Where(where).ToList();

        }

        public int Insert(T obj)
        {


            _objectSet.Add(obj);// tipi bilmiyor isek Set metodu ile gelen nesne yi bul ve ekle.
            return Save();


        }

        public int Update(T obj)
        {

            return Save();


        }


        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();


        }
        public int Save()
        {

            return db.SaveChanges();

        }

        public T Find(Expression<Func<T,bool>> where )
        {

            return _objectSet.FirstOrDefault(where);


        }

    }
}
