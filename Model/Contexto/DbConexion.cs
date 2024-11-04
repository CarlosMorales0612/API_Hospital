using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model.Modelos
{
    public partial class DbConexion : DbContext
    {
        private DbConexion ( string stringConexion) 
            : base(stringConexion)
        {
            //evitar que los objetos anidados que estan dentro de otros objetos
            //automaticamente se carguen haciendo uso de las propiedades SET y GET
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            //Tiempo de espera en la respuesta
            this.Database.CommandTimeout = 900;
        }

        //Metodo para la creacion a la conexion 
        public static DbConexion Create()
        {
            return new DbConexion("name=DbConexion");
        }
    }
}
