/**********************************
*Asignación de programa: 09
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 02/12/18 
* 
* Descripción: Clase que contiene la funcionalidad
* de la interfaz gráfica del registro de datos de
* una adopción.
* 
* Modificado por:
* Cambios:
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
    
    public partial class WindowRegistroAdopcion : Window
    {
        public WindowRegistroAdopcion()
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

        }
    }
}
