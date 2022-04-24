using EntitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IAboutService
    {
        List<About> GetList();
        void AboutAdd(About about);
        Category GetbyID(int id);
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}
