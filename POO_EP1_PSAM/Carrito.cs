using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_EP1_PSAM
{
    internal class Carrito
    {
        private List<Producto> productos;
        private float total;
        private List<Producto> inventario;

        public Carrito()
        {
            productos = new List<Producto>();
            total = 0;
            inventario = new List<Producto>() //Mejorable, pues en la forma actual se crearia esta lista de inventario para cada carrito
                                              // de cada cliente
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
        }

        //PROPIEDADES

        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }

        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        //METODOS

        public bool agregarProductos(int idProducto, int Cantidad)
        {
            for (int i = 0;  i < inventario.Count; i++)
            {
                if (inventario[i].IdProducto == idProducto)
                {
                    for (int j = 0; j < Cantidad; j++)
                    {
                        productos.Add(inventario[i]);
                    }
                    return true;
                }
            }
            return false;
        }

        public List<string> verCarrito() //aun se puede cambiar para que se mencione solo el nombre del producto y la cantidad
        {
            List<string> carrito = new List<string>();

            if (productos.Count == 0)
            {
                carrito.Add("El carrito está vacío");
            }
            else
            {
                for (int i = 0; i < productos.Count; i++)
                {
                    carrito.Add(i + 1 + ". " + productos[i].NombreProducto + "$" + productos[i].Precio);
                    i++;
                }
            }
            return carrito;
        }
        public float calcularTotal()
        {
            float total = 0;

            if (productos.Count == 0)
            {
                return total;
            }
            else
            {
                for (int i = 0; i < productos.Count; i++)
                {
                    total = total + productos[i].Precio;
                }
            }
            return total;
        }
    }
}
