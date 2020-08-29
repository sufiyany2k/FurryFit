using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace FurryFit.Validations
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }

    public class IsNotFutureDate<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            var _date = Convert.ToDateTime(str).Date;
            return _date <= DateTime.Today;
        }
    }

    public class EmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(str);
            return match.Success;
        }
    }

    public class IsOverMaxLength<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
                return false;
            var _maxLength = 5;
            var _value = value as string;
            if (_value.Length <= _maxLength)
                return true;
            else
                return false;
            
        }
    }

    public class IsNumberNotGreaterThanZero<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var iNumber = Convert.ToInt32(value);
            return !(iNumber<=0);
        }
    }
    public class IsAValidNumber<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            int iNumber ;
            return Int32.TryParse(value.ToString(), out iNumber);
        }
    }

}
