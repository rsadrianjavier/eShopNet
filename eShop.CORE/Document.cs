using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CORE
{
    /// <summary>
    /// Entidad de dominio de Documentos
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Identificador del documento
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del documento
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Producto al que pertenece el documento
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Identificador del producto al que pertenece
        /// </summary>
        public int Product_Id { get; set; }
    }
}
