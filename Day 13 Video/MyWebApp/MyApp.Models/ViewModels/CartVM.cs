﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public class CartVM
    {

        public IEnumerable<Cart> ListOfCart { get; set; }
        public double Total { get; set; }

    }
}
