using System.ComponentModel.DataAnnotations;

namespace Diplomski.BLL.Validations
{
    public class DateTimeValidation : ValidationAttribute
    {
        public DateTimeValidation() : base()
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null || !(value is DateTime))
            {
                return false;
            }

            DateTime inputDate = (DateTime)value;

            return inputDate < DateTime.UtcNow;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }
}
