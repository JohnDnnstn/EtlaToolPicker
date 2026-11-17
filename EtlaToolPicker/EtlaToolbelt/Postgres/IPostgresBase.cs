using System.Data.Common;

namespace EtlaToolPicker.EtlaToolbelt.Postgres;

public interface IPostgresBase
{
    void Init(object initialisationData);
    DbConnection Connect();
}
