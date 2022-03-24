using DataAccessLayer.Concrate.Repositories;
using EntitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
   public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();
        public List<Category> GetAllBL()
        {
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {
            if(p.CategoryName=="" || p.CategoryName.Length<=3 || p.CategoryDescription=="")
            {
               //hata mesajı
            }
            else
            {
                repo.Insert(p);
            }
        }
    }
}
