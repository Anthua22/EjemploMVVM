using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploMVVM.Model;

namespace EjemploMVVM.Service
{
    public static class BBDDService
    {
        private static readonly EjemploMVVMContext _contexto;

        static BBDDService()
        {
            _contexto = new EjemploMVVMContext();
            _contexto.CLIENTES.Load();
            _contexto.PEDIDOS.Load();
        }

        public static ObservableCollection<CLIENTE> GetClientes()
        {
            return _contexto.CLIENTES.Local;
        }

        public static ObservableCollection<PEDIDO> GetPedidos()
        {
            return _contexto.PEDIDOS.Local;
        }

        public static int AddCliente(CLIENTE item)
        {
            _contexto.CLIENTES.Add(item);
            return _contexto.SaveChanges();
        }

        public static int AddPedido(PEDIDO item)
        {
            _contexto.PEDIDOS.Add(item);
            return _contexto.SaveChanges();
        }

        public static int DeleteCliente(CLIENTE item)
        {
            _contexto.CLIENTES.Remove(item);
            return _contexto.SaveChanges();
        }

        public static int DeletePedido(PEDIDO item)
        {
            _contexto.PEDIDOS.Remove(item);
            return _contexto.SaveChanges();
        }

        public static int ActualizarBBDD()
        {
            return _contexto.SaveChanges();
        }

    }
}
