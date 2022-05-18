// See https://aka.ms/new-console-template for more information

using System.Text;
using OhMySandwich.models;

Console.OutputEncoding = Encoding.UTF8;

var butter = new Ingredient("Beurre", UnitType.Gram);
var ham = new Ingredient("Jambon", UnitType.Slice);
var chicken = new Ingredient("Poulet", UnitType.Slice);
var egg = new Ingredient("Oeufs", UnitType.SimpleUnit);
var bread = new Ingredient("Pain", UnitType.SimpleUnit);
var tomato = new Ingredient("Tomate", UnitType.SimpleUnit);
var salad = new Ingredient("Salade", UnitType.Gram);
var tuna = new Ingredient("Thon", UnitType.Gram);
var mayonnaise = new Ingredient("Mayonnaise", UnitType.Gram);

var sandwich1 = new Sandwich(
    "Jambon beurre",
    new IngredientStack[]
    {
        new(bread, 1),
        new(ham, 1),
        new(butter, 10),
    },
    new Price("€", 3.5)
);
var sandwich2 = new Sandwich(
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
var sandwich3 = new Sandwich(
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

var basket = new Basket();

basket.AddSandwich(sandwich1);
basket.AddSandwich(sandwich2);
basket.AddSandwich(sandwich3);

Console.WriteLine(sandwich1 + "\n");
Console.WriteLine(sandwich2 + "\n");
Console.WriteLine(sandwich3 + "\n");
Console.WriteLine(basket.GetBasketPrice());