using System.Text;
using OhMySandwich.models;

namespace OhMySandwich.invoices;

public class DefaultInvoiceGenerator : InvoiceGenerator
{
    private readonly char[] _alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public Invoice GenerateInvoice(Basket basket)
    {
        var sandwichDictionary = new Dictionary<Sandwich, string>();
        var priceDictionary = new Dictionary<string, Price>();
        var sandwichs = basket.GetSandwichList();

        for (var i = 0; i < sandwichs.Count; i++)
        {
            var currentSandwich = sandwichs[i];
            sandwichDictionary[currentSandwich] =
                GetSandwichDictionaryIteration(sandwichDictionary, currentSandwich, i);
            AddTotal(currentSandwich.Price, priceDictionary);
        }

        return new Invoice(sandwichDictionary, priceDictionary);
    }

    private string GetSandwichDictionaryIteration(Dictionary<Sandwich, string> sandwichDictionary,
        Sandwich currentSandwich, int alphaIndex)
    {
        return sandwichDictionary.ContainsKey(currentSandwich)
            ? $"{sandwichDictionary[currentSandwich]}+{_alpha[alphaIndex % _alpha.Length]}"
            : _alpha[alphaIndex % _alpha.Length].ToString();
    }

    private static void AddTotal(Price price, Dictionary<string, Price> priceDictionary)
    {
        if (priceDictionary.ContainsKey(price.Currency))
        {
            priceDictionary[price.Currency] =
                price with { Value = priceDictionary[price.Currency].Value + price.Value };
        }
        else
        {
            priceDictionary[price.Currency] = price;
        }
    }
}