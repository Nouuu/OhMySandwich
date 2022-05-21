using OhMySandwich.models;

namespace OhMySandwich.marshallers;

public class ConsoleIngredientMarshaller : Marshaller<IngredientStack>
{
    public string Serialize(IngredientStack data)
    {
        return data.Count + data.Ingredient.UnitType.Value + data.Ingredient.Name;
    }
}