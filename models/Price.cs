namespace OhMySandwich.models;

public readonly record struct Price(
    string Currency,
    double Value
);