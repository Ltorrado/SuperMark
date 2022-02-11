using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Common.Model
{
    /// <summary>
    /// IDEPRO- tabla de perfiles
    /// </summary>
   public  class Profile
    {
        /// <summary>
        /// PROREG- codigo del perfil
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// PRODES - descripcion del perfil
        /// </summary>
        public string Description { get; set; }
        

    }
}
