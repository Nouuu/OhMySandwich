using OhMySandwich.models;

namespace OhMySandwich.marshallers;

public class ConsolePriceMarshaller : Marshaller<Price>
{
    public string Serialize(Price price)
    {
        return price.Value + price.Currency;
    }
}