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
    /// <summary>
    /// Interaction logic for WindowMenuVisita.xaml
    /// </summary>
    public partial class WindowMenuVisita : Window
    {
        public WindowMenuVisita()
        {
            InitializeComponent();

            //Botón para regresar al menú anterior.
            BtnRegresar.Click += (s, e) =>
            {
                MainWindow Ventana = new MainWindow();
                this.Close();
                Ventana.Show();
            };

            BtnRegistrarVisita.Click += (s, e) =>
            {
                WindowRegistroVisita Ventana = new WindowRegistroVisita();
                this.Close();
                Ventana.Show();
            };


         }
    }
}
