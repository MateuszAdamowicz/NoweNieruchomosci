using System.Data.Entity;

namespace Context
{
    public class Initializer : MigrateDatabaseToLatestVersion<NieruchomosciContext, Configuration>
    {

    }
}