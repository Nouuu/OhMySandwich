namespace OhMySandwich.Domain.marshallers;

public interface IMarshaller<in T>
{
    public string Serialize(T data);
}