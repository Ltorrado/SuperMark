using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Common.Model
{
    /// <summary>
    /// SMPPRO - tabla de productos
    /// </summary>
    public class Product
    {
        public Product(Product pro)
        {
            this.Code = pro.Code;
            this.Name = pro.Name;
            this.Id = pro.Id;
            this.Img = pro.Img;
            this.Price = pro.Price;
            this.Description = pro.Description;
            this.Quantity = pro.Quantity;


        }

        public Product()
        {

        }
        /// <summary>
        /// SMPREG 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// PRONOM - nombre del producto
        /// </summary>
        [Required]
        [StringLength(250, ErrorMessage = "Nombre no puede ser mayor a 10",MinimumLength =1)]
        public string Name { get; set; }
        /// <summary>
        /// PRODES - descripcion breve del producto
        /// </summary>
          [Required]
        [StringLength(250, ErrorMessage = "Nombre no puede ser mayor a 50", MinimumLength = 1)]
        public string Description { get; set; }
        /// <summary>
        /// PROPRE- valor del producto
        /// </summary>
        [Required]


        public decimal Price { get; set; }
        /// <summary>
        /// PROIMG ruta de la imagen
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// PROCOD- codigo de el producto
        /// </summary>
           [Required]
        [StringLength(250, ErrorMessage = "Codigo no puede ser mayor a 30", MinimumLength = 1)]
        public string Code { get; set; }

        [NotMapped]
        public int Quantity { get; set; } = 1;
 
    }
}
