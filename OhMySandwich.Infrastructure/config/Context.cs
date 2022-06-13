using OhMySandwich.CLI;
using OhMySandwich.Domain.invoices;
using OhMySandwich.Domain.marshallers;
using OhMySandwich.Domain.models;
using OhMySandwich.Domain.ui;
using OhMySandwich.Domain.utils;
using OhMySandwich.Infrastructure.invoices;
using OhMySandwich.Infrastructure.marshallers;

namespace OhMySandwich.Infrastructure.config;

public class Context
{
    private InvoiceGenerator? _singletonInvoiceGenerator;

    // * Marshallers
    private IMarshaller<IngredientStack>? _singletonIngredientMarshaller;
    private IMarshaller<Invoice>? _singletonInvoiceMarshaller;
    private IMarshaller<Price>? _singletonPriceMarshaller;
    private IMarshaller<Sandwich>? _singletonSandwichMarshaller;
    private IMarshaller<Basket>? _singletonBasketMarshaller;

    // * UI
    private IAdapter? _singletonAdapter;

    // * Basket
    private Basket? _basket;
    private List<ICommand>? _availableCommands;
    private List<Sandwich>? _availableSandwiches;

    private readonly Ingredient _butter = new Ingredient("Beurre", UnitType.Gram);
    private readonly Ingredient _ham = new Ingredient("Jambon", UnitType.Slice);
    private readonly Ingredient _chicken = new Ingredient("Poulet", UnitType.Slice);
    private readonly Ingredient _egg = new Ingredient("Oeufs", UnitType.SimpleUnit);
    private readonly Ingredient _bread = new Ingredient("Pain", UnitType.SimpleUnit);
    private readonly Ingredient _tomato = new Ingredient("Tomate", UnitType.SimpleUnit);
    private readonly Ingredient _salad = new Ingredient("Salade", UnitType.Gram);
    private readonly Ingredient _tuna = new Ingredient("Thon", UnitType.Gram);
    private readonly Ingredient _mayonnaise = new Ingredient("Mayonnaise", UnitType.Gram);


    public InvoiceGenerator GetInvoiceGenerator()
    {
        return _singletonInvoiceGenerator ??= new DefaultInvoiceGenerator();
    }

    public IMarshaller<IngredientStack> GetIngredientMarshaller()
    {
        return _singletonIngredientMarshaller ??= new ConsoleIngredientMarshaller();
    }

    // return invoice marshaller using the other marshaller methods for needed dependencies
    public IMarshaller<Invoice> GetInvoiceMarshaller()
    {
        return _singletonInvoiceMarshaller ??=
            new ConsoleInvoiceMarshaller(GetPriceMarshaller(), GetSandwichMarshaller());
    }

    public IMarshaller<Price> GetPriceMarshaller()
    {
        return _singletonPriceMarshaller ??= new ConsolePriceMarshaller();
    }

    public IMarshaller<Sandwich> GetSandwichMarshaller()
    {
        return _singletonSandwichMarshaller ??= new ConsoleSandwichMarshaller(GetIngredientMarshaller());
    }

    public IMarshaller<Basket> GetBasketMarshaller()
    {
        return _singletonBasketMarshaller ??= new ConsoleBasketMarshaller();
    }

    public Basket GetBasket()
    {
        return _basket ??= new Basket();
    }

    public List<ICommand> GetAvailableCommands()
    {
        return _availableCommands ??= new List<ICommand>()
        {
            new NewOrderCommand(GetBasket()),
            new SandwichSelectorCommand(GetBasket(), GetPriceMarshaller(), GetSandwichMarshaller(), GetAvailableSandwichs()),
            new InvoiceGeneratorCommand(GetBasket(), GetInvoiceGenerator(), GetInvoiceMarshaller()),
        };
    }

    public List<Sandwich> GetAvailableSandwichs()
    {
        return _availableSandwiches ??= new List<Sandwich>
        {
            new SandwichBuilder()
                .SetName("Jambon beurre")
                .SetPrice(new Price("€", 3.5))
                .AddIngredient(_bread, 1)
                .AddIngredient(_ham, 1)
                .AddIngredient(_butter, 10)
                .GetSandwich(),
            new SandwichBuilder()
                .SetName("Poulet crudités")
                .SetPrice(new Price("€", 5))
                .AddIngredient(_bread, 1)
                .AddIngredient(_egg, 1)
                .AddIngredient(_tomato, 0.5)
                .AddIngredient(_chicken, 1)
                .AddIngredient(_mayonnaise, 10)
                .AddIngredient(_salad, 10)
                .GetSandwich(),
            new SandwichBuilder()
                .SetName("Dieppois")
                .SetPrice(new Price("€", 4.5))
                .AddIngredient(_bread, 1)
                .AddIngredient(_tuna, 50)
                .AddIngredient(_tomato, 0.5)
                .AddIngredient(_mayonnaise, 10)
                .AddIngredient(_salad, 10)
                .GetSandwich()
        };
    }

    public IAdapter GetAdapter()
    {
        return _singletonAdapter ??= new CliAdapter(new MenuCommand(GetAvailableCommands(), GetBasket(), GetBasketMarshaller()));
    }
}