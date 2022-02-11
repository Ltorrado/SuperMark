using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.Repositories.Interface
{
  public  interface IRepository<T, K>
    {
        T Get(K parameters);
        T Post(K parameters);

        List<T> GetAll();

    }
}
