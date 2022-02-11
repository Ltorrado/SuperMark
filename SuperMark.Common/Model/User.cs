using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Common.Model
{
    /// <summary>
    /// IDEUSU
    /// </summary>
   public  class User
    {
        /// <summary>
        /// USUREG
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// USUNOM - NOMBRE DEL USUARIO
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// USUPRO - ID DEL PERFIL
        /// </summary>

        public string Profile { get; set; }

        /// <summary>
        /// USUUSU - USUARIO LOGIN
        /// </summary>
        public string UserLogin { get; set; }
        /// <summary>
        /// USUPAS - CONTRASEÑA
        /// </summary>
        public string PassWord { get; set; }

    }
}
