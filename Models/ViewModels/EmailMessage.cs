using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
    }
}