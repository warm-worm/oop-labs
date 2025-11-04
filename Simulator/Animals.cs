namespace Simulator;

public class Animals
{
    private string _description = "Unnamed"; //wartosc domyslna zeby uniknac ostrzezenia kompilatora

    public required string Description
    {
        get { return _description; }
        init //bo ma dzialac tylko przy inicjalizacji
        {
            string processedDesc = value;

            if (string.IsNullOrWhiteSpace(processedDesc))
            {
                processedDesc = "###";
            }
            else
            {
                processedDesc = processedDesc.Trim();
            }

            if (processedDesc.Length > 15) //max 15 znakow
            {
                processedDesc = processedDesc.Substring(0, 15);
                processedDesc = processedDesc.TrimEnd();
            }

            while (processedDesc.Length < 3) //min 3 znaki
            {
                processedDesc += "#";
            }

            if (char.IsLower(processedDesc[0])) //pierwsza wielka litera
            {
                processedDesc = char.ToUpper(processedDesc[0]) + processedDesc.Substring(1);
            }

            _description = processedDesc;
        }
    }

    public uint Size { get; set; } = 3;

    public string Info
    {
        get { return $"{_description} <{Size}>"; }
    }
}