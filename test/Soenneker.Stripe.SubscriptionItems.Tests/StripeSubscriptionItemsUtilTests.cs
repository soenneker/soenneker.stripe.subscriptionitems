using Soenneker.Stripe.SubscriptionItems.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Stripe.SubscriptionItems.Tests;

[Collection("Collection")]
public sealed class StripeSubscriptionItemsUtilTests : FixturedUnitTest
{
    private readonly IStripeSubscriptionItemsUtil _util;

    public StripeSubscriptionItemsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IStripeSubscriptionItemsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
