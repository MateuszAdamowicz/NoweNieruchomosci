using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class SelectOption
    {
        public SelectOption(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}