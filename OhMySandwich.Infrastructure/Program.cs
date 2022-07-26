using OhMySandwich.Domain.config;
using OhMySandwich.Infrastructure.config;

namespace OhMySandwich.Infrastructure;

public static class Program
{
    public static void Main(string[] args)
    {
        
        Context context = new CliContext();
        var adapter = context.GetAdapter();

        adapter.AcceptInteractions();
    }
}