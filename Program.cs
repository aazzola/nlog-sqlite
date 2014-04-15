namespace aa.NLogSQlite
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SQLite;
    using System.IO;
    using NLog;

    class Program
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            EnsureDB();

            log.Info("Logging like a boss");
        }

        static void EnsureDB()
        {
            if (File.Exists("Log.db3"))
                return;

            using (SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["SQLite"].ToString()))
            using (SQLiteCommand command = new SQLiteCommand(
                "CREATE TABLE Log (Timestamp TEXT, Loglevel TEXT, Callsite TEXT, Message TEXT)",
                connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
