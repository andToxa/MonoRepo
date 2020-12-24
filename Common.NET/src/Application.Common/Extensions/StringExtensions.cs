using System.Text.RegularExpressions;

namespace Application.Common.Extensions
{
    /// <summary>Методы-расширения для <see cref="string"/></summary>
    public static class StringExtensions
    {
        /// <summary>Замена шаблона {ClassName.PropertyName} на имя класса и значение свойства</summary>
        /// <param name="sourceString">Исходная строка</param>
        /// <param name="sourceObjects">Объекты, имена и значения свойств которых используются для подстановки</param>
        /// <returns>Строка-результат</returns>
        public static string ReplacePropertyNamesByValues(this string sourceString, params object[] sourceObjects)
        {
            foreach (var sourceObject in sourceObjects)
            {
                foreach (var property in sourceObject.GetType().GetProperties())
                {
                    sourceString = Regex.Replace(
                        input: sourceString,
                        pattern: $"{{{sourceObject.GetType().Name}.{property.Name}}}",
                        replacement: property.GetValue(sourceObject)?.ToString() ?? string.Empty);
                }
            }

            return sourceString;
        }
    }
}