using FetchRecipe.Data;

namespace FetchRecipe.Serializers
{
    public interface ISerializer
    {
        /// <summary>Serialize the given <see cref="Recipe"/> into a specific format.</summary>
        /// <param name="recipe">the <see cref="Recipe"/> to serialize</param>
        /// <returns>the serialized <see cref="Recipe"/></returns>
        string Serialize(Recipe? recipe);
    }
}