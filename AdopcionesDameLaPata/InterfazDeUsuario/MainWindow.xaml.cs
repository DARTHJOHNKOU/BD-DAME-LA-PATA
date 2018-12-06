/**********************************
*Asignación de programa: 05
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 29/11/18
* 
*Descripción: Clase que contiene la funcionalidad
* de la interfaz gráfica del menú principal.
* 
* 
* Modificado por:
* Cambios:
* Fecha de modificación:
* 
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterfazDeUsuario
{    
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            //Inicialización de los componentes de la UI
            InitializeComponent();

            //Botón que manda al menú de Administración de datos de perros
            BtnIrAAdministracionPerros.Click += (s, e) =>
            {
                WindowRegistroPerro Ventana = new WindowRegistroPerro();
                this.Close();
                Ventana.Show();
            };

            //Botón que manda al menú de Administración de visitas domiciliarias
            BtnIrAAdministracionVisitas.Click += (s, e) =>
            {
                WindowRegistroVisita Ventana = new WindowRegistroVisita();
                this.Close();
                Ventana.Show();
            };

            //Botón que manda al menú de Administración de adoptantes domiciliarias
            BtnIrAAdministracionAdoptantes.Click += (s, e) =>
            {
                WindowRegistroAdoptante Ventana = new WindowRegistroAdoptante();
                this.Close();
                Ventana.Show();
            };

            //Botón que manda al menú de Administración de adopciones domiciliarias
            BtnIrAAdministracionAdopciones.Click += (s, e) =>
            {
                WindowRegistroAdopcion  Ventana = new WindowRegistroAdopcion();
                this.Close();
                Ventana.Show();
            };
        }
    }
}
