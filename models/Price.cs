namespace OhMySandwich.models;

public readonly record struct Price(
    string Currency,
    double Value
)
{
    public override string ToString()
    {
        return $"{{Currency = {Currency}, Value={Value}}}";
    }
};