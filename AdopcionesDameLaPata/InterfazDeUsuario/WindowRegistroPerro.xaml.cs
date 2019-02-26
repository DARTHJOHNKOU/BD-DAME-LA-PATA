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
        ClassPerro Perro = new ClassPerro();
        DataRowView row;
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

            VerPerros.IsReadOnly = true;
            VerPerros.IsEnabled = false;
            
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

            VerPerros.SelectionChanged += (s, e) =>
            {
                try
                {
                    row = (DataRowView)VerPerros.SelectedItems[0];
                
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
                // variable para guarfar el valor de si fue esterilizado o no el perro.
                string Esterilizado;

                string Genero ="";
                string Adoptado = "No";

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

                if (RbNo.IsChecked == true)
                {
                    Esterilizado = "No";
                }
                else
                {
                    Esterilizado = "Si";
                }

                if (!esActualizar)
                {
                    Perro.RegistroPerro(TxtNombre.Text, Genero, DateTime.Parse(TxtFechaIngreso.Text), int.Parse(TxtEdad.Text), TxtRaza.Text, TxtTamano.Text, Esterilizado, Adoptado);
                    MessageBox.Show("Perro guardado con exito");                    
                }
                else
                {
                    int Id = int.Parse(row["IdPerro"].ToString());

                    Perro.UpdatePerro(Id, TxtNombre.Text, Genero, DateTime.Parse(TxtFechaIngreso.Text), int.Parse(TxtEdad.Text), TxtRaza.Text, TxtTamano.Text, Esterilizado, Adoptado);
                    MessageBox.Show("Datos actualizados con exito");
                    //VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;
                }

                VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;
            };
        }
    }
}
