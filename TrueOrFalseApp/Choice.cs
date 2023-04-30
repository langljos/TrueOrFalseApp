using System.Collections.Generic;

namespace TrueOrFalseApp
{
    class Choice
    {
        public string Option { get; set; }
        public double Value { get; set; }

        public Choice(string option, double value)
        {
            Option = option;
            Value = value;
        }

    }
}