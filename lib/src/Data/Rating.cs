using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>A rating is an evaluation on a numeric scale, such as 1 to 5 stars.</summary>
    public class Rating : Thing
    {
        /// <summary>The rating for the content.</summary>
        [JsonPropertyName("ratingValue")]
        public float? RatingValue { get; set; }
    }
}
