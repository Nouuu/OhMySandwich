namespace OhMySandwich.models;

public readonly record struct Sandwich(
    string Name,
    IngredientStack[] Ingredients,
    Price Price
)
{
    public override string ToString()
    {
        return $"Sandwich {{ " +
               $"Name = {Name}, " +
               $"Ingredients = [{String.Join(", ", Ingredients)}], " +
               $"Price = {Price} " +
               $"}}";
    }
};