using Npgsql;
using System.Data.Common;
using System.Diagnostics;

namespace EtlaToolPicker.EtlaToolbelt.Postgres;

public class PostgresBase : IPostgresBase
{

    // These will all be set after the object has been Instantiated so null! is OK and removes irrelevant compiler warnings
    protected string Host { get; set; } = "127.0.0.1";
    protected ushort Port { get; set; } = 5432;
    protected string Db { get; set; } = null!;
    protected string User { get; set; } = null!;
    protected string Pw { get; set; } = null!;

    public PostgresBase()
    {
        // Mandatory
        Db = CmdLine.GetSwitch("Db") ?? "";
        if (Db.IsWhite())
        {
            var msg = $"Failed to get a valid database name for the database connection"; Log.Fatal(msg); throw new Exception(msg);
        }

        // Optional
        Host = CmdLine.GetSwitch("Host") ?? "127.0.0.1";
        if (ushort.TryParse(CmdLine.GetSwitch("Port"), out ushort port)) { Port = port; } else { Port = 5432; }
        User = CmdLine.GetSwitch("User") ?? $"{Db}_loader";
    }

    public void Init(object initialisationData)
    {
        Pw = initialisationData as string ?? "";
    }

    public DbConnection Connect()
    {
        // The timeout to use for this connection can be set on the command line, defaulting to 600seconds (10 mins)
        var timeoutSwitch = CmdLine.GetSwitch("Timeout");
        if (timeoutSwitch == null || !int.TryParse(timeoutSwitch, out int timeout)) { timeout = 600; }

        NpgsqlConnectionStringBuilder builder = new()
        {
            Host = Host,
            Port = Port,
            Database = Db,
            Username = User,
            Password = Pw,
            CommandTimeout = timeout,
            IncludeErrorDetail = true,
            //TrustServerCertificate = true, // Apparently obsolete
            SslMode = Host == "127.0.0.1" ? SslMode.Prefer : SslMode.Require
        };
        Log.Info($"{DateTime.Now:HH:mm:ss}: Connecting to {Host}");
        var cnnn = new NpgsqlConnection(builder.ConnectionString);
        cnnn.Notice += Cnnn_Notice;
        return cnnn;
    }

    private void Cnnn_Notice(object sender, NpgsqlNoticeEventArgs e)
    {
        Log.Info($"{DateTime.Now:HH:mm:ss}: {e.Notice.MessageText}");
        Trace.WriteLine($"{DateTime.Now:HH:mm:ss}: {e.Notice.MessageText}");
        if (Environment.UserInteractive) { Console.Write(","); }
    }
}
