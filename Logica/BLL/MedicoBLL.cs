using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun.ViewModels;
using Model.Modelos;
using Data.DAL;

namespace Logica.BLL
{
    public class MedicoBLL
    {
        //Conexion a carta de presentacion
        public static ListadoPaginadoVMR<MedicoVMR> GetAll(int cantidad, int pagina, string textoBusqueda)
        {
            return MedicoDAL.GetAll(cantidad, pagina, textoBusqueda);
        }
        public static MedicoVMR GetOne(long id)
        {
            return MedicoDAL.GetOne(id);
        }
        public static long Create(Medico item)
        {
            return MedicoDAL.Create(item);
        }
        public static void Update(MedicoVMR item)
        {
            MedicoDAL.Update(item);
        }
        public static void Delete(List<long> ids)
        {
            MedicoDAL.Delete(ids);
        }
    }
}
