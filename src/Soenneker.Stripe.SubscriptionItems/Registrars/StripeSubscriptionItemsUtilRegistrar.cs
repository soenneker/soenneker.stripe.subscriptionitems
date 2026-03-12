using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Stripe.Client.Registrars;
using Soenneker.Stripe.SubscriptionItems.Abstract;

namespace Soenneker.Stripe.SubscriptionItems.Registrars;

/// <summary>
/// A .NET typesafe implementation of Stripe's Subscription Items API
/// </summary>
public static class StripeSubscriptionItemsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IStripeSubscriptionItemsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddStripeSubscriptionItemsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddStripeClientUtilAsSingleton().TryAddSingleton<IStripeSubscriptionItemsUtil, StripeSubscriptionItemsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IStripeSubscriptionItemsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddStripeSubscriptionItemsUtilAsScoped(this IServiceCollection services)
    {
        services.AddStripeClientUtilAsSingleton().TryAddScoped<IStripeSubscriptionItemsUtil, StripeSubscriptionItemsUtil>();

        return services;
    }
}
