using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.ViewModels;

namespace DatingApp.Repository
{
    public interface ICustomerRepo
    {
        //Get list of all customers
        Task<List<CustomerViewModel>> GetAllCustomers();

        //Get a customer by id
        Task<CustomerViewModel> GetCustomer(int? id);
    }
}
