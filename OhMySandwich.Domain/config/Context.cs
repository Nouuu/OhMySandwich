using OhMySandwich.Domain.invoices;
using OhMySandwich.Domain.marshallers;
using OhMySandwich.Domain.models;
using OhMySandwich.Domain.ui;

namespace OhMySandwich.Domain.config;

public interface Context
{
    InvoiceGenerator GetInvoiceGenerator();
    IMarshaller<IngredientStack> GetIngredientMarshaller();
    IMarshaller<Invoice> GetInvoiceMarshaller();
    IMarshaller<Price> GetPriceMarshaller();
    IMarshaller<Sandwich> GetSandwichMarshaller();
    IMarshaller<Basket> GetBasketMarshaller();
    Basket GetBasket();
    List<ICommand> GetAvailableCommands();
    List<Sandwich> GetAvailableSandwichs();
    IAdapter GetAdapter();
}