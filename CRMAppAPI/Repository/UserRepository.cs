using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMAppAPI.Models;
using CRMAppAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CRMAppAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CRMAppAPIContext _context;

        //Constructor
        public UserRepository(CRMAppAPIContext context)
        {
            _context = context;
        }

        //Add user
        public async Task<int> AddUser(Users users)
        {
            if (_context!=null)
            {
                await _context.AddAsync(users);
                await _context.SaveChangesAsync();
                return users.UserId;
            }
            return 0;
        }


        //get users list
        public async Task<List<Users>> GetUsers()
        {
            if (_context!=null)
            {
                return await _context.Users.Include(r => r.Role).ToListAsync();
            }
            return null;
        }

        //update user
        public async Task UpdateUser(Users users)
        {
            if (_context!=null)
            {
                _context.Entry(users).State = EntityState.Modified;
                _context.Users.Update(users);
                await _context.SaveChangesAsync();
            }
        }

        #region view Model
        //Get all users
        public async Task<List<UsersViewModel>> GetAllUsers()
        {
            if (_context!=null)
            {
                return await (from u in _context.Users
                              from r in _context.Roles
                              where u.RoleId == r.RoleId
                              select new UsersViewModel {
                              UserName = u.UserName,
                              UserPassword = u.UserPassword,
                              Contact = u.UserContact,
                              UserEmail = u.UserEmail,
                              RoleName = r.RoleName
                              }).ToListAsync();
            }
            return null;
        }

        //Get user by Id
        public async Task<UsersViewModel> GetUser(int? userId)
        {
            if (_context!=null)
            {
                return await (from u in _context.Users
                              from r in _context.Roles
                              where u.UserId == userId
                              select new UsersViewModel
                              {
                                  UserName = u.UserName,
                                  UserPassword = u.UserPassword,
                                  Contact = u.UserContact,
                                  UserEmail = u.UserEmail,
                                  RoleName = r.RoleName
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        //Get user by entering username and password
        public async Task<UsersViewModel> UserLogin(string username, string password)
        {
            if (_context!=null)
            {
                return await (from u in _context.Users
                              from r in _context.Roles
                              where u.UserName == username && u.UserPassword == password 
                              select new UsersViewModel
                              {
                                  UserName = u.UserName,
                                  UserPassword = u.UserPassword,
                                  Contact = u.UserContact,
                                  UserEmail = u.UserEmail,
                                  RoleName = r.RoleName
                              }).FirstOrDefaultAsync();
                    
            }
            return null;
        }

        //Get user by contact
        public async Task<UsersViewModel> UserContact(string contact)
        {
            if (_context!=null)
            {
                return await (from u in _context.Users
                              from r in _context.Roles
                              where u.UserContact == contact
                              select new UsersViewModel
                              {
                                  UserName = u.UserName,
                                  UserPassword = u.UserPassword,
                                  Contact = u.UserContact,
                                  UserEmail = u.UserEmail,
                                  RoleName = r.RoleName
                              }).FirstOrDefaultAsync();

            }
            return null;
        }
        #endregion
    }
}
