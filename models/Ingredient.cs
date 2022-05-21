namespace OhMySandwich.models;

public readonly record struct Ingredient(
    string Name,
    UnitType UnitType
);