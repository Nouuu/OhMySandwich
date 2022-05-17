namespace OhMySandwich.models;

public readonly record struct IngredientStack(
    Ingredient ingredient,
    double count
);