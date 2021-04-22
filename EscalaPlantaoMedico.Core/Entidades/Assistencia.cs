using System.Collections.Generic;

namespace EscalaPlantaoMedico.Core.Entidades
{
    public class Assistencia: BaseEntidade
    {
        public Assistencia(string nome, int nivelAtendimento, int id=0): base(id)
        {

        }

        public string Nome { get; private set; }

        public int NivelAtendimento { get; private set; }

        public List<AtendimentoAssistencial> AtendimentosAssistenciais { get; set; }
    }
}
