﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
 public  class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetbyID(int id)
        {
            return _adminDal.Get(x => x.AdminID==id); // id değeri ile categoryID eşit mi diye kontrol ettirdik.

        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        Category IAdminService.GetbyID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
