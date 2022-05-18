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
            sandwichDictionary.Add(
                currentSandwich,
                GetSandwichDictionaryIteration(sandwichDictionary.ContainsKey(currentSandwich), i)
            );
            AddTotal(currentSandwich.Price, priceDictionary);
        }

        return new Invoice(sandwichDictionary, priceDictionary);
    }

    private string GetSandwichDictionaryIteration(bool alreadyExist, int alphaIndex)
    {
        return alreadyExist ? $"+{_alpha[alphaIndex % _alpha.Length]}" : _alpha[alphaIndex % _alpha.Length].ToString();
    }

    private void AddTotal(Price price, Dictionary<string, Price> priceDictionary)
    {
        if (priceDictionary.ContainsKey(price.Currency))
        {
            priceDictionary.Add(price.Currency,
                price with { Value = priceDictionary[price.Currency].Value + price.Value });
        }
        else
        {
            priceDictionary.Add(price.Currency, price);
        }
    }
}