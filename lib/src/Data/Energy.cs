using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FetchRecipe.Data
{
    /// <summary>
    /// Properties that take Energy as values are of the form '&lt;Number&gt; &lt;Energy unit of measure&gt;'.
    /// </summary>
    [JsonConverter(typeof(EnergyJsonConverter))]
    public sealed partial class Energy
    {
        /// <summary>A regular expression to match a text representation of an <see cref="Energy"/></summary>
        public static readonly Regex Regex = CreateRegex();

        private const string NumberName = "number";
        private const string UnitName = "unit";

        [GeneratedRegex($@"(?<{NumberName}>\d+) (?<{UnitName}>\w+)")]
        private static partial Regex CreateRegex();

        /// <summary>Parse a given string into an <see cref="Energy"/>.</summary>
        /// <param name="text">a text representation of a <see cref="Energy"/></param>
        /// <returns>
        /// <see langword="null"/>, if the given <see langword="string"/> is either <see langword="null"/> or does not
        /// match <see cref="Regex"/>; a <see cref="Energy"/> otherwise
        /// </returns>
        public static Energy? Parse(string? text)
        {
            if (text is null)
            {
                return null;
            }

            Match match = Regex.Match(text);

            return match.Success
                ? new Energy(
                    int.Parse(match.Groups[NumberName].Value, CultureInfo.InvariantCulture),
                    match.Groups[UnitName].Value
                )
                : null;
        }

        /// <summary>Create a new <see cref="Energy"/> with the given number and unit.</summary>
        /// <param name="number">the number of the given unit</param>
        /// <param name="unit">the unit of the given number</param>
        public Energy(int number, string unit)
        {
            Number = number;
            Unit = unit;
        }

        /// <summary>The number of the <see cref="Energy"/></summary>
        public int Number { get; set; }

        /// <summary>The unit of the <see cref="Energy"/></summary>
        public string Unit { get; set; }

        public override string ToString()
        {
            return $"{Number} {Unit}";
        }
    }

    /// <summary>A <see cref="JsonConverter"/> for <see cref="Energy"/>.</summary>
    public class EnergyJsonConverter : JsonConverter<Energy>
    {
        public override Energy? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return Energy.Parse(reader.GetString()) ?? throw new JsonException();
        }

        public override void Write(
            Utf8JsonWriter writer,
            Energy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
