namespace OhMySandwich.models;

public readonly record struct Invoice(
    List<Sandwich> Sandwiches,
    Price Price
);