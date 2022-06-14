using OhMySandwich.Domain.models;
using OhMySandwich.Domain.utils;
using OhMySandwich.Infrastructure.marshallers;

namespace OhMySandwich.Test.marshallers;

public class ConsoleInvoiceMarshallerShould
{
    private readonly ConsoleInvoiceMarshaller _marshaller = new ConsoleInvoiceMarshaller(
        new ConsolePriceMarshaller(),
        new ConsoleSandwichMarshaller(
            new ConsoleIngredientMarshaller()
        )
    );

    [Fact]
    private void show_nothing_if_empty_invoice()
    {
        var invoice = new Invoice(
            new Dictionary<Sandwich, string>(),
            new Dictionary<string, Price>()
        );

        var result = _marshaller.Serialize(invoice);
        Assert.Equal("\nPrix total : ", result);
    }

    [Fact]
    private void show_invoice_with_one_sandwich()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(0)
            .GetSandwich();

        var invoice = new Invoice(
            new Dictionary<Sandwich, string>() { { sandwich, "1" } },
            new Dictionary<string, Price>() { { "€", new Price("€", 10) } }
        );

        var result = _marshaller.Serialize(invoice);
        Assert.Equal(
            "1 Jambon\n   \nPrix total : 10€",
            result
        );
    }

    [Fact]
    private void show_invoice_with_two_sandwiches_and_two_currencies()
    {
        var sandwich1 = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(0)
            .GetSandwich();
        var sandwich2 = new SandwichBuilder()
            .SetName("Fromage")
            .SetPrice(0)
            .GetSandwich();

        var invoice = new Invoice(
            new Dictionary<Sandwich, string>() { { sandwich1, "1" }, { sandwich2, "2" } },
            new Dictionary<string, Price>() { { "€", new Price("€", 10) }, { "$", new Price("$", 20) } }
        );
        
        var result = _marshaller.Serialize(invoice);
        Assert.Equal(
            "1 Jambon\n   \n2 Fromage\n   \nPrix total : 10€, 20$",
            result
        );
    }
}