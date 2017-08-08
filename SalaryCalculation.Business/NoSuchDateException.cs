using System;

namespace SalaryCalculation.Business
{
    public class NoSuchDateException : Exception
    {
        public NoSuchDateException(string message) : base(message)
        {
        }
    }
}