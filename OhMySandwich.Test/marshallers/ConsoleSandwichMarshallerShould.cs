using OhMySandwich.Domain.models;
using OhMySandwich.Domain.utils;
using OhMySandwich.Infrastructure.marshallers;

namespace OhMySandwich.Test.marshallers;

public class ConsoleSandwichMarshallerShould
{
    [Fact]
    private void serialize_sandwich_without_ingredients()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(0)
            .GetSandwich();

        var ingredientMarshaller = new ConsoleIngredientMarshaller();
        var marshaller = new ConsoleSandwichMarshaller(ingredientMarshaller);
        var result = marshaller.Serialize(sandwich);
        Assert.Equal("Jambon\n   ", result);
    }

    [Fact]
    private void serialize_sandwich_with_ingredients()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(0)
            .AddIngredient(new Ingredient("Jambon", UnitType.Slice), 1)
            .AddIngredient(new Ingredient("Fromage", UnitType.Slice), 2)
            .GetSandwich();

        var ingredientMarshaller = new ConsoleIngredientMarshaller();
        var marshaller = new ConsoleSandwichMarshaller(ingredientMarshaller);
        var result = marshaller.Serialize(sandwich);
        Assert.Equal("Jambon\n" +
                     "   1 tranche de Jambon\n" +
                     "   2 tranche de Fromage", result);
    }
}