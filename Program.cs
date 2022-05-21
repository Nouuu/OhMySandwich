// See https://aka.ms/new-console-template for more information

using System.Text;
using OhMySandwich;
using OhMySandwich.config;
using OhMySandwich.models;

Console.OutputEncoding = Encoding.UTF8;

var context = new Context();

var invoiceGenerator = context.GetInvoiceGenerator();
var invoiceMarshaller = context.GetInvoiceMarshaller();
var sandwichMarshaller = context.GetSandwichMarshaller();

var butter = new Ingredient("Beurre", UnitType.Gram);
var ham = new Ingredient("Jambon", UnitType.Slice);
var chicken = new Ingredient("Poulet", UnitType.Slice);
var egg = new Ingredient("Oeufs", UnitType.SimpleUnit);
var bread = new Ingredient("Pain", UnitType.SimpleUnit);
var tomato = new Ingredient("Tomate", UnitType.SimpleUnit);
var salad = new Ingredient("Salade", UnitType.Gram);
var tuna = new Ingredient("Thon", UnitType.Gram);
var mayonnaise = new Ingredient("Mayonnaise", UnitType.Gram);

var sandwich1 = new SandwichBuilder()
    .SetName("Jambon beurre")
    .SetPrice(new Price("€", 3.5))
    .AddIngredient(bread, 1)
    .AddIngredient(ham, 1)
    .AddIngredient(butter, 10)
    .GetSandwich();

var sandwich2 = new SandwichBuilder()
    .SetName("Poulet crudités")
    .SetPrice(new Price("€", 5))
    .AddIngredient(bread, 1)
    .AddIngredient(egg, 1)
    .AddIngredient(tomato, 0.5)
    .AddIngredient(chicken, 1)
    .AddIngredient(mayonnaise, 10)
    .AddIngredient(salad, 10)
    .GetSandwich();


var sandwich3 = new SandwichBuilder()
    .SetName("Dieppois")
    .SetPrice(new Price("€", 4.5))
    .AddIngredient(bread, 1)
    .AddIngredient(tuna, 50)
    .AddIngredient(tomato, 0.5)
    .AddIngredient(mayonnaise, 10)
    .AddIngredient(salad, 10)
    .GetSandwich();


var sandwich4 = new SandwichBuilder()
    .SetName("croque monsieur")
    .SetPrice(7)
    .AddIngredient(bread, 2)
    .AddIngredient(salad, 2)
    .AddIngredient(ham, 1)
    .AddIngredient(butter, 20)
    .GetSandwich();

var sandwich5 = new SandwichBuilder()
    .SetName("low price")
    .SetPrice(new Price("€", 2))
    .AddIngredient(new IngredientStack(bread, 3))
    .AddIngredient(new IngredientStack(tomato, 2))
    .GetSandwich();


var basket = new Basket();

basket.AddSandwich(sandwich1);
basket.AddSandwich(sandwich2);
basket.AddSandwich(sandwich3);
basket.AddSandwich(sandwich4);
basket.AddSandwich(sandwich4);
basket.AddSandwich(sandwich4);
basket.AddSandwich(sandwich5);
basket.AddSandwich(sandwich1);

var invoice = invoiceGenerator.GenerateInvoice(basket);

Console.WriteLine(invoiceMarshaller.Serialize(invoice));