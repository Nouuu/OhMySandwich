using OhMySandwich.models;

class SandwitchBuilder
{
    private readonly string? name;
    private readonly Price? price;
    private readonly List<IngredientStack> ingredients;

    public SandwitchBuilder()
    {
        name = null;
        price = null;
        ingredients = new List<IngredientStack>();
    }
    
    public SandwitchBuilder(string? name, Price? price, List<IngredientStack> ingredientStacks)
    {
        this.name = name;
        this.price = price;
        ingredients = ingredientStacks;
    }

    public Sandwich getResult()
    {
        if (name == null || price == null)
        {
            throw new InvalidOperationException();
        }
    return new Sandwich(name, ingredients.ToArray(), price.Value);
    }

    public SandwitchBuilder setName(string newName)
    {
        return new SandwitchBuilder(newName, price, ingredients);
    }

    public SandwitchBuilder addIngredient(IngredientStack ingredientStack)
    {
        var newIngredients = new List<IngredientStack>(ingredients) { ingredientStack };
        return new SandwitchBuilder(name , price, newIngredients);
    }
    public SandwitchBuilder addIngredient(Ingredient ingredient, int count)
    {
        var newIngredients = new List<IngredientStack>(ingredients) { new(ingredient, count) };
        return new SandwitchBuilder(name , price, newIngredients);
    }

    public SandwitchBuilder setPrice(Price price)
    {
        return new SandwitchBuilder(name, price, ingredients);
    }

    public SandwitchBuilder setPrice(int price)
    {
        return new SandwitchBuilder(name, new Price("€" ,price), ingredients);
    }
}