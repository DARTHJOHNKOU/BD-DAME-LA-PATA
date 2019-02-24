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

        public WindowRegistroPerro()
        {            
            //Inicialización de los componentes de la UI
            InitializeComponent();

            // visualizar perros
            VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;

            VerPerros.IsReadOnly = true;
            VerPerros.IsEnabled = false;

            // variable para guarfar el valor de si fue esterilizado o no el perro.
            string Esterilizado;

            // se verifica cual radiobutton esta seleccionado para indicar si el perro esta esterilizado o no

            btnActualizar.Checked += (s, e) =>
            {
                VerPerros.IsEnabled = true;
            };

            btnActualizar.Unchecked += (s, e) =>
            {
                VerPerros.IsEnabled = false;
            };

            VerPerros.SelectionChanged += (s, e) =>
            {
                try
                {
                    DataRowView row = (DataRowView)VerPerros.SelectedItems[0];
                
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

            // boton para insertar los datos en la BD
            BtnIngresar.Click += (s, e) =>
            {
                string Adoptado = "No";

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

                Perro.RegistroPerro(TxtNombre.Text, DateTime.Parse(TxtFechaIngreso.Text), int.Parse(TxtEdad.Text), TxtRaza.Text, TxtTamano.Text, Esterilizado, Adoptado);
                MessageBox.Show("Perro guardado con exito");
                VerPerros.ItemsSource = Perro.SelectPerros().Tables[0].DefaultView;
            };
        }
    }
}
