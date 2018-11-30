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
    /// Interaction logic for WindowRegistroPerro.xaml
    /// </summary>
    public partial class WindowRegistroPerro : Window
    {
        public WindowRegistroPerro()
        {
            InitializeComponent();

            BtnRegresar.Click += (s, e) =>
            {
                WindowMenuPerro Ventana = new WindowMenuPerro();
                this.Close();
                Ventana.Show();
            };
        }
    }
}
