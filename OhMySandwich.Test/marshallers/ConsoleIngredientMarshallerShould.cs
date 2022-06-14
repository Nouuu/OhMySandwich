using OhMySandwich.Domain.models;
using OhMySandwich.Infrastructure.marshallers;

namespace OhMySandwich.Test.marshallers;

public class ConsoleIngredientMarshallerShould
{
    [Fact]
    private void serialize_an_ingredient_stack()
    {
        var ingredient = new Ingredient("Carotte", UnitType.Slice);
        var ingredientStack = new IngredientStack(ingredient, 2);
        
        var marshaller = new ConsoleIngredientMarshaller();
        var result = marshaller.Serialize(ingredientStack);
        
        Assert.Equal("2 tranche de Carotte", result);
    }
}