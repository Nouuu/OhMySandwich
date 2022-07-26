using OhMySandwich.Domain.invoices;
using OhMySandwich.Domain.models;
using OhMySandwich.Domain.utils;

namespace OhMySandwich.Infrastructure.invoices;

public class DefaultInvoiceGenerator : InvoiceGenerator
{
    private readonly Iterator<string> _iterator;

    public DefaultInvoiceGenerator(Iterator<string> iterator)
    {
        _iterator = iterator;
    }

    public Invoice GenerateInvoice(Basket basket)
    {
        var sandwichDictionary = new Dictionary<Sandwich, string>();
        var priceDictionary = new Dictionary<string, Price>();

        foreach (var currentSandwich in basket.GetSandwichList())
        {
            sandwichDictionary[currentSandwich] =
                GetSandwichDictionaryIteration(sandwichDictionary, currentSandwich);
            AddTotal(currentSandwich.Price, priceDictionary);
        }

        return new Invoice(sandwichDictionary, priceDictionary);
    }

    private string GetSandwichDictionaryIteration(Dictionary<Sandwich, string> sandwichDictionary,
        Sandwich currentSandwich)
    {
        return sandwichDictionary.ContainsKey(currentSandwich)
            ? $"{sandwichDictionary[currentSandwich]}+{_iterator.NextIteration()}"
            : _iterator.NextIteration();
    }

    private static void AddTotal(Price price, Dictionary<string, Price> priceDictionary)
    {
        priceDictionary[price.Currency] = priceDictionary.ContainsKey(price.Currency)
            ? price with { Value = priceDictionary[price.Currency].Value + price.Value }
            : price;
    }
}