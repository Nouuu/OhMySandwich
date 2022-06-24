using OhMySandwich.Infrastructure.utils;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace OhMySandwich.Test.utils;

public class AlphabetIteratorShould
{
    private readonly AlphabetIterator _iterator;
    ITestOutputHelper helper;
    

    public AlphabetIteratorShould(ITestOutputHelper helper)
    {
        this.helper = helper;
        _iterator = new AlphabetIterator();
    }
    
    [Fact]
    public void return_a_list_of_letters_in_alphabet()
    { for (var i = 0; i < 10000; i++)
        {
            // Test output helper
            helper.WriteLine(_iterator.NextIteration());
        }
    }
}