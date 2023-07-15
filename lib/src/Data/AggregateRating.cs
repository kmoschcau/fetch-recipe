using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>The average rating based on multiple ratings or reviews.</summary>
    public class AggregateRating : Rating
    {
        /// <summary>The count of total number of ratings.</summary>
        [JsonPropertyName("ratingCount")]
        public int? RatingCount { get; set; }

        /// <summary>The count of total number of reviews.</summary>
        [JsonPropertyName("reviewCount")]
        public int? ReviewCount { get; set; }
    }
}