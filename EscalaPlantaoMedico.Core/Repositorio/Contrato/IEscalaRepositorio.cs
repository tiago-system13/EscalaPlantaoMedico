using EscalaPlantaoMedico.Core.Entidades;
using EscalaPlantaoMedico.Core.Repositorio.Base;
using System;

namespace EscalaPlantaoMedico.Core.Repositorio.Contrato
{
    public interface IEscalaRepositorio: IDisposable, IBaseRepositorio<Escala>
    {
        int Redestribuir(Escala escala);

        Escala ObterEscala(Escala escala);
    }
}
