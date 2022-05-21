using OhMySandwich.invoices;

namespace OhMySandwich.config;

public class Context
{
    private InvoiceGenerator? _singletonInvoiceGenerator;

    public InvoiceGenerator GetInvoiceGenerator()
    {
        return _singletonInvoiceGenerator ??= new DefaultInvoiceGenerator();
    }
}