using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class ListadoPaginadoVMR<T>
    {
        public int cantidadTotal { get; set;  }
         //contiene la cantidad de todos los elementos
        public IEnumerable<T> elemento { get; set; }
        //Inicializar con el Contructor
        public ListadoPaginadoVMR()
        {
            elemento = new List<T>();
            cantidadTotal = 0;
        }
    }
    
}
