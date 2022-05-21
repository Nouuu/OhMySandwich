using OhMySandwich.models;

namespace OhMySandwich;

public class SandwichBuilder
{
    private readonly string? name;
    private readonly Price? price;
    private readonly List<IngredientStack> ingredients;

    public SandwichBuilder()
    {
        name = null;
        price = null;
        ingredients = new List<IngredientStack>();
    }
    
    public SandwichBuilder(string? name, Price? price, List<IngredientStack> ingredientStacks)
    {
        this.name = name;
        this.price = price;
        ingredients = ingredientStacks;
    }

    public Sandwich GetSandwich()
    {
        if (name == null || price == null)
        {
            throw new InvalidOperationException();
        }
        return new Sandwich(name, ingredients.ToArray(), price.Value);
    }

    public SandwichBuilder SetName(string newName)
    {
        return new SandwichBuilder(newName, price, ingredients);
    }

    public SandwichBuilder AddIngredient(IngredientStack ingredientStack)
    {
        var newIngredients = new List<IngredientStack>(ingredients) { ingredientStack };
        return new SandwichBuilder(name , price, newIngredients);
    }
    public SandwichBuilder AddIngredient(Ingredient ingredient, double count)
    {
        var newIngredients = new List<IngredientStack>(ingredients) { new(ingredient, count) };
        return new SandwichBuilder(name , price, newIngredients);
    }

    public SandwichBuilder SetPrice(Price price)
    {
        return new SandwichBuilder(name, price, ingredients);
    }

    public SandwichBuilder SetPrice(double price)
    {
        return new SandwichBuilder(name, new Price("€" ,price), ingredients);
    }
}