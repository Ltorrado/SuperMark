using SuperMark.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.Repositories.Interface
{
    public interface  IUserRepository : IRepository<User, object>
    {
   
        public User Login(string user,string password);

    }
}
