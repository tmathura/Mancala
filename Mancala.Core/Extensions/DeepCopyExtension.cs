using System.Text.Json;

namespace Mancala.Core.Extensions
{
    public static class DeepCopyExtension
    {
        /// <summary>
        /// Functionality to create a new instance of an object without a reference to the original object.
        /// </summary>
        /// <typeparam name="T">The type of the passed in object.</typeparam>
        /// <param name="objectValue">The object to copy.</param>
        /// <returns>A copy of the object.</returns>
        public static T Copy<T>(this T objectValue)
        {
            var json = JsonSerializer.Serialize(objectValue);
            var newObject = JsonSerializer.Deserialize<T>(json);
            return newObject!;
        }
    }
}