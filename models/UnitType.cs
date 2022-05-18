namespace OhMySandwich.models;

public class UnitType
{
    private UnitType(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }
    
    public static UnitType SimpleUnit { get { return new UnitType(" "); } }
    public static UnitType Gram { get { return new UnitType("g "); } }
    public static UnitType Liter { get { return new UnitType("l "); } }
    public static UnitType Slice { get { return new UnitType(" tranche de "); } }
}