using EscalaPlantaoMedico.Core.Entidades;
using EscalaPlantaoMedico.Core.Repositorio.Base;

namespace EscalaPlantaoMedico.Core.Repositorio.Contrato
{
    public interface IEscalaRepositorio: IBaseRepositorio<Escala>
    {
        int Redestribuir(Escala escala);

        Escala ObterEscala(Escala escala);
    }
}
