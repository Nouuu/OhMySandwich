using OhMySandwich.Infrastructure.config;

namespace OhMySandwich.Infrastructure;

public static class Program
{
    public static void Main(string[] args)
    {
        var context = new Context();
        var adapter = context.GetAdapter();

        adapter.AcceptInteractions();
    }
}