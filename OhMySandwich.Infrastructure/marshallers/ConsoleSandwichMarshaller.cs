using OhMySandwich.Domain.marshallers;
using OhMySandwich.Domain.models;
using static System.String;

namespace OhMySandwich.Infrastructure.marshallers;

public class ConsoleSandwichMarshaller : IMarshaller<Sandwich>
{
    private readonly IMarshaller<IngredientStack> _ingredientStackMarshaller;

    public ConsoleSandwichMarshaller(IMarshaller<IngredientStack> ingredientStackMarshaller)
    {
        _ingredientStackMarshaller = ingredientStackMarshaller;
    }

    public string Serialize(Sandwich data)
    {
        return data.Name + "\n   " + Join("\n   ",
            data.Ingredients.Select(ingredientStack => _ingredientStackMarshaller.Serialize(ingredientStack)));
    }
}