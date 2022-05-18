using OhMySandwich.models;

namespace OhMySandwich.marshallers;

public class ConsoleInvoiceMarshaller : Marshaller<Invoice>
{
    private Marshaller<Price> _priceMarshaller;
    private Marshaller<Sandwich> _sandwichMarshaller;

    public ConsoleInvoiceMarshaller(Marshaller<Price> priceMarshaller, Marshaller<Sandwich> sandwichMarshaller)
    {
        _priceMarshaller = priceMarshaller;
        _sandwichMarshaller = sandwichMarshaller;
    }

    public string Serialize(Invoice data)
    {
        return String.Join("\n",data.Sandwiches.Select(sandwich => _sandwichMarshaller.Serialize(sandwich))) + " : " + _priceMarshaller.Serialize(data.Price);
    }
}