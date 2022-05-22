using OhMySandwich.models;

namespace OhMySandwich.invoices;

public interface InvoiceGenerator
{
    Invoice GenerateInvoice(Basket basket);
}
