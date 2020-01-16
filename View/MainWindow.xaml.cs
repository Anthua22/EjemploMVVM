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
using EjemploMVVM.View;

namespace EjemploMVVM
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new ViewModel.MainViewModel();
            InitializeComponent();
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                (this.DataContext as ViewModel.MainViewModel).Delete_Execute();
                MessageBox.Show("Se ha eliminado el pedido", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error:" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void DeleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (this.DataContext as ViewModel.MainViewModel).Delete_CanExecute();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PedidoView nuevo = new View.PedidoView(Accion.Abrir);
            nuevo.Owner = this;
            nuevo.Show();
        }

        private void FindCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (this.DataContext as ViewModel.MainViewModel).Find_Execute();
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PedidoView nuevo = new View.PedidoView(Accion.Editar, PedidosDataGrid.SelectedItem);
            nuevo.Owner = this;
            nuevo.Show();
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (this.DataContext as ViewModel.MainViewModel).Open_CanExecute();
        }

    }
}
