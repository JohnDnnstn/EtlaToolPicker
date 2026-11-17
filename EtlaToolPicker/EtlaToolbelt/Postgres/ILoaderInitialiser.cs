namespace EtlaToolPicker.EtlaToolbelt.Postgres;

/// <summary>Provides a generic mechanism for the initialisation of a specific style of database connection
/// Current implementations:
/// * Initialiser in EpicInitialisation
/// </summary>
public interface ILoaderInitialiser
{
    /// <summary>An implementation-specific object that can be used as part of the process of connecting to a database</summary>
    /// <returns>Implementation-specific</returns>
    object GetInitialisation(string? p = null);
}

