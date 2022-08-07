using System.Text.Json;

namespace Mancala.Core.Extensions
{
    public static class DeepCopyExtension
    {

        public static T Copy<T>(this T objectValue)
        {
            var json = JsonSerializer.Serialize(objectValue);
            var newObject = JsonSerializer.Deserialize<T>(json);
            return newObject!;
        }
    }
}