using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Comun.ViewModels
{
    public class RespuestaVMR<T>
    {
        //
        public HttpStatusCode codigo { get; set; }
        public T datos { get; set; }
        public List<string> mensage { get; set; }

        public RespuestaVMR()
        {
            codigo = HttpStatusCode.OK;
            datos = default(T);
            mensage = new List<string>();

        }

    }
}
