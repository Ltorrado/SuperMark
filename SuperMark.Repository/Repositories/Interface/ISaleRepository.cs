using SuperMark.Common.Model;
using SuperMark.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.Repositories.Interface
{
  public  interface ISaleRepository:IRepository<Sale,object>
    {
        public List<TopSale> TopSales(bool top);
    }
}
