using OhMySandwich.CLI;
using OhMySandwich.Domain.config;
using OhMySandwich.Domain.models;
using OhMySandwich.Domain.ui;
using OhMySandwich.Infrastructure.config;
using OhMySandwich.Infrastructure.invoices;
using OhMySandwich.Infrastructure.marshallers;

namespace OhMySandwich.Test.config;

public class CliContextShould
{
    private readonly Context _context = new CliContext();

    [Fact]
    public void instantiate_default_invoice_generator()
    {
        Assert.IsType<DefaultInvoiceGenerator>(_context.GetInvoiceGenerator());
        Assert.IsType<DefaultInvoiceGenerator>(_context.GetInvoiceGenerator());
    }

    [Fact]
    public void instantiate_console_ingredient_marshaller()
    {
        Assert.IsType<ConsoleIngredientMarshaller>(_context.GetIngredientMarshaller());
        Assert.IsType<ConsoleIngredientMarshaller>(_context.GetIngredientMarshaller());
    }

    [Fact]
    public void instantiate_console_invoice_marshaller()
    {
        Assert.IsType<ConsoleInvoiceMarshaller>(_context.GetInvoiceMarshaller());
        Assert.IsType<ConsoleInvoiceMarshaller>(_context.GetInvoiceMarshaller());
    }

    [Fact]
    public void instantiate_console_price_marshaller()
    {
        Assert.IsType<ConsolePriceMarshaller>(_context.GetPriceMarshaller());
        Assert.IsType<ConsolePriceMarshaller>(_context.GetPriceMarshaller());
    }

    [Fact]
    public void instantiate_console_sandwich_marshaller()
    {
        Assert.IsType<ConsoleSandwichMarshaller>(_context.GetSandwichMarshaller());
        Assert.IsType<ConsoleSandwichMarshaller>(_context.GetSandwichMarshaller());
    }

    [Fact]
    public void instantiate_console_basket_marshaller()
    {
        Assert.IsType<ConsoleBasketMarshaller>(_context.GetBasketMarshaller());
        Assert.IsType<ConsoleBasketMarshaller>(_context.GetBasketMarshaller());
    }

    [Fact]
    public void instantiate_empty_basket()
    {
        var basket = _context.GetBasket();
        Assert.IsType<Basket>(basket);
        Assert.Empty(basket.GetSandwichList());
    }

    [Fact]
    public void instantiate_available_commands()
    {
        var commands = _context.GetAvailableCommands();
        Assert.IsType<List<ICommand>>(commands);
        Assert.Equal(3, commands.Count);
        Assert.Collection(commands,
            command => Assert.IsType<NewOrderCommand>(command),
            command => Assert.IsType<SandwichSelectorCommand>(command),
            command => Assert.IsType<InvoiceGeneratorCommand>(command));
    }

    [Fact]
    public void instantiate_available_sandwichs()
    {
        var sandwiches = _context.GetAvailableSandwichs();
        Assert.Equal(3, sandwiches.Count);
        Assert.Collection(sandwiches,
            sandwich => Assert.Equal("Jambon beurre", sandwich.Name),
            sandwich => Assert.Equal("Poulet crudités", sandwich.Name),
            sandwich => Assert.Equal("Dieppois", sandwich.Name));
    }

    [Fact]
    public void instantiate_cli_adapter()
    {
        Assert.IsType<CliAdapter>(_context.GetAdapter());
        Assert.IsType<CliAdapter>(_context.GetAdapter());
    }
}