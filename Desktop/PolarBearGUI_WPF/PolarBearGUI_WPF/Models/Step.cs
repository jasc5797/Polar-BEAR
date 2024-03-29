﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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
