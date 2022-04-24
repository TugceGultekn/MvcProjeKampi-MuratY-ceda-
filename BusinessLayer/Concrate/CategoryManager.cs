using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate.Repositories;
using EntitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetbyID(int id)  //silme için id tanımladık
        {
            return _categorydal.Get(x => x.CategoryID==id); // id değeri ile categoryID eşit mi diye kontrol ettirdik.
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }

    }
}
