using FluentValidation.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TheatreTicketBookingSystem.ValidateModel;

namespace TheatreTicketBookingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FluentValidationModelValidatorProvider.Configure(x =>
            {
                x.Add(typeof(IsNameValidValidate), (metadata, context, rule, validator) => new IsNameValidPropertyValidator(metadata, context, rule, validator));
                x.Add(typeof(IsDateValidValidate), (metadata, context, rule, validator) => new IsDateValidPropertyValidator(metadata, context, rule, validator));
                x.Add(typeof(IsEmailValidValidate), (metadata, context, rule, validator) => new IsEmailValidPropertyValidator(metadata, context, rule, validator));

            });

        }
    }
}
