using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ReciboController : ApiController
    {
        // GET api/<controller>
        //public List<Recibo> Get()
        //{
        //    return ReciboData.Listar();
        //}

        public List<Recibo> GetList(int id)
        {
            return ReciboData.ListarId(id);
        }

        //// GET api/<controller>/5
        //public Recibo Get(int id)
        //{
        //    return ReciboData.Obtener(id);
        //}

        // POST api/<controller>
        public string Post([FromBody] Recibo recibo)
        {
            return ReciboData.Registrar(recibo);
        }

        public bool Delete(int id)
        {
            return ReciboData.Eliminar(id);
        }

        // PUT api/<controller>/
        public bool Put([FromBody]Recibo recibo)
        {
            return ReciboData.Modificar(recibo);
       }

    }
}