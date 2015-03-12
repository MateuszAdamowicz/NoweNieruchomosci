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
    [ExcludeFromCodeCoverage]
    public class SelectOptionIntValue
    {
        public SelectOptionIntValue(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public int Value { get; set; }
    }
}