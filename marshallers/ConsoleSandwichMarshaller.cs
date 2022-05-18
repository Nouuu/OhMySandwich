using OhMySandwich.models;

namespace OhMySandwich.marshallers;

public class ConsoleSandwichMarshaller : Marshaller<Sandwich>
{
    private Marshaller<IngredientStack> _ingredientStackMarshaller;

    public ConsoleSandwichMarshaller(Marshaller<IngredientStack> ingredientStackMarshaller)
    {
        _ingredientStackMarshaller = ingredientStackMarshaller;
    }

    public string Serialize(Sandwich data)
    {
        return data.Name + "\n" + String.Join("\n",
            data.Ingredients.Select(ingredientStack => _ingredientStackMarshaller.Serialize(ingredientStack)));
    }
}