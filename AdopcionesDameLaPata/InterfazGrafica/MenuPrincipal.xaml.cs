/**********************************
*Asignación de programa:
*Nombre:  
*Fecha: 
*Descripción:  
**********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterfazGrafica
{
    
    public partial class MenuPrincipal: Window
    {
        //Objeto de la clase Perro para llamar las funciones de registro y actualización de datos.
        //Perro operaciones = new Perro();

        public MenuPrincipal()
        {
            //Inicialización de los elementos de la interfaz gráfica
            InitializeComponent();

            btnIrAAdministracionPerros.Click += (s, e) =>
            {

                //¿Se mandaron los datos a la BD con éxito?
                //if (operaciones.RegistroPerro(txt.Text) == true)
                //{
                //    MessageBox.Show("Los datos fueron guardados correctamente");
                //}
                //else
                //    MessageBox.Show("Hubo un error. Verifique que los datos estén correctos.");

            };
        }
    }
}
