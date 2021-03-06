﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePropertyParser.cs" company="Obscureware Solutions">
// MIT License
//
// Copyright(c) 2016 Sebastian Gruchacz
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// </copyright>
// <summary>
//   Defines the BasePropertyParser class - for all command model options parsers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ObscureWare.Console.Commands.Internals.Parsers
{
    using System;
    using System.Reflection;
    using Model;

    using ObscureWare.Console.Commands;

    internal abstract class BasePropertyParser
    {
        public PropertyInfo TargetProperty { get; private set; }

        protected BasePropertyParser(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            this.TargetProperty = propertyInfo;
        }

        public IParsingResult Apply(ICommandParserOptions options, CommandModel model, string[] args, ref int argIndex)
        {
            if (model.GetType() != this.TargetProperty.DeclaringType)
            {
                throw new InvalidOperationException("Incompatible model type.");
            }

            return this.DoApply(options, model, args, ref argIndex);
        }

        protected abstract IParsingResult DoApply(ICommandParserOptions options, CommandModel model, string[] args, ref int argIndex);
    }
}