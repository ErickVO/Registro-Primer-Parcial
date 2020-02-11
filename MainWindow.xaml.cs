using RegistroParcial1.BLL;
using RegistroParcial1.Entidades;
using RegistroParcial1.UI;
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

namespace RegistroParcial1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ValorTextBox.Text = "0";
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Articulos LlenaClase()
        {
            Articulos a = new Articulos();
            a.ProductoId = Convert.ToInt32(IdTextBox.Text);
            a.Descripcion = DescripcionTextBox.Text;
            a.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            a.Costo = Convert.ToInt32(CostoTextBox.Text);
            a.ValorInventario = Convert.ToInt32(ValorTextBox.Text);

            return a;
        }

        private void LlenaCampo(Articulos articulos)
        {
            IdTextBox.Text = Convert.ToString(articulos.ProductoId);
            DescripcionTextBox.Text = articulos.Descripcion;
            ExistenciaTextBox.Text = Convert.ToString(articulos.Existencia);
            CostoTextBox.Text = Convert.ToString(articulos.Costo);
            ValorTextBox.Text = Convert.ToString(articulos.ValorInventario);
        }

        private bool ExisteBaseDatos()
        {
            Articulos a = ArticulosBll.Buscar((int)Convert.ToInt32(IdTextBox.Text));

            return (a != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if(DescripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show("Introduzca una Descripcion","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                DescripcionTextBox.Focus();
                paso = false;
            }

            if(string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                MessageBox.Show("Este campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ExistenciaTextBox.Focus();
                paso = false;
            }

            if (CostoTextBox.Text == string.Empty)
            {
                MessageBox.Show("Este campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                CostoTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            Articulos articulos;

            articulos = LlenaClase();

            if (IdTextBox.Text == "0")
            {
                paso = ArticulosBll.Guardar(articulos);
            }
            else
            {
                if (!ExisteBaseDatos())
                {
                    MessageBox.Show("No existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ArticulosBll.Modificar(articulos);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se guardo","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);

            if (ArticulosBll.Eliminar(id))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);

            Articulos a = ArticulosBll.Buscar(id);

            if (a != null) 
            {
                Limpiar();
                MessageBox.Show("Encontrado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                LlenaCampo(a);
            }
            else
            {
                MessageBox.Show("No se encontro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Calcular()
        {
            int existencia;
            int costo;
            int resultado = 0;

            int.TryParse(ExistenciaTextBox.Text, out existencia);
            int.TryParse(CostoTextBox.Text, out costo);

            resultado = costo * existencia;

            ValorTextBox.Text = Convert.ToString(resultado);
        }


        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ConsultarV cv = new ConsultarV();
            cv.Show();
        }
    }
}
