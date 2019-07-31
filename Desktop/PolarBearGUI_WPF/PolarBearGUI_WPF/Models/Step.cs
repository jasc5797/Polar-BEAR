﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PolarBearGUI_WPF.Models
{
    public abstract class Step : Model
    {
        [Browsable(false)]
        public abstract string Type
        {
            get;
        }

        protected DateTime CreationTime;

        public Step()
        {
            CreationTime = DateTime.Now;
        }

        
    }
}
