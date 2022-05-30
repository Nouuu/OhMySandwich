using OhMySandwich.invoices;
using OhMySandwich.marshallers;
using OhMySandwich.models;
using OhMySandwich.ui;
using OhMySandwich.ui.cli;
using OhMySandwich.utils;

namespace OhMySandwich.config;

public class Context
{
    private InvoiceGenerator? _singletonInvoiceGenerator;

    // * Marshallers
    private Marshaller<IngredientStack>? _singletonIngredientMarshaller;
    private Marshaller<Invoice>? _singletonInvoiceMarshaller;
    private Marshaller<Price>? _singletonPriceMarshaller;
    private Marshaller<Sandwich>? _singletonSandwichMarshaller;
    private Marshaller<Basket>? _singletonBasketMarshaller;

    // * UI
    private Adapter? _singletonAdapter;

    // * Basket
    private Basket? _singletonBasket;
    private List<Command>? _singletonCommands;
    private List<Sandwich>? _singletonSandwiches;

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

    public Marshaller<IngredientStack> GetIngredientMarshaller()
    {
        return _singletonIngredientMarshaller ??= new ConsoleIngredientMarshaller();
    }

    // return invoice marshaller using the other marshaller methods for needed dependencies
    public Marshaller<Invoice> GetInvoiceMarshaller()
    {
        return _singletonInvoiceMarshaller ??=
            new ConsoleInvoiceMarshaller(GetPriceMarshaller(), GetSandwichMarshaller());
    }

    public Marshaller<Price> GetPriceMarshaller()
    {
        return _singletonPriceMarshaller ??= new ConsolePriceMarshaller();
    }

    public Marshaller<Sandwich> GetSandwichMarshaller()
    {
        return _singletonSandwichMarshaller ??= new ConsoleSandwichMarshaller(GetIngredientMarshaller());
    }

    public Marshaller<Basket> GetBasketMarshaller()
    {
        return _singletonBasketMarshaller ??= new ConsoleBasketMarshaller();
    }

    public Basket GetBasket()
    {
        return _singletonBasket ??= new Basket();
    }

    public List<Command> GetCommands()
    {
        return _singletonCommands ??= new List<Command>()
        {
            new NewOrderCommand(GetBasket()),
            new SandwichSelectorCommand(GetBasket(), GetPriceMarshaller(), GetSandwichMarshaller(), GetSandwichs()),
            new InvoiceGeneratorCommand(GetBasket(), GetInvoiceGenerator(), GetInvoiceMarshaller()),
        };
    }

    public List<Sandwich> GetSandwichs()
    {
        return _singletonSandwiches ??= new List<Sandwich>
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

    public Adapter GetAdapter()
    {
        return _singletonAdapter ??= new CliAdapter(new MenuCommand(GetCommands(), GetBasket(), GetBasketMarshaller()));
    }
}