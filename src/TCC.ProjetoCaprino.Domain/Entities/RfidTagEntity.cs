namespace TCC.ProjetoCaprino.Domain.Entities;

public class RfidTagEntity
{
    public Guid Id { get; set; }
    public string RfidTag { get; set; }

    internal void Update(string rfidTag)
    {
        RfidTag = rfidTag;
    }
}
