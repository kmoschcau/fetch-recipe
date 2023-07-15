using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FetchRecipe.Data
{
    /// <summary>
    /// Properties that take Mass as values are of the form '&lt;Number&gt; &lt;Mass unit of measure&gt;'. E.g., '7 kg'.
    /// </summary>
    [JsonConverter(typeof(MassJsonConverter))]
    public sealed partial class Mass
    {
        /// <summary>A regular expression to match a text representation of a <see cref="Mass"/></summary>
        public static readonly Regex Regex = CreateRegex();

        private const string NumberName = "number";
        private const string UnitName = "unit";

        [GeneratedRegex($@"(?<{NumberName}>\d+) (?<{UnitName}>\w+)")]
        private static partial Regex CreateRegex();

        /// <summary>Parse a given string into a <see cref="Mass"/>.</summary>
        /// <param name="text">a text representation of a <see cref="Mass"/></param>
        /// <returns>
        /// <see langword="null"/>, if the given <see langword="string"/> is either <see langword="null"/> or does not
        /// match <see cref="Regex"/>; a <see cref="Mass"/> otherwise
        /// </returns>
        public static Mass? Parse(string? text)
        {
            if (text is null)
            {
                return null;
            }

            Match match = Regex.Match(text);

            return match.Success
                ? new Mass(
                    int.Parse(match.Groups[NumberName].Value, CultureInfo.InvariantCulture),
                    match.Groups[UnitName].Value
                )
                : null;
        }

        /// <summary>Create a new <see cref="Mass"/> with the given number and unit.</summary>
        /// <param name="number">the number of the given unit</param>
        /// <param name="unit">the unit of the given number</param>
        public Mass(int number, string unit)
        {
            Number = number;
            Unit = unit;
        }

        /// <summary>The number of the <see cref="Mass"/></summary>
        public int Number { get; set; }

        /// <summary>The unit of the <see cref="Mass"/></summary>
        public string Unit { get; set; }

        public override string ToString()
        {
            return $"{Number} {Unit}";
        }
    }

    /// <summary>A <see cref="JsonConverter"/> for <see cref="Mass"/>.</summary>
    public class MassJsonConverter : JsonConverter<Mass>
    {
        public override Mass? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return Mass.Parse(reader.GetString()) ?? throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Mass value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
