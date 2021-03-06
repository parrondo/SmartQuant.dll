﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;

namespace SmartQuant
{
    public class Indicator : TimeSeries
    {
        protected ISeries input;
        protected bool calculate;

        public bool AutoUpdate { get; set; }

        public override int Count
        {
            get
            {
                Calculate();
                return base.Count;
            }
        }

        public override double First
        {
            get
            {
                Calculate();
                return base.First;
            }
        }

        public override double Last
        {
            get
            {
                Calculate();
                return base.Last;
            }
        }

        public override DateTime FirstDateTime
        {
            get
            {
                Calculate();
                return base.FirstDateTime;
            }
        }

        public override DateTime LastDateTime
        {
            get
            {
                Calculate();
                return base.LastDateTime;
            }
        }

        public override double this[int index]
        {
            get
            {
                Calculate();
                return base[index];
            }
        }

        public override double this[int index, BarData barData]
        {
            get
            {
                Calculate();
                return base[index, barData];
            }
        }

        public Indicator(ISeries input)
        {
            this.input = input;
            this.input.Indicators.Add(this);
            this.calculate = true;
        }

        public void Attach()
        {
            this.input.Indicators.Add(this);
        }

        public void Detach()
        {
            this.input.Indicators.Remove(this);
        }

        public override int GetIndex(DateTime datetime, IndexOption option = IndexOption.Null)
        {
            Calculate();
            return base.GetIndex(datetime, option);
        }

        public override DateTime GetDateTime(int index)
        {
            Calculate();
            return base.GetDateTime(index);
        }

        public override double GetMin(DateTime dateTime1, DateTime dateTime2)
        {
            Calculate();
            return base.GetMin(dateTime1, dateTime2);
        }

        public override double GetMax(DateTime dateTime1, DateTime dateTime2)
        {
            Calculate();
            return base.GetMax(dateTime1, dateTime2);
        }

        protected virtual void Init()
        {
        }

        protected virtual void Calculate()
        {
            // This should be done only once.
            if (!this.calculate)
                return;
            this.calculate = false;
            var indicator = this.input as Indicator;
            if (indicator != null)
                indicator.Calculate();
            // TODO: why this way?
            for (int i = 0; i < this.input.Count; ++i)
                Calculate(i);
        }

        internal void UpdateTo(int index)
        {
            if (this.calculate)
                Calculate();
            else
                Calculate(index);
        }

        public virtual void Calculate(int index)
        {
        }
    }
}
