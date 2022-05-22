using OhMySandwich.models;

namespace OhMySandwich.utils;

public class SandwichBuilder
{
    private readonly string? _name;
    private readonly Price? _price;
    private readonly List<IngredientStack> _ingredients;

    public SandwichBuilder()
    {
        _name = null;
        _price = null;
        _ingredients = new List<IngredientStack>();
    }
    
    public SandwichBuilder(string? name, Price? price, List<IngredientStack> ingredientStacks)
    {
        this._name = name;
        this._price = price;
        _ingredients = ingredientStacks;
    }

    public Sandwich GetSandwich()
    {
        if (_name == null || _price == null)
        {
            throw new InvalidOperationException();
        }
        return new Sandwich(_name, _ingredients.ToArray(), _price.Value);
    }

    public SandwichBuilder SetName(string newName)
    {
        return new SandwichBuilder(newName, _price, _ingredients);
    }

    public SandwichBuilder AddIngredient(IngredientStack ingredientStack)
    {
        var newIngredients = new List<IngredientStack>(_ingredients) { ingredientStack };
        return new SandwichBuilder(_name , _price, newIngredients);
    }
    public SandwichBuilder AddIngredient(Ingredient ingredient, double count)
    {
        var newIngredients = new List<IngredientStack>(_ingredients) { new(ingredient, count) };
        return new SandwichBuilder(_name , _price, newIngredients);
    }

    public SandwichBuilder SetPrice(Price price)
    {
        return new SandwichBuilder(_name, price, _ingredients);
    }

    public SandwichBuilder SetPrice(double price)
    {
        return new SandwichBuilder(_name, new Price("€" ,price), _ingredients);
    }
}