namespace OhMySandwich.Domain.models;

public readonly record struct Price(
    string Currency,
    double Value
);