using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>Instructions that explain how to achieve a result by performing a sequence of steps.</summary>
    public class HowTo : CreativeWork
    {
        /// <summary>
        /// The length of time it takes to prepare the items to be used in instructions or a direction.
        /// </summary>
        [JsonPropertyName("prepTime")]
        public TimeSpan? PrepTime { get; set; }

        /// <summary>
        /// The total time required to perform instructions or a direction (including time to prepare the supplies).
        /// </summary>
        [JsonPropertyName("totalTime")]
        public TimeSpan? TotalTime { get; set; }
    }
}
