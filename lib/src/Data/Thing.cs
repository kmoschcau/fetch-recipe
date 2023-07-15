using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>The most generic type of item.</summary>
    public class Thing
    {
        /// <summary>A description of the item.</summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>The name of the item.</summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}