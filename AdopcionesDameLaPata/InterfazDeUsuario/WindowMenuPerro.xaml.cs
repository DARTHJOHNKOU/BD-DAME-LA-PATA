/**********************************
*Asignación de programa: 06
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 29/11/18
* 
*Descripción: Clase que contiene la funcionalidad
* de la interfaz gráfica del menú de operaciones
* disponibles para los datos de los perros.
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
    public partial class WindowMenuPerro : Window
    {
        public WindowMenuPerro()
        {
            //Inicialización de los componentes de la UI
            InitializeComponent();

            //Botón para regresar al menú anterior.
            BtnRegresar.Click += (s, e) =>
            {
                MainWindow Ventana = new MainWindow();
                this.Close();
                Ventana.Show();
            };

            //Botón que lleva al menú de Registro de datos de un perro.
            BtnRegistrarPerro.Click += (s, e) =>
            {
                WindowRegistroPerro Ventana = new WindowRegistroPerro();
                this.Close();
                Ventana.Show();
            };

        }
    }
}
