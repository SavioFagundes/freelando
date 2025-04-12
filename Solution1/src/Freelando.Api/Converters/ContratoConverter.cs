using Freelando.Api.Requests;
using Freelando.Api.Responses;
using Freelando.Modelos;

namespace Freelando.Api.Converters;

public class ContratoConverter
{
    private ServicoConverter? _servicoConverter;
    private ProfissionalConverter? _profissionalConverter;
    public ContratoResponse EntityToResponse(Contrato? contrato)
    {
        _servicoConverter = new ServicoConverter();
        if (contrato == null)
        {
            return new ContratoResponse(Guid.Empty, 0.0, null, Guid.Empty, Guid.Empty);
        }

        return new ContratoResponse(contrato.Id, contrato.Valor, contrato.Vigencia, contrato.ServicoId, contrato.ProfissionalId);
    }

    public Contrato RequestToEntity(ContratoRequest? contratoRequest)
    {
        _profissionalConverter = new ProfissionalConverter();

        if (contratoRequest == null)
        {
            return new Contrato(Guid.Empty, 0.0, null, null, Guid.Empty);
        }

        return new Contrato(contratoRequest.Id, contratoRequest.Valor, contratoRequest.Vigencia, _servicoConverter.RequestToEntity(contratoRequest.Servico), contratoRequest.Profissional.Id);
    }

    public ICollection<ContratoResponse> EntityListToResponseList(IEnumerable<Contrato> contratos)
    {
        return (contratos == null)
            ? new List<ContratoResponse>()
            : contratos.Select(a => EntityToResponse(a)).ToList();
    }

    public ICollection<Contrato> RequestListToEntityList(IEnumerable<ContratoRequest> contratosRequests)
    {
        if (contratosRequests == null)
        {
            return new List<Contrato>();
        }

        return contratosRequests.Select(a => RequestToEntity(a)).ToList();
    }
}