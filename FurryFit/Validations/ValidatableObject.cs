using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FurryFit.ViewModels.Base;
using Xamarin.Forms;

namespace FurryFit.Validations
{
    public class ValidatableObject<T> : ExtendedBindableObject, IValidatableObject
    {
        private readonly List<IValidationRule<T>> _validations;
        private List<string> _errors;
        private T _value;
        private bool _isValid;
        private bool _isInValid;

        public List<IValidationRule<T>> Validations => _validations;

        public List<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
                RaisePropertyChanged(() => Errors);
            }
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public bool IsInValid
        {
            get
            {
                return _isInValid;
            }
            set
            {
                _isInValid = value;
                RaisePropertyChanged(()=> IsInValid);
            }

        }
        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();
            IsInValid = Errors.Any();

            return this.IsValid;
        }

    }
}
