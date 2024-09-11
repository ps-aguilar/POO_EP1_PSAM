using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_EP1_PSAM
{
    internal class Tienda
    {
    
        private List<Cliente> clientes = new List<Cliente>();
        private List<Producto> inventario = new List<Producto>()
            {
                new Producto(001, "Lienzo 40x60", "Lienzo de algodón montado en bastidor de madera, " +
                "ideal para pintura al óleo o acrílico.", 180.50F),
                new Producto(002, "Pinceles de Pelo Sintético", "Set de pinceles de alta calidad con " +
                "mangos ergonómicos y cerdas sintéticas, perfecto para detalles y trazos finos.", 120F),
                new Producto(003, "Caja de Acuarelas (Set de 24 colores)", "Set de acuarelas con 24 colores" +
                " vibrantes, incluye pincel de acuarela y bandeja para mezclar.", 250.40F),
                new Producto(004, "Papel de Acuarela 300g (Block de 20 hojas)", "Papel de textura gruesa" +
                " y alta absorción, ideal para técnicas de acuarela y gouache.", 200F),
                new Producto(005, "Cinta Adhesiva de Papel para Manualidades", "Cinta de enmascarar para " +
                "proteger áreas específicas durante trabajos de pintura o decoración.", 40.99F),
                new Producto(006, "Marcadores Permanentes (Set de 8 colores)", "Marcadores permanentes de " +
                "punta fina, resistentes al agua y de secado rápido.", 180.5F ),
                new Producto(007, "Caja de Pasteles Secos (Set de 36 colores)", "Pasteles secos de alta " +
                "calidad con colores intensos, perfectos para dibujos y técnicas de sombreado.", 320F),
                new Producto(008, "Tijeras para Manualidades", "Tijeras con punta fina y hoja de acero" +
                " inoxidable, diseñadas para cortar papel y cartulina con precisión.", 75.50F),
                new Producto(009, "Tabla de Corte 30x45 cm", "Tabla resistente para cortar papel y otros" +
                " materiales sin dañar las superficies, con mediciones en centímetros.", 220F),
                new Producto(010, "Pegamento en Barra 40g", "Pegamento en barra, ideal para papel, " +
                "cartulina y otros materiales ligeros. Secado rápido y sin residuos.", 25F),
            };

        public void registrarCliente(string nombre, string correo, string contrasena)
        {
            Cliente cliente = new Cliente(nombre, correo, contrasena);
            clientes.Add(cliente);
        }

        public int verificarContrasena(string correo, string contrasena)
        {
            if (clientes.Count == 0)
            {
                return -1; 
            }

            for (int i = 0; i < clientes.Count; i++)
            {

                if (clientes[i].CorreoElectronico == correo)
                {
                    if (clientes[i].Contrasena == contrasena)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0; 
                    }
                }
            }
            return -2;
        }

        public List<string> verCatalogo()
        {
            List<string> catalogo = new List<string>();
            for (int i = 0; i < inventario.Count; i++)
            {
                catalogo.Add($"{i + 1}. {inventario[i].NombreProducto} - ${inventario[i].Precio}");
            }
            return catalogo;
        }

        public Cliente obtenerCliente(string correo)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.CorreoElectronico == correo)
                {
                    return cliente;
                }
            }
            return null; 
        }
    }
}
