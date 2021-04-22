using EscalaPlantaoMedico.Core.Entidades;
using EscalaPlantaoMedico.Core.Repositorio.Contrato;
using EscalaPlantaoMedico.Data.Base;
using EscalaPlantaoMedico.Data.Contexto;
using System;

namespace EscalaPlantaoMedico.Data.Repositorio
{
    public class EscalaRepositorio : BaseRepositorio<Escala>,IEscalaRepositorio
    {
        private readonly EscalaContexto _contexto;

        public EscalaRepositorio(EscalaContexto contexto): base(contexto)
        {
            _contexto = contexto ?? throw new ArgumentException(nameof(contexto));
        }

        public Escala ObterEscala(Escala escala)
        {
            throw new NotImplementedException();
        }

        public int Redestribuir(Escala escala)
        {
            throw new NotImplementedException();
        }
    }
}
