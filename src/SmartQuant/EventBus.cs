// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;

namespace SmartQuant
{
    public class EventBus
    {
        private Framework framework;

        public EventBusMode Mode { get; set; }

        public EventPipe DataPipe { get; private set; }

        public EventPipe ExecutionPipe { get; private set; }

        public EventPipe HistoricalPipe  { get; private set; }

        public EventPipe ServicePipe  { get; private set; }

        public EventBus(Framework framework, EventBusMode mode = EventBusMode.Simulation)
        {
            this.framework = framework;
            this.Mode = mode;
            this.DataPipe = new EventPipe(framework);
            this.ExecutionPipe = new EventPipe(framework);
            this.HistoricalPipe = new EventPipe(framework);
            this.ServicePipe = new EventPipe(framework);
        }

        public void Attach(EventBus bus)
        {
            throw new NotImplementedException();
        }

        public Event Dequeue()
        {
            throw new NotImplementedException();
        }

        public void ResetCounts()
        {
        }

        public void Clear()
        {
            DataPipe.Clear();
            ExecutionPipe.Clear();
            ExecutionPipe.Clear();
            ServicePipe.Clear();
        }
    }
}
