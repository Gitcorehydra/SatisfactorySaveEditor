﻿using SatisfactorySaveParser.Fields;
using System;
using System.Collections.Generic;
using System.IO;

namespace SatisfactorySaveParser.Fields
{
    public class SerializedFields
    {
        public static SerializedFields None = new SerializedFields();

        public List<ISerializedField> Fields { get; set; } = new List<ISerializedField>();

        public static SerializedFields Parse(int length, BinaryReader reader)
        {
            var start = reader.BaseStream.Position;
            var result = new SerializedFields();

            while (true)
            {
                var fieldName = reader.ReadLengthPrefixedString();
                if (fieldName == "None")
                {
                    break;
                }

                var fieldType = reader.ReadLengthPrefixedString();
                //var size = reader.ReadInt32();

                switch (fieldType)
                {
                    case "ArrayProperty":
                        result.Fields.Add(ArrayProperty.Parse(fieldName, reader));
                        break;
                    case "FloatProperty":
                        result.Fields.Add(FloatProperty.Parse(fieldName, reader));
                        break;
                    case "IntProperty":
                        result.Fields.Add(IntProperty.Parse(fieldName, reader));
                        break;
                    case "EnumProperty":
                        result.Fields.Add(EnumProperty.Parse(fieldName, reader));
                        break;
                    case "BoolProperty":
                        result.Fields.Add(BoolProperty.Parse(fieldName, reader));
                        break;
                    case "StrProperty":
                        result.Fields.Add(StrProperty.Parse(fieldName, reader));
                        break;
                    case "NameProperty":
                        result.Fields.Add(NameProperty.Parse(fieldName, reader));
                        break;
                    case "ObjectProperty":
                        result.Fields.Add(ObjectProperty.Parse(fieldName, reader));
                        break;
                    default:
                        throw new NotImplementedException(fieldType);
                }

            }

            var int1 = reader.ReadInt32();
            if (start + length - reader.BaseStream.Position == 4)
            //if(result.Fields.Count > 0)
            {
                var int2 = reader.ReadInt32();
            }
            else if (start + length - reader.BaseStream.Position > 4)
            {
                var int2 = reader.ReadInt32();
                var str2 = reader.ReadLengthPrefixedString();
                var str3 = reader.ReadLengthPrefixedString();
            }


            return result;
        }
    }
}
