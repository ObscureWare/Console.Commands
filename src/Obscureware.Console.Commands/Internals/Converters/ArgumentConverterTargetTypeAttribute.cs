namespace ObscureWare.Console.Commands.Internals.Converters
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ArgumentConverterTargetTypeAttribute : Attribute
    {
        public Type TargetType { get; private set; }

        public ArgumentConverterTargetTypeAttribute(Type targetType)
        {
            this.TargetType = targetType;
        }
    }
}