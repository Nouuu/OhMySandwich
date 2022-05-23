namespace OhMySandwich.models;

public readonly record struct IngredientStack(
    Ingredient Ingredient,
    double Count
);