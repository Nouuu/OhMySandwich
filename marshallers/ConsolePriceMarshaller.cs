using OhMySandwich.models;

namespace OhMySandwich.marshallers;

public class ConsolePriceMarshaller : IMarshaller<Price>
{
    public string Serialize(Price price)
    {
        return price.Value + price.Currency;
    }
}