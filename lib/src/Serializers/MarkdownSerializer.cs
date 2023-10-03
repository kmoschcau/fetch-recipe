using System.Text;
using FetchRecipe.Data;

namespace FetchRecipe.Serializers
{
    public class MarkdownSerializer : ISerializer
    {
        public const string IngredientUnitHeader = "Einheit";
        public const string IngredientDescriptionHeader = "Zutat";

        public string Serialize(Recipe? recipe)
        {
            if (recipe is null)
            {
                return "";
            }

            string ingredientAmountHeader = $"{recipe.RecipeYield ?? 4}p*";

            int maxUnitLength = IngredientUnitHeader.Length;
            int maxAmountLength = ingredientAmountHeader.Length;
            int maxDescriptionLength = IngredientDescriptionHeader.Length;
            foreach (RecipeIngredient ingredient in recipe.RecipeIngredient)
            {
                maxUnitLength = Math.Max(maxUnitLength, ingredient.Unit?.Length ?? 0);
                maxAmountLength = Math.Max(maxAmountLength, ingredient.Amount.Length);
                maxDescriptionLength = Math.Max(maxDescriptionLength, ingredient.Description.Length);
            }

            StringBuilder builder = new();
            _ = builder
                .Append("# ")
                .AppendLine(recipe.Name)
                .AppendLine()
                .AppendLine("## Zutaten")
                .AppendLine()
                .Append("| ")
                .Append(IngredientUnitHeader)
                .Append(new string(' ', maxUnitLength - IngredientUnitHeader.Length))
                .Append(" | ")
                .Append(ingredientAmountHeader)
                .Append(new string(' ', maxAmountLength - ingredientAmountHeader.Length))
                .Append(" | ")
                .Append(IngredientDescriptionHeader)
                .Append(new string(' ', maxDescriptionLength - IngredientDescriptionHeader.Length))
                .AppendLine(" |")
                .Append("|-")
                .Append(new string('-', maxUnitLength))
                .Append("-|-")
                .Append(new string('-', maxAmountLength))
                .Append(":|-")
                .Append(new string('-', maxDescriptionLength))
                .AppendLine("-|");

            foreach (RecipeIngredient ingredient in recipe.RecipeIngredient)
            {
                _ = builder
                    .Append("| ")
                    .Append(ingredient.Unit)
                    .Append(new string(' ', maxUnitLength - (ingredient.Unit?.Length ?? 0)))
                    .Append(" | ")
                    .Append(ingredient.Amount)
                    .Append(new string(' ', maxAmountLength - ingredient.Amount.Length))
                    .Append(" | ")
                    .Append(ingredient.Description)
                    .Append(new string(' ', maxDescriptionLength - ingredient.Description.Length))
                    .AppendLine(" |");
            }

            _ = builder.AppendLine().AppendLine("## Anleitung");

            int counter = 1;
            foreach (HowToStep step in recipe.RecipeInstructions)
            {
                _ = builder.AppendLine().Append(counter++).Append(". ").AppendLine(step.Text);
            }

            return builder.ToString();
        }
    }
}