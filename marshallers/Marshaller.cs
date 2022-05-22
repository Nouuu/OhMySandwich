namespace OhMySandwich.marshallers;

public interface Marshaller<T>
{
    public String Serialize(T data);
}