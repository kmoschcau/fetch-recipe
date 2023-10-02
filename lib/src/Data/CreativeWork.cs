using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>
    /// The most generic kind of creative work, including books, movies, photographs, software programs, etc.
    /// </summary>
    public class CreativeWork : Thing
    {
        /// <summary>The overall rating, based on a collection of reviews or ratings, of the item.</summary>
        [JsonPropertyName("aggregateRating")]
        public AggregateRating? AggregateRating { get; set; }

        /// <summary>The author of this content or rating.</summary>
        [JsonPropertyName("author")]
        public Thing? Author { get; set; }

        /// <summary>Date of first broadcast/publication.</summary>
        [JsonPropertyName("datePublished")]
        public DateTime? DatePublished { get; set; }

        /// <summary>
        /// Keywords or tags used to describe some item. Multiple textual entries in a keywords list are typically
        /// delimited by commas, or by repeating the property.
        /// </summary>
        [JsonPropertyName("keywords")]
        public string? Keywords { get; set; }

        /// <summary>The textual content of this CreativeWork.</summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}