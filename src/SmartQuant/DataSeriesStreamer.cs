﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.IO;

namespace SmartQuant
{
    public class DataSeriesStreamer : ObjectStreamer
    {
        public DataSeriesStreamer()
        {
            this.typeId = ObjectType.DataSeries;
            this.type = typeof(DataSeries);
        }

        public override object Read(BinaryReader reader)
        {
            return new DataSeries(reader);
        }

        public override void Write(BinaryWriter writer, object obj)
        {
            (obj as DataSeries).Write(writer);
        }
    }
}