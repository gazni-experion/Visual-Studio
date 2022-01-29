using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Models;
using DatingApp.Repository;
using DatingApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly dating_appContext _db;

        public CustomerRepo(dating_appContext db)
        {
            _db = db;
        }

        //Get all customers
        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            if (_db!= null)
            {
                return await (from c in _db.Customers
                              from h in _db.Hobbies
                              from f in _db.Food
                              where c.HobbyId == h.HobbyId && c.FoodId == f.FoodId
                              select new CustomerViewModel
                              {
                                  Name = c.Name,
                                  Age = c.Age,
                                  Gender = c.Gender,
                                  Hobby = h.Hobby,
                                  FavouriteFood = f.FoodName
                              }
                    ).ToListAsync();
            }
            return null;
        }

        public async Task<CustomerViewModel> GetCustomer(int? id)
        {
            if (_db!=null)
            {
                return await (from c in _db.Customers
                              from h in _db.Hobbies
                              from f in _db.Food
                              where c.CustomerId == id
                              select new CustomerViewModel
                              {
                                  Name = c.Name,
                                  Age = c.Age,
                                  Gender = c.Gender,
                                  Hobby = h.Hobby,
                                  FavouriteFood = f.FoodName
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
    }
}
