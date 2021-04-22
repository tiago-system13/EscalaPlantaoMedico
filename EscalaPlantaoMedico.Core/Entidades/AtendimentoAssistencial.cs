using System;
using System.Collections.Generic;

namespace EscalaPlantaoMedico.Core.Entidades
{
    public class AtendimentoAssistencial: BaseEntidade
    {
        public AtendimentoAssistencial(int assistenciaId, string identificacaoLeito, int pesoAtendimento, DateTime dataAtendimento, int id = 0) : base(id)
        {
            AssistenciaId = assistenciaId;
            IdentificacaoLeito = identificacaoLeito;
            PesoAtendimento = pesoAtendimento;
            DataAtendimento = dataAtendimento;
        }

        public int AssistenciaId { get; private set; }

        public string IdentificacaoLeito { get; private set; }

        public int PesoAtendimento { get; private set; }

        public DateTime DataAtendimento { get; private set; }

        public List<Escala> Escalas { get; private set; }

        public Assistencia Assistencia { get; set; }

    }
}
