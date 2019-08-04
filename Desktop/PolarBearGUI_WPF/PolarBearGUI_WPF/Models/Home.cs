using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.Models
{
    public class Home : Step
    {
        public override string Type
        {
            get
            {
                return "Home";
            }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ComponentType { Tilt, Rotation, Extension }
        
        private ComponentType component;

        [Description("Component to Home")]
        public ComponentType Component
        {
            get
            {
                return component;
            }
            set
            {
                component = value;
                NotifyPropertyChanged("Component");
            }
        }

        public Home(ComponentType component) : base()
        {
            Component = component;
        }

        public override bool Equals(Model model)
        {
            if (model is Home)
            {
                Home home = model as Home;
                return Type == home.Type &&
                    CreationTime == home.CreationTime &&
                    Component == home.Component;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashTime = CreationTime == null ? 0 : CreationTime.GetHashCode();
            int hashType = Type == null ? 0 : Type.GetHashCode();
            int hashComponent =  Component.GetHashCode();
            return hashTime ^ hashType ^ hashComponent;
        }
    }
}
