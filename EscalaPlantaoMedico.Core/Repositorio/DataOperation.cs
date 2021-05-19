using EscalaPlantaoMedico.Core.Enum;

namespace EscalaPlantaoMedico.Core.Repositorio
{
    public class DataOperation
    {
        public static DataOperation EscalaRead { get; private set; }

        public static DataOperation EscalaWrite { get; private set; }

        public OperationType Type { get; private set; }

        public DataSource Source { get; private set; }

        static DataOperation()
        {
            EscalaRead = new DataOperation(DataSource.EscalaMedica, OperationType.Read);
        }

        public DataOperation(DataSource source, OperationType type)
        {
            Source = source;
            Type = type;
        }
    }
}
