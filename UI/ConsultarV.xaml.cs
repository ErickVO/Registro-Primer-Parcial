using RegistroParcial1.BLL;
using RegistroParcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroParcial1.UI
{
    /// <summary>
    /// Interaction logic for ConsultarV.xaml
    /// </summary>
    public partial class ConsultarV : Window
    {
        public ConsultarV()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Articulos>();

            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex) {

                    case 0:

                        listado = ArticulosBll.GetList(a => true);

                    break;

                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);

                        listado = ArticulosBll.GetList(a => a.ProductoId == id);

                    break;

                    case 2:

                        listado = ArticulosBll.GetList(a => a.Descripcion.Contains(CriterioTextBox.Text));

                    break;
                }

            }
            else
            {
                listado = ArticulosBll.GetList(a => true);
            }

            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
