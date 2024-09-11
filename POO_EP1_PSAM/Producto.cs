using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace POO_EP1_PSAM
{
    internal class Producto
    {
        private int idProducto;
        private string nombreProducto;
        private string descripcion;
        private float precio;

        public Producto(int idProducto, string nombreProducto, string descripcion, float precio)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.descripcion = descripcion;
            this.precio = precio;
        }


        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }
    }
}
