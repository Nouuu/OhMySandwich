using OhMySandwich.models;

namespace OhMySandwich.invoices;

public class DefaultInvoiceGenerator : InvoiceGenerator
{
    private readonly char[] _alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public Invoice GenerateInvoice(Basket basket)
    {
        var sandwichDictionary = new Dictionary<Sandwich, string>();
        var sandwichs = basket.GetSandwichList();
        double total = 0;

        for (int i = 0; i < sandwichs.Count; i++)
        {
            var currentSandwich = sandwichs[i];
            sandwichDictionary.Add(
                currentSandwich,
                GetSandwichDictionaryIteration(sandwichDictionary.ContainsKey(currentSandwich), i)
            );
            total += sandwichs[i].Price.Value;
        }

        return new Invoice(sandwichDictionary, new Price("€", total));
    }

    private string GetSandwichDictionaryIteration(bool alreadyExist, int alphaIndex)
    {
        return alreadyExist ? $"+{_alpha[alphaIndex % _alpha.Length]}" : _alpha[alphaIndex % _alpha.Length].ToString();
    }
}