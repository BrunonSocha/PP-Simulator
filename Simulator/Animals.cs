namespace Simulator;

public class Animals
{
    private string description;
    public required string Description 
    { 
        get => description; 
        init
        {
            string newDescription = value.Trim();

            if (string.IsNullOrEmpty(newDescription))
            {
                newDescription = "Unknown";
            }

            if (newDescription.Length > 15)
            {
                newDescription = newDescription.Substring(0, 15).Trim();
            }

            if (newDescription.Length < 3)
            {
                newDescription = newDescription.PadRight(3, '#');
            }

            if (char.IsLower(newDescription[0]))
            {
                newDescription = char.ToUpper(newDescription[0]) + newDescription.Substring(1);
            }

            description = newDescription;
        } 
    }
    public uint Size { get; set; } = 3;
    
    public string Info => $"{Description} <{Size}>";
}
