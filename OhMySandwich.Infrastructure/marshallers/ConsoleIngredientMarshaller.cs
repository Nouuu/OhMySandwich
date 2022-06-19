using OhMySandwich.Domain.marshallers;
using OhMySandwich.Domain.models;

namespace OhMySandwich.Infrastructure.marshallers;

public class ConsoleIngredientMarshaller : IMarshaller<IngredientStack>
{
    public string Serialize(IngredientStack data)
    {
        return data.Count + data.Ingredient.UnitType.Value + data.Ingredient.Name;
    }
}