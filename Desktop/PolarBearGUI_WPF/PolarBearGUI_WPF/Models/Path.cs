using Newtonsoft.Json;
using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.Models
{
    public class Path : Model
    {

        public List<Step> Steps { get; set; }


        public Path()
        {
            Steps = new List<Step>();
        }

        public Path(List<Step> steps)
        {
            Steps = steps;
        }

        public override bool Equals(Model model)
        {
            if (model is Path)
            {
                Path path = model as Path;
                return Steps == path.Steps;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Steps.GetHashCode();
        }
    }
}
