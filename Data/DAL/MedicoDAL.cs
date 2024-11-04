using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun.ViewModels;
using Model.Modelos;

namespace Data.DAL
{
    public class MedicoDAL
    {
        public static ListadoPaginadoVMR<MedicoVMR> GetAll(int cantidad, int pagina ,string textoBusqueda)
        {
            ListadoPaginadoVMR<MedicoVMR> resultado = new ListadoPaginadoVMR<MedicoVMR>();

            //Se declara Using para la conexion a la base de datos (Crea y Destruye las conexiones)
            using (var db = DbConexion.Create())
            {
                //Consuta para obtener el listado de medicos
                var consulta = db.Medico.Where(x => !x.borrado).Select(x => new MedicoVMR
                {
                    id = x.id,
                    cedula = x.cedula,
                    nombre = x.nombre + "" + x.apellidoPaterno + (x.apellidoMaterno != null ? (" " + x.apellidoMaterno) : ""),
                    esEspecialista = x.esEspecialista
                }) ;

                //Criterio de Busqueda
                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    //Elementos que coincidan con la busqueda
                    consulta = consulta.Where(x => x.cedula.Contains(textoBusqueda) || x.nombre.Contains(textoBusqueda));
                }

                //Devolver los resultados
                resultado.cantidadTotal = consulta.Count();

                resultado.elemento = consulta
                    .OrderBy(x => x.id)
                    .Skip(pagina * cantidad)
                    .Take(cantidad)
                    .ToList();
            }

                return resultado;
        }

        public static MedicoVMR GetOne(long id)
        {
            MedicoVMR item = null;

            using (var db = DbConexion.Create())
            {
                item = db.Medico.Where(x => !x.borrado && x.id == id).Select(x => new MedicoVMR {
                    id = x.id,
                    nombre = x.nombre,
                    apellidoPaterno = x.apellidoPaterno,
                    apellidoMaterno = x.apellidoMaterno,
                    habilitado = x.habilitado,
                    esEspecialista = x.esEspecialista
                }).FirstOrDefault();
            }

            return item;
        }

        public static long Create(Medico item)
        {

            using (var db = DbConexion.Create())
            {
                item.borrado = false;
                db.Medico.Add(item);
                db.SaveChanges();
            }

            return item.id;
        }

        public static void Update (MedicoVMR item)
        {
            using (var db = DbConexion.Create())
            {
                //Obtener el elemento de la base de datos
                var itemUpdate = db.Medico.Find(item.id);
                itemUpdate.cedula = item.cedula;
                itemUpdate.nombre = item.nombre;
                itemUpdate.apellidoPaterno = item.apellidoPaterno;
                itemUpdate.apellidoMaterno = item.apellidoMaterno;
                itemUpdate.habilitado = item.habilitado;
                itemUpdate.esEspecialista = item.esEspecialista;

                //Madera de definir en EntityFramework que un elemento que se recupero de la base de datos 
                //se modifico
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

        }

        public static void Delete(List<long> ids)
        {
            using (var db = DbConexion.Create())
            {
                var itemsDelete = db.Medico.Where(x => ids.Contains(x.id));

                foreach (var item in itemsDelete)
                {
                    item.borrado = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
            }
        }

    }
}
