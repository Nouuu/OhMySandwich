using OhMySandwich.Domain.marshallers;
using OhMySandwich.Domain.models;

namespace OhMySandwich.Infrastructure.marshallers;

public class ConsolePriceMarshaller : IMarshaller<Price>
{
    public string Serialize(Price price)
    {
        return price.Value + price.Currency;
    }
}