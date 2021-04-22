using EscalaPlantaoMedico.Core.Entidades;

namespace EscalaPlantaoMedico.Core.Servico.Contrato
{
    public interface IAssistenciaServico
    {
        int Salvar(Assistencia assistencia);

        int Editar(Assistencia assistencia);

        Assistencia ObterAssistenciaPorId(int id);

        void Deletar(int id);
    }
}
