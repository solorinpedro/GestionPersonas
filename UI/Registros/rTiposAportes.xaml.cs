using GestionPersonas.BLL;
using GestionPersonas.Entidades;
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

namespace GestionPersonas.UI.Registros
{
    /// <summary>
    /// Interaction logic for rTiposAportes.xaml
    /// </summary>
    public partial class rTiposAportes : Window
    {
        private TiposAportes TiposAportes = new TiposAportes();
        public rTiposAportes()
        {
            InitializeComponent();
            this.DataContext = TiposAportes;
        }
        private void Limpiar()
        {
            this.TiposAportes = new TiposAportes();
            this.DataContext = TiposAportes;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0 || MetaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("No puede haber campos vacios", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var tipoAporte = TiposAportesBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (tipoAporte != null)
                this.TiposAportes = tipoAporte;
            else
                this.TiposAportes = new TiposAportes();

            this.DataContext = this.TiposAportes;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = TiposAportesBLL.Guardar(TiposAportes);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("¡Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (TiposAportesBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
