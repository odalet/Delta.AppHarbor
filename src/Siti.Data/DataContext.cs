using System.Diagnostics;
using System.Data.Entity;

namespace Siti.Data
{
    public class DataContext : DbContext
    {
        private const bool defaultSqlLoggingEnabled = 
#if DEBUG
            true;
#else
            false;
#endif

        public DataContext(bool enableSqlLogging = defaultSqlLoggingEnabled)
            : base("name=SitiDatabase")
        {
            // No lazy loading
            // See http://code.msdn.microsoft.com/Loop-Reference-handling-in-caaffaf7
            base.Configuration.LazyLoadingEnabled = false;
            // No proxies?
            base.Configuration.ProxyCreationEnabled = false;

            // Initialize EF's generated SQL logging
            if (enableSqlLogging) base.Database.Log = message =>
            {
                // reformat message (too many cr/lf)

                // First remove starting and trailing cr/lf
                message = message.Trim('\r', '\n');

                // if message is empty do not log
                if (string.IsNullOrWhiteSpace(message)) return;

                // if message is only one line long, we're done; otherwise, add a starting cr/lf
                if (message.Contains("\r\n"))
                    message = "\r\n" + message;

                // Then log
                Debug.WriteLine("EF: " + message);
            };

            Database.SetInitializer(new DataInitializer());
        }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Fingerprint> Fingerprints { get; set; }
    }
}
