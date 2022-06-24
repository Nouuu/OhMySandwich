using System.Text;
using OhMySandwich.Domain.utils;

namespace OhMySandwich.Infrastructure.utils;

public class AlphabetIterator : Iterator<string>
{
    private readonly char[] _alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private int _currentIndex = 0;


    public string NextIteration()
    {
        var iteration = new StringBuilder();
        var tempIndex = _currentIndex;
        tempIndex -= _currentIndex % _alpha.Length;
        while (tempIndex >= _alpha.Length)
        {
            iteration.Append(_alpha[((tempIndex / _alpha.Length) - 1) % _alpha.Length]);
            tempIndex -= _alpha.Length * Math.Min(tempIndex / _alpha.Length, _alpha.Length);
        }

        iteration.Append(_alpha[_currentIndex % _alpha.Length]);        
        _currentIndex++;
        return iteration.ToString();
    }
}