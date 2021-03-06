﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.IO;

namespace SmartQuant
{
    public class ByteStreamer : ObjectStreamer
    {
        public ByteStreamer()
        {
            this.typeId = DataObjectType.Byte;
            this.type = typeof(byte);
        }

        public override object Read(BinaryReader reader)
        {
            return reader.ReadByte();
        }

        public override void Write(BinaryWriter writer, object obj)
        {
            writer.Write((byte)obj);
        }
    }
}