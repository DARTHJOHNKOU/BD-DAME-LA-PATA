/**********************************
*Asignación de programa: 07
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 29/11/18 
* 
* Descripción: Clase que contiene la funcionalidad
* de la interfaz gráfica del registro de datos de
* un perro
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
        public WindowRegistroPerro()
        {
            //Inicialización de los componentes de la UI
            InitializeComponent();

            //Botón para regresar al menú anterior.
            BtnRegresar.Click += (s, e) =>
            {
                WindowMenuPerro Ventana = new WindowMenuPerro();
                this.Close();
                Ventana.Show();
            };
        }
    }
}
