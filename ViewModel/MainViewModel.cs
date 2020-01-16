using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EjemploMVVM.Model;
using EjemploMVVM.Service;

namespace EjemploMVVM.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            ListaPedidos = new CollectionViewSource
            {
                Source = BBDDService.GetPedidos()
            };
            ListaPedidos.Filter += ListaPedidos_Filter;
        }

        private void ListaPedidos_Filter(object sender, FilterEventArgs e)
        {
            PEDIDO pedidoActual = e.Item as PEDIDO;

            if (string.IsNullOrEmpty(ClienteFiltro))
                e.Accepted = true;
            else
            {
                if (pedidoActual.CLIENTE.nombre.Contains(ClienteFiltro) || pedidoActual.CLIENTE.apellido.Contains(ClienteFiltro))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }

        public CollectionViewSource ListaPedidos { get; set; }

        public PEDIDO PedidoSeleccionado { get; set; }

        public string ClienteFiltro { get; set; }

        public bool Open_CanExecute()
        {
            return (PedidoSeleccionado != null);
        }

        internal void Delete_Execute()
        {
            BBDDService.DeletePedido(PedidoSeleccionado);
        }

        public bool Delete_CanExecute()
        {
            return (PedidoSeleccionado != null);
        }

        internal void Find_Execute()
        {
            ListaPedidos.View.Refresh();
        }
    }
}
