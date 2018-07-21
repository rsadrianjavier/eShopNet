using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CORE
{
    /// <summary>
    /// Entidad de dominio de dirección
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Identificador de la dirección
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Teléfono de contacto de la dirección
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Pais
        /// </summary>        
        public string Country { get; set; }
        /// <summary>
        /// Provincia
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// Localidad
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Calle
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Más datos de la calle, número, portal, etc
        /// </summary>
        public string Street2 { get; set; }
    }
}
