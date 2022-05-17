// See https://aka.ms/new-console-template for more information

using System.Collections;
using OhMySandwich.models;

Ingredient butter = new Ingredient("Beurre", UnitType.Gram);
Ingredient ham = new Ingredient("Jambon", UnitType.Slice);
Ingredient chicken = new Ingredient("Poulet", UnitType.Slice);
Ingredient egg = new Ingredient("Oeufs", UnitType.None);
Ingredient bread = new Ingredient("Pain", UnitType.None);
Ingredient tomato = new Ingredient("Tomate", UnitType.None);
Ingredient salad = new Ingredient("Salade", UnitType.Gram);
Ingredient tuna = new Ingredient("Thon", UnitType.Gram);
Ingredient mayonnaise = new Ingredient("Mayonnaise", UnitType.Gram);

Sandwich sandwich1 = new Sandwich(
    "Jambon beurre",
    new IngredientStack[]
    {
        new(bread, 1),
        new(ham, 1),
        new(butter, 10),
    },
    new Price("€", 3.5)
);
Sandwich sandwich2 = new Sandwich(
    "Poulet crudités",
    new IngredientStack[]
    {
        new(bread, 1),
        new(egg, 1),
        new(tomato, 0.5),
        new(chicken, 1),
        new(mayonnaise, 10),
        new(salad, 10)
    },
    new Price("€", 5)
);
Sandwich sandwich3 = new Sandwich(
    "Dieppois",
    new IngredientStack[]
    {
        new(bread, 1),
        new(tuna, 50),
        new(tomato, 0.5),
        new(mayonnaise, 10),
        new(salad, 10),
    },
    new Price("€", 4.5)
);
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine(sandwich1);
Console.WriteLine(sandwich2);
Console.WriteLine(sandwich3);