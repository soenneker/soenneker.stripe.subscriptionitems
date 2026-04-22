using Soenneker.Stripe.SubscriptionItems.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Stripe.SubscriptionItems.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class StripeSubscriptionItemsUtilTests : HostedUnitTest
{
    private readonly IStripeSubscriptionItemsUtil _util;

    public StripeSubscriptionItemsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IStripeSubscriptionItemsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
