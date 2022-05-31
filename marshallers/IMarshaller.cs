namespace OhMySandwich.marshallers;

public interface IMarshaller<T>
{
    public string Serialize(T data);
}