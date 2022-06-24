namespace OhMySandwich.Domain.utils;

public interface Iterator<out T>
{
    T NextIteration();
}