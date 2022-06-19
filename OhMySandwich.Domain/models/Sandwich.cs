namespace OhMySandwich.Domain.models;

public readonly record struct Sandwich(
    string Name,
    IngredientStack[] Ingredients,
    Price Price
);