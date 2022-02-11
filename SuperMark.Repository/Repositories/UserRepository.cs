using SuperMark.Common.Model;
using SuperMark.Repository.DbContexts;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {


        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {

            _connectionString = connectionString;
        }
        public User Get(object parameters)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(string user, string password)
        {
            using (var context = new SupermakDbcontext(_connectionString))
            {
                var query = (from cause in context.Users
                             where cause.UserLogin == user  && cause.PassWord == password
                             select cause
                             );
                var result = query.FirstOrDefault();

                return result;
            }



        }

        public User Post(object parameters)
        {
            throw new NotImplementedException();
        }
    }
}
