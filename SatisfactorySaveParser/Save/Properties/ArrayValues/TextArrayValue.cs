﻿using System;
using System.IO;

using SatisfactorySaveParser.Save.Properties.Abstractions;

namespace SatisfactorySaveParser.Save.Properties.ArrayValues
{
    public class TextArrayValue : ITextPropertyValue, IArrayElement
    {
        public Type BackingType => typeof(TextEntry);

        public TextEntry Text { get; set; }

        public static TextArrayValue DeserializeArrayValue(BinaryReader reader)
        {
            return new TextArrayValue()
            {
                Text = TextProperty.ParseTextEntry(reader)
            };
        }

        public void ArraySerialize(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
