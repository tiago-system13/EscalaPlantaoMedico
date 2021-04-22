namespace EscalaPlantaoMedico.Core.Entidades
{
    public class BaseEntidade
    {
        public int Id { get; private set; }

        public BaseEntidade(int id)
        {
            Id = id;
        }
    }
}
