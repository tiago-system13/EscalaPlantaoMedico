using EscalaPlantaoMedico.Core.Entidades;

namespace EscalaPlantaoMedico.Core.Servico.Contrato
{
    public interface IEscalaServico
    {
        int Salvar(Escala escala);
        int Redestribuir(Escala escala);

        Escala ObterEscala(Escala escala);

    }
}
