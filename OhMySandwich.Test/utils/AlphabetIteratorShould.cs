using OhMySandwich.Infrastructure.utils;
using Xunit.Abstractions;

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
    public void return_a_single_letters_in_alphabet()
    {
        var letter = 'A';
        for (var i = 0; i < 26; i++)
        {
            Assert.Equal(letter.ToString(), _iterator.NextIteration());
            letter++;
        }
    }

    [Fact]
    public void return_double_letters_in_alphabet()
    {
        for (var i = 0; i < 26; i++)
        {
            _iterator.NextIteration();
        }
        Assert.Equal("AA",_iterator.NextIteration());
        Assert.Equal("AB",_iterator.NextIteration());
        for (var i = 0; i < 26; i++)
        {
            _iterator.NextIteration();
        }
        Assert.Equal("BC",_iterator.NextIteration());
    }
}