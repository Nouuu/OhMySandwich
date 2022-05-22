namespace OhMySandwich.models;

public readonly record struct Invoice(
    Dictionary<Sandwich, string> Sandwiches,
    Dictionary<string, Price> Prices
);