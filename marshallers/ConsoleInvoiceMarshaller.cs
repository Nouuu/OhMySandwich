using OhMySandwich.models;

namespace OhMySandwich.marshallers;

public class ConsoleInvoiceMarshaller : Marshaller<Invoice>
{
    private readonly Marshaller<Price> _priceMarshaller;
    private readonly Marshaller<Sandwich> _sandwichMarshaller;

    public ConsoleInvoiceMarshaller(Marshaller<Price> priceMarshaller, Marshaller<Sandwich> sandwichMarshaller)
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