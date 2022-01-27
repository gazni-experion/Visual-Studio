using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMAppAPI.Models;
using CRMAppAPI.ViewModel;

namespace CRMAppAPI.Repository
{
    public interface IUserRepository
    {
        //Get users list
        Task<List<Users>> GetUsers();

        //Add a user
        Task<int> AddUser(Users users);

        //Update a user
        Task UpdateUser(Users users);

        #region View Model

        //Get all users
        Task<List<UsersViewModel>> GetAllUsers();

        //Get a user by id
        Task<UsersViewModel> GetUser(int? userId);

        //Get user by username and password
        Task<UsersViewModel> UserLogin(string username,string password);

        //Get user by contact
        Task<UsersViewModel> UserContact(string contact);
        #endregion
    }
}
