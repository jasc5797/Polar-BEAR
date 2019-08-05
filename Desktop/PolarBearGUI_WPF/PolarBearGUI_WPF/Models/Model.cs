using Newtonsoft.Json;
using PolarBearGUI_WPF.Utilities;
using System.IO;

namespace PolarBearGUI_WPF.Models
{
    public abstract class Model : NotifyPropertyChangedObject
    {
        private static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };

        public override bool Equals(object obj)
        {
            return obj is Model && Equals(obj as Model);
        }

        public abstract bool Equals(Model model);

        public abstract override int GetHashCode();

        public static Model Deserialize(string json)
        {

            return JsonConvert.DeserializeObject<Model>(json, jsonSerializerSettings);
        }

        public static Model DeserializeFromFile(string fileName)
        {
            using (StreamReader streamReader = File.OpenText(fileName))
            {
                JsonSerializer jsonSerializer = new JsonSerializer()
                {
                    TypeNameHandling = jsonSerializerSettings.TypeNameHandling,
                    NullValueHandling = jsonSerializerSettings.NullValueHandling
                };

                return (Model)jsonSerializer.Deserialize(streamReader, typeof(Model));
            }
        }


        public static string Serialize(Model model)
        {
            return model.Serialize();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, jsonSerializerSettings);
        }

        public void SerializeToFile(string fileName)
        {
            using (StreamWriter streamWriter = File.CreateText(fileName))
            {
                JsonSerializer jsonSerializer = new JsonSerializer()
                {
                    TypeNameHandling = jsonSerializerSettings.TypeNameHandling
                };
                jsonSerializer.Serialize(streamWriter, this);
            }
        }
    }
    /*
    public class ModelComparer : IEqualityComparer<Model>
    {
        public bool Equals(Model x, Model y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return x.Equals(y);
        }

        public int GetHashCode(Model model)
        {
            if (ReferenceEquals(model, null))
                return 0;
            return model.GetHashCode();
        }
        
    }
    */
}
