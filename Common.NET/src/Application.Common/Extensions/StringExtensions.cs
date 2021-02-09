using System.Text.RegularExpressions;

namespace Application.Common.Extensions
{
    /// <summary>Методы-расширения для <see cref="string"/></summary>
    public static class StringExtensions
    {
        /// <summary>Замена шаблона {ClassName.PropertyName} на имя класса и значение свойства</summary>
        /// <param name="string">Исходная строка</param>
        /// <param name="objects">Объекты, имена и значения свойств которых используются для подстановки</param>
        /// <returns>Строка-результат</returns>
        public static string ReplacePropertyNamesByValues(this string @string, params object[] objects)
        {
            foreach (var @object in objects)
            {
                foreach (var property in @object.GetType().GetProperties())
                {
                    @string = Regex.Replace(
                        input: @string,
                        pattern: $"{{{@object.GetType().Name}.{property.Name}}}",
                        replacement: property.GetValue(@object)?.ToString() ?? string.Empty);
                }
            }

            return @string;
        }
    }
}