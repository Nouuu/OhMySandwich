namespace OhMySandwich.models;

public readonly record struct IngredientStack(
    Ingredient Ingredient,
    double Count
)
{
    public override string ToString()
    {
        return $"{{Ingredient = {Ingredient}, Count = {Count} }}";
    }
};