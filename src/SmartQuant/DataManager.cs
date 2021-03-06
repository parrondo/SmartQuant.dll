// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace SmartQuant
{
    public class DataManager
    {
        private Framework framework;
        private Thread thread;
        private volatile bool exit;
        private bool disposed;

        public DataServer Server { get; private set; }

        public DataManager(Framework framework, DataServer dataServer)
        {
            this.framework = framework;
            Server = dataServer;
            Server.Open();
            this.thread = new Thread(new ThreadStart(Run));
            this.thread.Name = "Data Manager Thread";
            this.thread.IsBackground = true;
            this.thread.Start();
            while(!this.thread.IsAlive)
                Thread.Sleep(1);
        }

        private void Run()
        {
            Console.WriteLine("{0} Data manager thread started: Framework = {1}  Clock = {2}", DateTime.Now,this.framework.Name , this.framework.Clock.GetModeAsString());
            while (!this.exit)
                Thread.Sleep(10);
            Console.WriteLine("{0} Data manager thread stopped: Framework = {1}  Clock = {2}", DateTime.Now,this.framework.Name , this.framework.Clock.GetModeAsString());

        }

        public void Dump()
        {
        }

        internal void Save(BinaryWriter writer)
        {
        }

        internal void Load(BinaryReader reader)
        {
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public DataSeries AddDataSeries(Instrument instrument, byte type)
        {
            return Server.AddDataSeries(instrument, type);
        }

        public DataSeries AddDataSeries(string name)
        {
            return Server.AddDataSeries(name);
        }

        public DataSeries GetDataSeries(string symbol, byte type, BarType barType = BarType.Time, long barSize = 60)
        {
            return GetDataSeries(this.framework.InstrumentManager.Instruments[symbol], type, barType, barSize);
        }

        public DataSeries GetDataSeries(Instrument instrument, byte type, BarType barType = BarType.Time, long barSize = 60)
        {
            return Server.GetDataSeries(instrument, type, barType, barSize);
        }

        public DataSeries GetDataSeries(string name)
        {
            return Server.GetDataSeries(name);
        }

        public TimeSeries AddTimeSeries(string name)
        {
            return new TimeSeries(Server.AddDataSeries(name));
        }

        public TimeSeries GetTimeSeries(string name)
        {
            return new TimeSeries(Server.GetDataSeries(name));
        }

        public List<DataSeries> GetDataSeriesList(Instrument instrument = null, string pattern = null)
        {
            return Server.GetDataSeriesList(instrument, pattern);
        }

        public void DeleteDataSeries(Instrument instrument, byte type, BarType barType = BarType.Time, long barSize = 60)
        {
        }

        public void DeleteDataSeries(string symbol, byte type, BarType barType = BarType.Time, long barSize = 60)
        {
        }

        public void DeleteDataSeries(string name)
        {
            Server.DeleteDataSeries(name);
        }

        public void Save(BarSeries series, SaveMode option = SaveMode.Add)
        {
            for (int i = 0; i < series.Count; ++i)
                Save((Bar)series[i], option);
        }

        public void Save(TickSeries series, SaveMode option = SaveMode.Add)
        {
            foreach (var s in series)
                Save(s, option);
        }

        public void Save(Tick tick, SaveMode option = SaveMode.Add)
        {
            Save(tick.InstrumentId, tick, option);
        }

        public void Save(Bar bar, SaveMode option = SaveMode.Add)
        {
            Save(bar.InstrumentId, bar, option);
        }

        public void Save(Level2 level2, SaveMode option = SaveMode.Add)
        {
            Save(level2.InstrumentId, level2, option);
        }

        public void Save(Level2Snapshot level2, SaveMode option = SaveMode.Add)
        {
            Save(level2.InstrumentId, level2, option);
        }

        public void Save(Level2Update level2, SaveMode option = SaveMode.Add)
        {
            Save(level2.InstrumentId, level2, option);
        }

        public void Save(Fundamental fundamental, SaveMode option = SaveMode.Add)
        {
            Save(fundamental.InstrumentId, fundamental, option);
        }

        public void Save(News news, SaveMode option = SaveMode.Add)
        {
            Save(news.InstrumentId, news, option);
        }

        public void Save(Instrument instrument, DataObject obj, SaveMode option = SaveMode.Add)
        {
        }

        public void Save(int instrumentId, DataObject obj, SaveMode option = SaveMode.Add)
        {
        }

        public void Save(string symbol, DataObject obj, SaveMode option = SaveMode.Add)
        {
        }

        public void Save(Instrument instrument, IDataSeries series, SaveMode option = SaveMode.Add)
        {
        }

        public Bid GetBid(Instrument instrument)
        {
            return null;
        }

        public Bid GetBid(int instrumentId)
        {
            throw new NotImplementedException();
        }

        public Ask GetAsk(Instrument instrument)
        {   
            throw new NotImplementedException();
        }

        public Ask GetAsk(int instrumentId)
        {
            throw new NotImplementedException();
        }

        public Trade GetTrade(Instrument instrument)
        {
            throw new NotImplementedException();
        }

        public Trade GetTrade(int instrumentId)
        {
            return null;
        }

        public Bar GetBar(Instrument instrument)
        {
            throw new NotImplementedException();
        }

        public Bar GetBar(int instrumentId)
        {
            throw new NotImplementedException();
        }

        public OrderBook GetOrderBook(Instrument instrument)
        {
            throw new NotImplementedException();
        }

        public OrderBook GetOrderBook(int instrumentId)
        {
            throw new NotImplementedException();
        }

        public TickSeries GetHistoricalTicks(TickType type, string symbol, DateTime dateTime1, DateTime dateTime2)
        {
            return null;
        }

        public TickSeries GetHistoricalBids(string symbol, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(TickType.Bid, symbol, dateTime1, dateTime2);
        }

        public TickSeries GetHistoricalAsks(string symbol, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(TickType.Ask, symbol, dateTime1, dateTime2);
        }

        public TickSeries GetHistoricalTrades(string symbol, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(TickType.Trade, symbol, dateTime1, dateTime2);
        }

        public TickSeries GetHistoricalTicks(TickType type, Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            throw new NotImplementedException();
        }

        public TickSeries GetHistoricalBids(Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(TickType.Bid, instrument, dateTime1, dateTime2);
        }

        public TickSeries GetHistoricalAsks(Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(TickType.Ask, instrument, dateTime1, dateTime2);
        }

        public TickSeries GetHistoricalTrades(Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(TickType.Trade, instrument, dateTime1, dateTime2);
        }

        public TickSeries GetHistoricalTrades(string provider, Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            return null;
        }

        public TickSeries GetHistoricalTrades(string provider, string symbol, DateTime dateTime1, DateTime dateTime2)
        {
            throw new NotImplementedException();
        }

        public TickSeries GetHistoricalBids(string provider, string symbol, DateTime dateTime1, DateTime dateTime2)
        {
            throw new NotImplementedException();
        }

        public TickSeries GetHistoricalAsks(string provider, string symbol, DateTime dateTime1, DateTime dateTime2)
        {
            throw new NotImplementedException();
        }

        public TickSeries GetHistoricalTicks(IHistoricalDataProvider provider, TickType type, Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            throw new NotImplementedException();
        }

        public TickSeries GetHistoricalTrades(IHistoricalDataProvider provider, Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(provider, TickType.Trade, instrument, dateTime1, dateTime2);
        }

        public TickSeries GetHistoricalBids(IHistoricalDataProvider provider, Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(provider, TickType.Bid, instrument, dateTime1, dateTime2);
        }

        public TickSeries GetHistoricalAsks(IHistoricalDataProvider provider, Instrument instrument, DateTime dateTime1, DateTime dateTime2)
        {
            return this.GetHistoricalTicks(provider, TickType.Ask, instrument, dateTime1, dateTime2);
        }

        public BarSeries GetHistoricalBars(string provider, Instrument instrument, DateTime dateTime1, DateTime dateTime2, BarType barType, long barSize)
        {
            return null;
        }

        public BarSeries GetHistoricalBars(string provider, string symbol, DateTime dateTime1, DateTime dateTime2, BarType barType, long barSize)
        {
            return null;
        }

        public BarSeries GetHistoricalBars(IHistoricalDataProvider provider, Instrument instrument, DateTime dateTime1, DateTime dateTime2, BarType barType, long barSize)
        {
            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            this.disposed = true;
        }
    }
}
