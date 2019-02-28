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
* Fecha de modificación: 
* 
* Declaraciones:
*   °MainWindow Ventana
*   °ClassPerro Perro
*   °string Esterilizado
*   °string Adoptado
* 
* Código fuente de ClassPerro en: /InterfazDeUsuario/ClassPerro.cs
*   
*   ° bool RegistroPerro(string Nombre, DateTime FechaIngreso, int Edad, string Raza, string Tamaño, string Esterilizado, string Adoptado)
*       Propósito: ingresar los datos que recibe como parámetros a la base de datos.
*       Limitaciones: en la Edad no se debe ingresar letras o símbolos.
*                     Nombre no debe exceder los 30 caracteres.
*       Regresa True si se completó con éxito el guardado de datos en la BD. Caso contrario, retorna False. 
*   
*   ° DataSet SelectPerros()
*       Propósito: Obtener un conjunto de datos recuperados de la base de datos.
*       Limitaciones:
*       Regresa un conjunto de datos si la recuperación se logró. Caso contrario, regresa un conjunto vacío.
* 
**********************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
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
        // Clase para usar las funciones de registrar y actualizar información.
        ClassPerro Perro = new ClassPerro();

        // Clase para obtener los valores de la fila seleccionada en el DataGrid
        DataRowView row;

        // Variable para saber si el ingreso de datos es para actualizar datos o es el registro
        // de un perro nuevo           
        bool esActualizar = false;        

        public WindowRegistroPerro()
        {            
            //Inicialización de los componentes de la UI
            InitializeComponent();

            // Se visualizan los perros.
            // Puede haber un problema de conexión a la base de datos durante la ejecución del programa.
            try
            {
                VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;
            }
            catch
            {
                MessageBox.Show("Hubo un error al conectarse a la base de datos.");
                //MainWindow Ventana = new MainWindow();
                //this.Close();
                //Ventana.Show();
            }            

            // Se inicializa como deshabilitado y sólo lectura el DataGrid
            VerPerros.IsReadOnly = true;
            VerPerros.IsEnabled = false;
            
            // Botón para indicar si los datos serán actualizados o no.
            btnActualizar.Checked += (s, e) =>
            {
                VerPerros.IsEnabled = true;
                esActualizar = true;
            };

            btnActualizar.Unchecked += (s, e) =>
            {
                VerPerros.IsEnabled = false;
                esActualizar = false;
            };

            // Evento que captura el momento en que se selecciona una fila
            // del GridView.
            VerPerros.SelectionChanged += (s, e) =>
            {
                // Es posible que haya una deselección y esto puede provocar un error 
                // en tiempo de ejecución.
                try
                {
                    // Se guardan en un arreglo los datos de la fila seleccionada. 
                    row = (DataRowView)VerPerros.SelectedItems[0];
                
                    // Se llenan los campos con sus datos correspondientes del perro seleccionado.
                    TxtNombre.Text = row["Nombre"].ToString();
                    TxtEdad.Text = row["Edad"].ToString();
                    TxtRaza.Text = row["Raza"].ToString();
                    TxtTamano.Text = row["Tamaño"].ToString();
                    TxtFechaIngreso.Text = row["FechaIngreso"].ToString();

                    if (row["Esterilizado"].ToString() == "Si")
                        RbSi.IsChecked = true;
                    else
                        RbNo.IsChecked = true;

                }
                catch { }

            };

            //Botón para regresar al menú anterior.
            BtnRegresar.Click += (s, e) =>
            {
                
                MainWindow Ventana = new MainWindow();
                this.Close();
                Ventana.Show();
            };

            // Botón para borrar los datos ingresados
            BtnCancelar.Click += (s, e) =>
            {
                TxtNombre.Text = "";
                TxtEdad.Text = "";
                TxtFechaIngreso.Text = "";
                RbNo.IsChecked = true;
                TxtRaza.Text = "";
                TxtTamano.Text = "";
                btnActualizar.IsChecked = false;
                esActualizar = false;
            };

            // boton para insertar los datos en la BD
            BtnIngresar.Click += (s, e) =>
            {
                // variable para guardar el valor de si fue esterilizado o no el perro.
                string Esterilizado;

                // Variable para guardar el género del perro.
                string Genero = "";

                // Variable para asignar que el perro no está adoptado. 
                // Se puede eliminar esta variable y pasar directamente el valor a la función.
                string Adoptado = "No";

                // Validaciones.
                    // Campos vacíos
                if (TxtNombre.Text == "" || TxtRaza.Text == "" || TxtTamano.Text == ""
                    || TxtFechaIngreso.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los campos.");
                    goto CancelarOperacion;
                }

                    // Sólo números en la Edad
                if(int.TryParse(TxtEdad.Text, out int res) == false )
                {
                    MessageBox.Show("Debe ingresar un número en la edad.");
                    goto CancelarOperacion;
                }

                if (RbMacho.IsChecked == true)
                    Genero = "Macho";
                else
                    Genero = "Hembra";


                if (RbSi.IsChecked == true)
                {
                    Esterilizado = "Si";
                }
                else
                {
                    Esterilizado = "No";
                }                

                if (!esActualizar)
                {
                    if (Perro.EsPerroRepetido(TxtNombre.Text).Tables[0].Rows.Count <= 0)
                    {
                        Perro.RegistroPerro(TxtNombre.Text, Genero, DateTime.Parse(TxtFechaIngreso.Text), int.Parse(TxtEdad.Text), TxtRaza.Text, TxtTamano.Text, Esterilizado, Adoptado);
                        MessageBox.Show("Perro guardado con exito");
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un perrito con ese nombre.");
                    }
                }
                else
                {
                    // Se obtiene el ID del perro seleccionado en el DataGrid
                    int Id = int.Parse(row["IdPerro"].ToString());

                    Perro.UpdatePerro(Id, TxtNombre.Text, Genero, DateTime.Parse(TxtFechaIngreso.Text), int.Parse(TxtEdad.Text), TxtRaza.Text, TxtTamano.Text, Esterilizado, Adoptado);
                    MessageBox.Show("Datos actualizados con exito");
                    //VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;
                }

                VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;

                // En caso de que no se llenen correctamente los campos, 
                // se salta la operación de actualizar ó registrar
            CancelarOperacion:;
                
            };
        }
    }
}
