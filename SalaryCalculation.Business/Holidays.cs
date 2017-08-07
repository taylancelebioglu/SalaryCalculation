
using SalaryCalculation.Data;
using System;
using System.Collections.Generic;

namespace SalaryCalculation.Business
{
    public class Holidays : List<Holiday>
    {
        public Holidays()
        {
            //List is short because of obtaining sample output results
            this.Add(new Holiday() { Description = "Holiday 1", Date = new DateTime(2018, 1, 1) });
        }
    }
}