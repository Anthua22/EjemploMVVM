﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploMVVM.Model
{
    public partial class CLIENTE : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public partial class PEDIDO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}