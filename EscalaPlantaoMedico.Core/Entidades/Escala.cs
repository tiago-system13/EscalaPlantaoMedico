using System;

namespace EscalaPlantaoMedico.Core.Entidades
{
    public class Escala: BaseEntidade
    {

        public Escala(int atendimentoAssistencialId, DateTime dataEscala, string profissional, int id = 0) : base(id)
        {
            AtendimentoAssistencialId = atendimentoAssistencialId;
            DataEscala = dataEscala;
            Profissional = profissional;
        }

        public int AtendimentoAssistencialId { get; private set; }

        public DateTime DataEscala { get; private set; }

        public string Profissional { get; private set; }

        public AtendimentoAssistencial AtendimentoAssistencial { get; private set; }

    }
}
