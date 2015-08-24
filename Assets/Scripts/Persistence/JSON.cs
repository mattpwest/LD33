using Pathfinding.Serialization.JsonFx;

namespace Assets.Scripts.Persistence
{
    public class JSON<T>
    {
        public T Deserialize(string json)
        {
            return JsonReader.Deserialize<T>(json);
        }

        public string Serialize(object value)
        {
            return JsonWriter.Serialize(value);
        }
    }
}
