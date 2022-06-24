using OhMySandwich.Domain.invoices;
using OhMySandwich.Domain.models;
using OhMySandwich.Domain.utils;
using OhMySandwich.Infrastructure.invoices;
using OhMySandwich.Infrastructure.utils;

namespace OhMySandwich.Test.invoices;

public class DefaultInvoiceGeneratorShould
{
    private readonly Sandwich _sandwich1 = new SandwichBuilder()
        .SetName("Jambon")
        .SetPrice(5)
        .GetSandwich();

    private readonly Sandwich _sandwich2 = new SandwichBuilder()
        .SetName("Poulet")
        .SetPrice(10)
        .GetSandwich();

    private readonly Sandwich _sandwich3 = new SandwichBuilder()
        .SetName("DollarPoulet")
        .SetPrice(new Price("$", 6))
        .GetSandwich();

    private readonly Basket _basket = new Basket();

    private readonly InvoiceGenerator _invoiceGenerator = new DefaultInvoiceGenerator(new AlphabetIterator());

    public DefaultInvoiceGeneratorShould()
    {
        _basket.Reset();
        _basket.AddSandwich(_sandwich1);
        _basket.AddSandwich(_sandwich2);
    }

    [Fact]
    public void generate_invoice_with_correct_data()
    {
        var invoice = _invoiceGenerator.GenerateInvoice(_basket);

        Assert.Equal(2, invoice.Sandwiches.Count);
        Assert.Collection(invoice.Sandwiches,
            sandwich =>
            {
                Assert.Equal("A", sandwich.Value);
                Assert.Equal(_sandwich1, sandwich.Key);
            },
            sandwich =>
            {
                Assert.Equal("B", sandwich.Value);
                Assert.Equal(_sandwich2, sandwich.Key);
            }
        );
        Assert.Single(invoice.Prices);
        Assert.Collection(invoice.Prices,
            price =>
            {
                Assert.Equal("€", price.Key);
                Assert.Equal(new Price("€", 15), price.Value);
            }
        );
    }

    [Fact]
    public void generate_invoice_with_same_sandwich_multiple_times()
    {
        _basket.Reset();
        _basket.AddSandwich(_sandwich1);
        _basket.AddSandwich(_sandwich2);
        _basket.AddSandwich(_sandwich1);

        var invoice = _invoiceGenerator.GenerateInvoice(_basket);

        Assert.Equal(2, invoice.Sandwiches.Count);
        Assert.Collection(invoice.Sandwiches,
            sandwich =>
            {
                Assert.Equal("A+C", sandwich.Value);
                Assert.Equal(_sandwich1, sandwich.Key);
            },
            sandwich =>
            {
                Assert.Equal("B", sandwich.Value);
                Assert.Equal(_sandwich2, sandwich.Key);
            }
        );
        Assert.Single(invoice.Prices);
        Assert.Collection(invoice.Prices,
            price =>
            {
                Assert.Equal("€", price.Key);
                Assert.Equal(new Price("€", 20), price.Value);
            }
        );
    }

    [Fact]
    public void generate_invoice_with_same_sandwich_multiple_currencies()
    {
        _basket.AddSandwich(_sandwich3);

        var invoice = _invoiceGenerator.GenerateInvoice(_basket);

        Assert.Equal(3, invoice.Sandwiches.Count);
        Assert.Collection(invoice.Sandwiches,
            sandwich =>
            {
                Assert.Equal("A", sandwich.Value);
                Assert.Equal(_sandwich1, sandwich.Key);
            },
            sandwich =>
            {
                Assert.Equal("B", sandwich.Value);
                Assert.Equal(_sandwich2, sandwich.Key);
            },
            sandwich =>
            {
                Assert.Equal("C", sandwich.Value);
                Assert.Equal(_sandwich3, sandwich.Key);
            }
        );
        Assert.Equal(2, invoice.Prices.Count);
        Assert.Collection(invoice.Prices,
            price =>
            {
                Assert.Equal("€", price.Key);
                Assert.Equal(new Price("€", 15), price.Value);
            },
            price =>
            {
                Assert.Equal("$", price.Key);
                Assert.Equal(new Price("$", 6), price.Value);
            }
        );
    }
}