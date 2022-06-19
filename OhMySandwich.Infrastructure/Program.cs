using OhMySandwich.Infrastructure.config;

namespace OhMySandwich.Infrastructure;

public static class Program
{
    public static void Main(string[] args)
    {
        var context = new CliContext();
        var adapter = context.GetAdapter();

        adapter.AcceptInteractions();
    }
}