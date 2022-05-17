﻿namespace OhMySandwich.models;

public readonly record struct Ingredient(
    string Name,
    UnitType UnitType
)
{
    public override string ToString()
    {
        return $"{{ Name = {Name}, UnitType = {UnitType.Value} }}";
    }
};