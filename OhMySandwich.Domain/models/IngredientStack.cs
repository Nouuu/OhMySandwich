namespace OhMySandwich.Domain.models;

public readonly record struct IngredientStack(
    Ingredient Ingredient,
    double Count
);