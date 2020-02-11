using FluentValidation.Internal;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace TheatreTicketBookingSystem.ValidateModel
{
    public class IsNameValidValidate : PropertyValidator
    {
        public IsNameValidValidate() : base("The name is invalid") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string name = context.PropertyValue as string;
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            return regexItem.IsMatch(name);
        }
    }

    public class IsNameValidPropertyValidator : FluentValidationPropertyValidator
    {
        public IsNameValidPropertyValidator(ModelMetadata metadata, ControllerContext controllerContext, PropertyRule rule, IPropertyValidator validator)
            : base(metadata, controllerContext, rule, validator) { }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (!ShouldGenerateClientSideRules()) yield break;

            var formatter = new MessageFormatter().AppendPropertyName(Rule.PropertyName);
            string message = formatter.BuildMessage("The name is invalid");
            var rule = new ModelClientValidationRule
            {
                ValidationType = "isnamevalid",
                ErrorMessage = message
            };

            yield return rule;
        }
    }

    public class IsDateValidValidate : PropertyValidator
    {
        public IsDateValidValidate() : base("The Date is invalid - The correct format is 2020-05-28") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string date = context.PropertyValue as string;
            DateTime datetime;
            return DateTime.TryParse(date, out datetime);
        }
    }

    public class IsDateValidPropertyValidator : FluentValidationPropertyValidator
    {
        public IsDateValidPropertyValidator(ModelMetadata metadata, ControllerContext controllerContext, PropertyRule rule, IPropertyValidator validator)
            : base(metadata, controllerContext, rule, validator) { }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (!ShouldGenerateClientSideRules()) yield break;

            var formatter = new MessageFormatter().AppendPropertyName(Rule.PropertyName);
            string message = formatter.BuildMessage("The Date is invalid - The correct format is 2020-05-28");
            var rule = new ModelClientValidationRule
            {
                ValidationType = "isdatevalid",
                ErrorMessage = message
            };

            yield return rule;
        }
    }

    public class IsEmailValidValidate : PropertyValidator
    {
        public IsEmailValidValidate() : base("The email is invalid") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            try
            {
                string email = context.PropertyValue as string;
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

    public class IsEmailValidPropertyValidator : FluentValidationPropertyValidator
    {
        public IsEmailValidPropertyValidator(ModelMetadata metadata, ControllerContext controllerContext, PropertyRule rule, IPropertyValidator validator)
            : base(metadata, controllerContext, rule, validator) { }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (!ShouldGenerateClientSideRules()) yield break;

            var formatter = new MessageFormatter().AppendPropertyName(Rule.PropertyName);
            string message = formatter.BuildMessage("The email is invalid");
            var rule = new ModelClientValidationRule
            {
                ValidationType = "isemailvalid",
                ErrorMessage = message
            };

            yield return rule;
        }
    }
}