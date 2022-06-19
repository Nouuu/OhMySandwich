using OhMySandwich.Domain.models;
using OhMySandwich.Infrastructure.marshallers;

namespace OhMySandwich.Test.marshallers;

public class ConsolePriceMarshallerShould
{
    [Fact]
    private void serialize_euro_price()
    {
        var price = new Price("€",10);
        var marshaller = new ConsolePriceMarshaller();
        
        var result = marshaller.Serialize(price);
        Assert.Equal("10€", result);
    }
    
    [Fact]
    private void serialize_dollar_price()
    {
        var price = new Price("$",5.5);
        var marshaller = new ConsolePriceMarshaller();
        
        var result = marshaller.Serialize(price);
        Assert.Equal("5,5$", result);
    }
}