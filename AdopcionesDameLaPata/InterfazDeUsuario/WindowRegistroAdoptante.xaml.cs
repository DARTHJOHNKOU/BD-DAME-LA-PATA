/**********************************
*Asignación de programa: 08
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 02/12/18 
* 
* Descripción: Clase que contiene la funcionalidad
* de la interfaz gráfica del registro de datos de
* un adoptante.
* 
* Modificado por:
* Cambios:
* Fecha de modificación:
* 
* Declaraciones:
*   °MainWindow Ventana
* 
**********************************/


using System;
using System.Collections.Generic;
using System.Data;
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
    
    public partial class WindowRegistroAdoptante : Window
    {

        // Clase para usar las funciones de registrar y actualizar información.
        ClassAdoptante Adoptante = new ClassAdoptante();

        // Clase para obtener los valores de la fila seleccionada en el DataGrid
        DataRowView row;

        // Variable para saber si el ingreso de datos es para actualizar datos o es el registro
        // de un adoptante nuevo           
        bool esActualizar = false;


        public WindowRegistroAdoptante()
        {
            //Inicialización de los componentes de la UI
            InitializeComponent();

            // Se visualizan los adoptantes.
            // Puede haber un problema de conexión a la base de datos durante la ejecución del programa.
            try
            {
                VerAdoptantes.ItemsSource = Adoptante.SelectAdoptantes().Tables[0].DefaultView;
            }
            catch
            {
                MessageBox.Show("Hubo un error al conectarse a la base de datos.");
                //MainWindow Ventana = new MainWindow();
                //this.Close();
                //Ventana.Show();
            }


            //Botón para regresar al menú anterior.
            BtnRegresar.Click += (s, e) =>
            {
                MainWindow Ventana = new MainWindow();
                this.Close();
                Ventana.Show();
            };

            //Boton para ingresar los datos a la BD
            BtnIngresar.Click += (s, e) =>
            {
                // Validaciones.
                    // Campos vacíos
                if (TxtNombre.Text=="" || TxtEdad.Text=="" || TxtTelefono.Text=="" )
                {
                    MessageBox.Show("Debe llenar todos los campos.");
                    goto CancelarOperacion;
                }

                    // Sólo números en la Edad
                if (int.TryParse(TxtEdad.Text, out int res) == false)
                {
                    MessageBox.Show("Debe ingresar un número en la edad.");
                    goto CancelarOperacion;
                }



            // En caso de que no se llenen correctamente los campos, 
            // se salta la operación de actualizar ó registrar
            CancelarOperacion:;

            };

        }
    }
}
