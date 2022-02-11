using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Common.Model
{
    /// <summary>
    /// SMPVEN - VENTAS
    /// </summary>
  public   class Sale
    {
        /// <summary>
        /// VENREG
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// VENPRO - ID DEL PRODUCTO
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// VENUSU - ID DEL USUARIO
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// VENCAN - CANTIDAD COMPRADA
        /// </summary>
        public int Quantity { get; set; }


    }
}
