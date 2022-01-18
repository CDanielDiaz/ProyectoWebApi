using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Recibo
    {
        public int idrecibo { get; set; }
        public int idusuario { get; set; }
        public string proveedor { get; set; }
        public string monto { get; set; }
        public string moneda { get; set; }
        public string fecha { get; set; }
        public string comentario { get; set; }
       
    }
}