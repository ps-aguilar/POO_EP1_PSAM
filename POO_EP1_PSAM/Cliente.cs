using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace POO_EP1_PSAM
{
    internal class Cliente
    {
        private string nombre;
        private string correoElectronico;
        private string contrasena;
        private Carrito carrito;

        public Cliente(string nombre, string correoElectronico, string contrasena)
        {
            this.nombre = nombre;
            this.correoElectronico = correoElectronico;
            this.contrasena = contrasena;
            this.carrito = new Carrito();
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public Carrito Carrito
        {
            get { return carrito; }
            set { carrito = value; }
        }
    }
}
