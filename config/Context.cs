using OhMySandwich.invoices;
using OhMySandwich.marshallers;
using OhMySandwich.models;
using OhMySandwich.ui;
using OhMySandwich.ui.cli;

namespace OhMySandwich.config;

public class Context
{
    private InvoiceGenerator? _singletonInvoiceGenerator;

    // * Marshallers
    private Marshaller<IngredientStack>? _singletonIngredientMarshaller;
    private Marshaller<Invoice>? _singletonInvoiceMarshaller;
    private Marshaller<Price>? _singletonPriceMarshaller;
    private Marshaller<Sandwich>? _singletonSandwichMarshaller;
    
    // * UI
    private Adapter? _singletonAdapter;

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
    
    public Adapter GetAdapter()
    {
        return _singletonAdapter ??= new CliAdapter();
    }
}