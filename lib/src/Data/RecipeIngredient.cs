using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FetchRecipe.Data
{
    /// <summary>A custom wrapper class around the otherwise text-only recipe ingredient.</summary>
    [JsonConverter(typeof(RecipeIngredientConverter))]
    public sealed partial class RecipeIngredient
    {
        /// <summary>A regular expression to match a text representation of a <see cref="RecipeIngredient"/></summary>
        public static readonly Regex Regex = CreateRegex();

        private const string AmountName = "amount";
        private const string UnitName = "unit";
        private const string DescriptionName = "description";

        [GeneratedRegex($@"(?<{AmountName}>[\d/]+) (?<{DescriptionName}>(?<{UnitName}>\w+)?.*)")]
        private static partial Regex CreateRegex();

        /// <summary>Parse a given string into a <see cref="RecipeIngredient"/>.</summary>
        /// <param name="text">a text representation of a <see cref="RecipeIngredient"/></param>
        /// <returns>
        /// <see langword="null"/>, if the given <see langword="string"/> is either <see langword="null"/> or does not
        /// match <see cref="Regex"/>; a <see cref="RecipeIngredient"/> otherwise
        /// </returns>
        public static RecipeIngredient? Parse(string? text)
        {
            if (text is null)
            {
                return null;
            }

            Match match = Regex.Match(text);

            if (!match.Success)
            {
                return null;
            }

            string amount = match.Groups[AmountName].Value;
            string? unit = match.Groups[UnitName].Value;
            string description = match.Groups[DescriptionName].Value;

            if (unit is not null)
            {
                description = description[unit.Length..].Trim();

                if (description.StartsWith("of", StringComparison.InvariantCultureIgnoreCase))
                {
                    description = description["of".Length..].Trim();
                }
            }

            return new RecipeIngredient(amount, unit, description);
        }

        /// <summary>Create a new <see cref="RecipeIngredient"/> with the given amount, unit and description.</summary>
        /// <param name="amount">the amount of the given unit</param>
        /// <param name="unit">the unit of the given amount</param>
        /// <param name="description">the description of the ingredient</param>
        public RecipeIngredient(string amount, string? unit, string description)
        {
            Amount = amount;
            Unit = unit;
            Description = description;
        }

        /// <summary>The amount of the <see cref="RecipeIngredient"/></summary>
        public string Amount { get; set; }

        /// <summary>The unit of the <see cref="RecipeIngredient"/></summary>
        public string? Unit { get; set; }

        /// <summary>The description of the <see cref="RecipeIngredient"/></summary>
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new();
            _ = builder.Append(Amount);
            if (Unit is not null)
            {
                _ = builder.Append(Unit);
            }
            return builder.Append(Description).ToString();
        }
    }

    /// <summary>A <see cref="JsonConverter"/> for <see cref="RecipeIngredient"/>.</summary>
    public class RecipeIngredientConverter : JsonConverter<RecipeIngredient>
    {
        public override RecipeIngredient? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return RecipeIngredient.Parse(reader.GetString()) ?? throw new JsonException();
        }

        public override void Write(
            Utf8JsonWriter writer,
            RecipeIngredient value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}