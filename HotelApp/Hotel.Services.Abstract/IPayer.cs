﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services.Abstract
{
    public interface IPayer
    {
        void Pay(string name, string price);
    }
}
