//using Cepedi.ProjetoRFID.Domain.Entities;
namespace TCC.ProjetoCaprino.Shared.Responses.Readout;

public record ReturnReadoutResponse(Guid Id, DateTime ReadoutDate, List<string> Tags);