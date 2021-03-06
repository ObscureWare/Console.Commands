namespace ObscureWare.Console.Commands.Internals.Converters
{
    using System.Globalization;

    [ArgumentConverterTargetType(typeof(bool))]
    internal class BoolArgumentConverter : ArgumentConverter
    {
        /// <inheritdoc />
        public override object TryConvert(string argumentText, CultureInfo culture)
        {
            return bool.Parse(argumentText);
        }
    }
}