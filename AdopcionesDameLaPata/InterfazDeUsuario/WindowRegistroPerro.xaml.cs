/**********************************
*Asignación de programa: 06
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 29/11/18 
* 
* Descripción: Clase que contiene la funcionalidad
* de la interfaz gráfica del registro de datos de
* un perro.
* 
* Modificado por: Victoria Martínez Villagomez 
* Cambios:
* Agregar la función del boton BtnIngresar para poder 
* hacer el envio de datos  la BD 
* 
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
using System.Windows.Shapes;

namespace InterfazDeUsuario
{
    
    public partial class WindowRegistroPerro : Window
    {
        ClassPerro Perro = new ClassPerro();

        public WindowRegistroPerro()
        {
            //Inicialización de los componentes de la UI
            InitializeComponent();

            // visualizar perros
            VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;

            // variable para 
            string Esterilizado;

            // se verifica cual radiobutton esta seleccionado para indicar si el perro esta esterilizado o no
            if (rbSi.IsChecked == true)
            {
                Esterilizado = "Si";
            }
            else
            {
                Esterilizado = "No";
            }

            if (rbNo.IsChecked == true)
            {
                Esterilizado = "No";
            }
            else
            {
                Esterilizado = "Si";
            }


            //Botón para regresar al menú anterior.
            BtnRegresar.Click += (s, e) =>
            {
                MainWindow Ventana = new MainWindow();
                this.Close();
                Ventana.Show();
            };

            // boton para insertar los datos en la BD
            BtnIngresar.Click += (s, e) =>
            {
                string Adoptado = "No";

                Perro.RegistroPerro(TxtNombre.Text, DateTime.Parse(TxtFechaIngreso.Text), int.Parse(TxtEdad.Text), TxtRaza.Text, TxtTamano.Text, Esterilizado, Adoptado);
                MessageBox.Show("Perro guardado con exito");
                VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;
            };
        }
    }
}
