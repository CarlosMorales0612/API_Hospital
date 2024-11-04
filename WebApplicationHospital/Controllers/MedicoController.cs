using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.Modelos;
using Comun.ViewModels;
using Logica.BLL;
using System.Web.Http.Cors;

namespace WebApplicationHospital.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MedicoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll(int cantida = 10, int pagina = 0, string textoBusqueda = null)
        {
            //Estandarizar las resouestas
            var respuesta = new RespuestaVMR<ListadoPaginadoVMR<MedicoVMR>>();
            try
            {
                respuesta.datos = MedicoBLL.GetAll(cantida, pagina, textoBusqueda);
            }
            catch (Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensage.Add(ex.Message);
                respuesta.mensage.Add(ex.ToString());
            }
            return Content(respuesta.codigo, respuesta);
        }

        [HttpGet]
        public IHttpActionResult GetOne(long id)
        {
            var respuesta = new RespuestaVMR<MedicoVMR>();

            try
            {
                respuesta.datos = MedicoBLL.GetOne(id);
            }
            catch (Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensage.Add(ex.Message);
                respuesta.mensage.Add(ex.ToString());
            }
            //Si no encuentra el elemento que se esta buscando
            if (respuesta.datos == null && respuesta.mensage.Count() == 0)
            {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensage.Add("Elemento no encontrado");
            }
            return Content(respuesta.codigo, respuesta);
        }

        [HttpPost]
        public IHttpActionResult Create(Medico item)
        {
            var respuesta = new RespuestaVMR<long?>();
            try
            {
                respuesta.datos = MedicoBLL.Create(item);
                respuesta.mensage.Add("El elemeto se creo Exitosamente");
            }
            catch (Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensage.Add("Ocurrió un error al crear el elemento");
                respuesta.mensage.Add(ex.Message);
                respuesta.mensage.Add(ex.ToString());
            }
            return Content(respuesta.codigo, respuesta);
        }

        [HttpPut]
        public IHttpActionResult Update(long id, MedicoVMR item)
        {
            var respuesta = new RespuestaVMR<bool>();
            try
            {
                item.id = id;
                MedicoBLL.Update(item);
                respuesta.datos = true;
            }
            catch (Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensage.Add(ex.Message);
                respuesta.mensage.Add(ex.ToString());
            }
            return Content(respuesta.codigo, respuesta);
        }
        [HttpDelete]
        public IHttpActionResult Delete(List<long> ids)
        {
            var respuesta = new RespuestaVMR<bool>();
            try
            {
                MedicoBLL.Delete(ids);
                respuesta.datos = true;
                respuesta.mensage.Add("Eliminación Exitosa");
            }
            catch (Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensage.Add("error al eliminar el elemento");
                respuesta.mensage.Add(ex.Message);
                respuesta.mensage.Add(ex.ToString());
            }
            return Content(respuesta.codigo, respuesta);
        }
    }
}
