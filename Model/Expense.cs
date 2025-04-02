﻿namespace MuleReplacementPOC.Model
{
    public class Expense
    {
        public int Id {  get; set; }
        public string Category { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
