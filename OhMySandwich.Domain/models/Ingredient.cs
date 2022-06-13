namespace OhMySandwich.Domain.models;

public readonly record struct Ingredient(
    string Name,
    UnitType UnitType
);