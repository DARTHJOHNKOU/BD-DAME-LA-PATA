/**********************************
*Asignación de programa: 07
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 02/12/18 
* 
* Descripción: Clase que contiene la funcionalidad
* de la interfaz gráfica del registro de datos de
* una visita.
* 
* Modificado por: Victoria Martinez Villagómez
* Cambios: Agregar metodo para enviar los datos a la BD 
* Fecha de modificación: 04/12/18 
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
    public partial class WindowRegistroVisita : Window
    {
        ClassVisita Visita = new ClassVisita();
        ClassAdoptante Adoptante = new ClassAdoptante();

        public WindowRegistroVisita()
        {
            //Inicialización de los componentes de la UI
            InitializeComponent();

            VerVisitas.ItemsSource = Visita.SelectVisitas().Tables[0].DefaultView;

            TxtNombre.ItemsSource = Adoptante.SelectAdoptantes().Tables[0].DefaultView;
            TxtNombre.DisplayMemberPath = "Nombre";
            TxtNombre.SelectedValuePath = "IdAdoptante";

            //Botón para regresar al menú anterior.
            BtnRegresar.Click += (s, e) =>
            {
                MainWindow Ventana = new MainWindow();
                this.Close();
                Ventana.Show();
            };

            //boton para ingresar los datso de la visita a la BD

            BtnIngresar.Click += (s, e) =>
            {
                string domicilio = TxtCiudad.Text;
                domicilio += TxtCalle.Text;
                string Observaciones = new TextRange(TxtObservaciones.Document.ContentStart, TxtObservaciones.Document.ContentEnd).Text;

                Visita.RegistroVisita(int.Parse(TxtNombre.SelectedValue.ToString()), domicilio, DateTime.Parse(TxtFechaVisita.Text), DateTime.Parse(TxtFechaProxima.Text), TxtVisitante.Text, Observaciones);
                MessageBox.Show("Registro de Visita exitosa");
                VerVisitas.ItemsSource = Visita.SelectVisitas().Tables[0].DefaultView;
            };
        }
    }
}
