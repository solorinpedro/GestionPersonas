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
    /// Interaction logic for rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        private Aportes aportes = new Aportes();
        public rAportes()
        {
            InitializeComponent();
            this.DataContext = aportes;

            PersonaComboBox.ItemsSource = PersonasBLL.GetPersonas();
            PersonaComboBox.SelectedValuePath = "PersonaId";
            PersonaComboBox.DisplayMemberPath = "Nombres";

            TipoAporteComboBox.ItemsSource = TiposAportesBLL.GetTiposAportes();
            TipoAporteComboBox.SelectedValuePath = "TipoAporteId";
            TipoAporteComboBox.DisplayMemberPath = "Descripcion";

            Limpiar();
            ValorTextBox.Text = "0.00";
            MontoTextBox.Text = "0.00";
        }
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = aportes;
        }

        private void Limpiar()
        {
            this.aportes = new Aportes();
            this.DataContext = aportes;
        }
        private bool Existe()
        {
            Aportes esValido = AportesBLL.Buscar(aportes.AporteId);

            return (esValido != null);
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Aportes encontrado = AportesBLL.Buscar(aportes.AporteId);
            if (encontrado != null)
            {
                aportes = encontrado;
                Actualizar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            aportes.AporteDetalle.Add(new AportesDetalle((int)TipoAporteComboBox.SelectedValue,
              float.Parse(ValorTextBox.Text), (Personas)PersonaComboBox.SelectedItem,
              (TiposAportes)TipoAporteComboBox.SelectedItem));
            aportes.Monto += float.Parse(ValorTextBox.Text);
            Actualizar();
            ValorTextBox.Focus();
            ValorTextBox.Clear();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                aportes.Monto -= float.Parse(MontoTextBox.Text);
                Actualizar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (aportes.AporteId == 0)
            {
                paso = AportesBLL.Guardar(aportes);
            }
            else
            {
                if (Existe())
                {
                    paso = AportesBLL.Guardar(aportes);
                }
                else
                {
                    MessageBox.Show("No se ha encontrado en la base de datos", "ERROR");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Aportes existe = AportesBLL.Buscar(aportes.AporteId);

            if (existe == null)
            {
                MessageBox.Show("El grupo no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                AportesBLL.Eliminar(aportes.AporteId);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
    }
}
