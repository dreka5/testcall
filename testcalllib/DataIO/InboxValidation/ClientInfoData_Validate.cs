using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace testcallLib
{
    public partial class ClientInfoData: IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(name)||name.Length<4)
                   throw new testcallValidationException(nameof(name), "Заполните имя");
            if (string.IsNullOrEmpty(surname) || surname.Length < 4)
                throw new testcallValidationException(nameof(surname), "Заполните фамилию");
            return errors;
        }
    }
}