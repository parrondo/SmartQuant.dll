﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.Collections;

namespace SmartQuant
{
    public class EventSortedSet : IEnumerable
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public EventSortedSet()
        {
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Event this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Event e)
        {
        }

        public void Clear()
        {
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

