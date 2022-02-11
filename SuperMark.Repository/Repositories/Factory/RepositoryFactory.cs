using SuperMark.Common.Enum;
using SuperMark.Common.Model;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.Repositories.Factory
{
    public class RepositoryFactory<T, K> : IRepository<T, K>
    {
        public IRepository<T,K> Repository { get; set; }
        public T Get(K parameters)
        {
            return Repository.Get(parameters);
        }

        public List<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T Post(K parameters)
        {
         return   Repository.Post(parameters);
        }

        /// <summary>
        /// Tipo de repositorio
        /// </summary>
        /// <param name="repositoryName"></param>
        /// <param name="provider"></param>
        /// <param name="ConnectionString"></param>
        public void GetRepository(RepositoryType repositoryName,  string ConnectionString)
        {

            switch (repositoryName)
            {

                case RepositoryType.Product:
                    Repository = new ProductRepository(ConnectionString)  ;
                    break;
                case RepositoryType.Sale:
                    Repository = new SaleRepository(ConnectionString) as IRepository<T, K>;

                    break;
                default:
                    break;
            }
        }
    }
}
