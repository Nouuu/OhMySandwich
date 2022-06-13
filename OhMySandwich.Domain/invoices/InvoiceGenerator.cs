using OhMySandwich.Domain.models;

namespace OhMySandwich.Domain.invoices;

public interface InvoiceGenerator
{
    Invoice GenerateInvoice(Basket basket);
}