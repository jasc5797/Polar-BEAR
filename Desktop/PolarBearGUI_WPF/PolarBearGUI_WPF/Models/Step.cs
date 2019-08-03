using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PolarBearGUI_WPF.Models
{
    public abstract class Step : Model
    {

        private static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

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

        public static Step DeserializeStep(string json)
        {
            
            return JsonConvert.DeserializeObject<Step>(json, jsonSerializerSettings);
        }

        public static List<Step> DeserializeStepList(string json)
        {
            return null;
        }

        public static string SerializeStep(Step step)
        {
            return JsonConvert.SerializeObject(step, jsonSerializerSettings);
        }

        public static string SerializeStepList(List<Step> stepList)
        {
            return JsonConvert.SerializeObject(stepList, jsonSerializerSettings);
        }
        
    }
}
