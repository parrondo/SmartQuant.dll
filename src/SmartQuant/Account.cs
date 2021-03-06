﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.Collections.Generic;

namespace SmartQuant
{
    public class Account
    {
        private Framework framework;

        public byte CurrencyId { get; set; }

        public List<AccountPosition> Positions { get; private set; }

        public List<AccountTransaction> Transactions { get; private set; }

        internal Account Parent { get; set; }

        public double Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Account(Framework framework)
        {
            this.framework = framework;
            CurrencyId = global::SmartQuant.CurrencyId.USD;
            Positions = new List<AccountPosition>();
            Transactions = new List<AccountTransaction>();
        }

        public void Add(double value, byte currencyId = global::SmartQuant.CurrencyId.USD, string text = null, bool updateParent = true)
        {
            Add(new AccountTransaction(this.framework.Clock.DateTime, value, currencyId, text), updateParent);
        }

        public void Add(AccountTransaction transaction, bool updateParent = true)
        {
            throw new NotImplementedException();
        }

        public void Add(Fill fill, bool updateParent = true)
        {
            Add(new AccountTransaction(fill), updateParent);
        }

        public void Add(DateTime dateTime, double value, byte currencyId = global::SmartQuant.CurrencyId.USD, string text = null, bool updateParent = true)
        {
            Add(new AccountTransaction(dateTime, value, currencyId, text), updateParent);
        }

        public void Deposit(double value, byte currencyId = global::SmartQuant.CurrencyId.USD, string text = null, bool updateParent = true)
        {
            Add(value, currencyId, text, updateParent);
        }

        public void Deposit(DateTime dateTime, double value, byte currencyId = global::SmartQuant.CurrencyId.USD, string text = null, bool updateParent = true)
        {
            Add(dateTime, value, currencyId, text, updateParent);
        }

        public void Withdraw(double value, byte currencyId = global::SmartQuant.CurrencyId.USD, string text = null, bool updateParent = true)
        {
            Add(-value, currencyId, text, updateParent);
        }

        public void Withdraw(DateTime dateTime, double value, byte currencyId = global::SmartQuant.CurrencyId.USD, string text = null, bool updateParent = true)
        {
            Add(dateTime, -value, currencyId, text, updateParent);
        }
    }
}