namespace ObscureWare.Console.Commands.Styles
{
    using ObscureWare.Console;

    public interface ICommonStyles
    {
        ConsoleFontColor Warning { get; set; }

        ConsoleFontColor Error { get; set; }

        ConsoleFontColor Default { get; set; }

        ConsoleFontColor OddRowColor { get; }

        ConsoleFontColor EvenRowColor { get; }
    }
}