using OhMySandwich.Domain.marshallers;
using OhMySandwich.Domain.models;
using static System.String;

namespace OhMySandwich.Infrastructure.marshallers;

public class ConsoleBasketMarshaller : IMarshaller<Basket>
{
    public string Serialize(Basket data)
    {
        return Join("", data.GetSandwichList().Select(sandwich => "\n- " + sandwich.Name));
    }
}