using OhMySandwich.models;
using static System.String;

namespace OhMySandwich.marshallers;

public class ConsoleBasketMarshaller : Marshaller<Basket>
{
    public string Serialize(Basket data)
    {
        return Join("", data.GetSandwichList().Select(sandwich => "\n- " + sandwich.Name));
    }
}