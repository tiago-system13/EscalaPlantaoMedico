using EscalaPlantaoMedico.Core.Entidades;
using EscalaPlantaoMedico.Core.Repositorio.Contrato;
using EscalaPlantaoMedico.Data.Base;
using EscalaPlantaoMedico.Data.Contexto;
using System;

namespace EscalaPlantaoMedico.Data.Repositorio
{
    public class AssistenciaRepositorio :  BaseRepositorio<Assistencia>,  IAssistenciaRepositorio
    {
        private readonly EscalaContexto _contexto;
        public AssistenciaRepositorio(EscalaContexto contexto) : base(contexto)
        {
            _contexto = contexto ?? throw new ArgumentException(nameof(contexto));

        }
       
    }
}
