using OhMySandwich.models;

namespace OhMySandwich.marshallers;

public class ConsoleInvoiceMarshaller : IMarshaller<Invoice>
{
    private readonly IMarshaller<Price> _priceMarshaller;
    private readonly IMarshaller<Sandwich> _sandwichMarshaller;

    public ConsoleInvoiceMarshaller(IMarshaller<Price> priceMarshaller, IMarshaller<Sandwich> sandwichMarshaller)
    {
        _priceMarshaller = priceMarshaller;
        _sandwichMarshaller = sandwichMarshaller;
    }

    public string Serialize(Invoice data)
    {
        return $"{String.Join("\n",data.Sandwiches.Select(pair => $"{pair.Value} {_sandwichMarshaller.Serialize(pair.Key)}"))}" +
               $"\nPrix total : {String.Join(", ", data.Prices.Values.Select(price => _priceMarshaller.Serialize(price)))}";
    }
}