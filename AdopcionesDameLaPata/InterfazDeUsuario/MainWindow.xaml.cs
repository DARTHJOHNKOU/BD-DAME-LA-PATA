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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Objeto de la clase Perro para llamar las funciones de registro y actualización de datos.
        ClassPerro Operaciones = new ClassPerro();

        public MainWindow()
        {
            InitializeComponent();

            BtnIrAAdministracionPerros.Click += (s, e) =>
            {
                //MessageBox.Show("El boton responde correctamente");

                WindowMenuPerro Ventana = new WindowMenuPerro();
                this.Close();
                Ventana.Show();

                //¿Se mandaron los datos a la BD con éxito?
                //if (Operaciones.RegistroPerro(txt.Text) == true)
                //{
                //    MessageBox.Show("Los datos fueron guardados correctamente");
                //}
                //else
                //    MessageBox.Show("Hubo un error. Verifique que los datos estén correctos.");

            };
        }
    }
}
