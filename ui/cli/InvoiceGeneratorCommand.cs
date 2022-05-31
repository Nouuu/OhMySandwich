using OhMySandwich.invoices;
using OhMySandwich.marshallers;
using OhMySandwich.models;

namespace OhMySandwich.ui.cli;

public class InvoiceGeneratorCommand : Command
{
    private readonly Basket _basket;
    private readonly Marshaller<Invoice> _invoiceMarshaller;
    private readonly InvoiceGenerator _invoiceGenerator;

    public InvoiceGeneratorCommand(Basket basket, InvoiceGenerator invoiceGenerator,
        Marshaller<Invoice> invoiceMarshaller)
    {
        _basket = basket;

        _invoiceGenerator = invoiceGenerator;
        _invoiceMarshaller = invoiceMarshaller;
    }

    public Command? Execute()
    {
        var invoice = _invoiceGenerator.GenerateInvoice(_basket);
        Console.WriteLine(
            _invoiceMarshaller.Serialize(invoice) +
            "\n--------------------------------------"
        );
        return null;
    }

    public string GetCommandHelp()
    {
        return "Generate invoice";
    }

    public void Display()
    {
        Console.WriteLine(
            "Generating invoice..." +
            "\n--------------------------------------"
        );
    }
}