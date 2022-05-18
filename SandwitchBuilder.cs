using OhMySandwich.models;

class SandwitchBuilder
{
    private readonly string? name;
    private readonly Price? price;
    private readonly IngredientStack[] ingredients;

    public Sandwich getResult()
    {
        return new Sandwich(name, ingredients, price);
    }

    public SandwitchBuilder setName(string newName)
    {
        return new SandwitchBuilder(newName, ingredients, price);
    }

    public SandwitchBuilder addIngredient(IngredientStack ingredientStack)
    {
        // todo push the new ingredient
        return new SandwitchBuilder(name , ingredients.Clone(), price);
    }

    public SandwitchBuilder changePrice(Price price)
    {
        return new SandwitchBuilder(name, ingredients, price);
    }

}