﻿namespace Obscureware.Console.Commands.Model
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CommandOptionCustomValueSwitchAttribute : Attribute
    {
        /// <summary>
        /// Gets strings / letters that will enable this flag.
        /// </summary>
        public string[] CommandLiterals { get; private set; }

        public CommandOptionCustomValueSwitchAttribute(params string[] commandLiterals)
        {
            this.CommandLiterals = commandLiterals;
        }
    }

    // TODO: perhaps allow default value as well?
}