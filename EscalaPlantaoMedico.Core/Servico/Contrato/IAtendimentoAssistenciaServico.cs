using EscalaPlantaoMedico.Core.Entidades;

namespace EscalaPlantaoMedico.Core.Servico.Contrato
{
    public interface IAtendimentoAssistenciaServico
    {
        int Salvar(AtendimentoAssistencial atendimentoAssistencial);

        int Editar(AtendimentoAssistencial atendimentoAssistencial);

        AtendimentoAssistencial ObterAtendimentoAssistencialPorId(int id);
    }
}
