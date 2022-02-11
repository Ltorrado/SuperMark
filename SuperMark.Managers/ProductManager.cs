using SuperMark.Common.Model;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Managers
{
    public class ProductManager
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Metodo para obtener todas los productos
        /// </summary>
        public async Task<List<Product>> GetAll()
        {


            return await Task.Run(() =>
            {
                return _repository.GetAll();
            });
        }

        /// <summary>
        /// obtener productos por id
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Product> Get(object parameters)
        {
            return await Task.Run(() =>
            {
                return _repository.Get(parameters);
            });
        }


        /// <summary>
        /// Agregar producto
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public async Task<Product> Post(Product Product)
        {
            return await Task.Run(() =>
            {
                return _repository.Post(Product);
            });
        }


        /// <summary>
        /// elimina producto
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {
            return await Task.Run(() =>
            {
                return _repository.Delete(id);
            });
        }


        /// <summary>
        /// elimina producto
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public async Task<int> Put(Product Product)
        {
            return await Task.Run(() =>
            {
                return _repository.Put(Product);
            });
        }

    }
}
