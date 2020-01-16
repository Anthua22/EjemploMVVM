using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploMVVM.Model;
using EjemploMVVM.Service;

namespace EjemploMVVM.ViewModel
{
    class PedidoViewModel : INotifyPropertyChanged
    {
        private readonly Accion _accion;

        public PedidoViewModel(Accion accion, Object pedido = null)
        {
            _accion = accion;
            ListaClientes = BBDDService.GetClientes();
            if (_accion == Accion.Abrir)
                Pedido = new PEDIDO();
            else
                Pedido = (PEDIDO)pedido;
        }

        public ObservableCollection<CLIENTE> ListaClientes { get; set; }

        public CLIENTE ClienteSeleccionado { get; set; }

        public PEDIDO Pedido { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Save_Execute()
        {
            //Aquí se pueden validar los datos antes de solicitar la acción al serviciod e BBDD

            if (_accion == Accion.Abrir)
                BBDDService.AddPedido(Pedido);
            else
                BBDDService.ActualizarBBDD();
        }
    }
}
