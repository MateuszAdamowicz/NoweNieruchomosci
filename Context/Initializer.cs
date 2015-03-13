using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Context
{
    [ExcludeFromCodeCoverage]
    public class Initializer : MigrateDatabaseToLatestVersion<NieruchomosciContext, Configuration>
    {

    }
}