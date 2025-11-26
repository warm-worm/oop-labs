public class Animals
{
    private string _description = "Unnamed";

    public required string Description
    {
        get => _description;
        init => _description = Simulator.Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{_description} <{Size}>";

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
