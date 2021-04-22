using EscalaPlantaoMedico.Core.Entidades;
using EscalaPlantaoMedico.Core.Repositorio.Contrato;
using EscalaPlantaoMedico.Data.Base;
using EscalaPlantaoMedico.Data.Contexto;

namespace EscalaPlantaoMedico.Data.Repositorio
{
    public class AtendimentoAssistenciaRepositorio : BaseRepositorio<AtendimentoAssistencial>, IAtendimentoAssistenciaRepositorio
    {
        private readonly EscalaContexto _contexto;

        public AtendimentoAssistenciaRepositorio(EscalaContexto contexto): base(contexto)
        {
            _contexto = contexto;
        } 
    }
}
