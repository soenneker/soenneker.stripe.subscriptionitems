[![](https://img.shields.io/nuget/v/soenneker.stripe.subscriptionitems.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.stripe.subscriptionitems/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.stripe.subscriptionitems/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.stripe.subscriptionitems/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.stripe.subscriptionitems.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.stripe.subscriptionitems/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.stripe.subscriptionitems/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.stripe.subscriptionitems/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Stripe.SubscriptionItems

Create, retrieve, update, delete, and list the individual prices and quantities attached to Stripe subscriptions.

## Installation

```bash
dotnet add package Soenneker.Stripe.SubscriptionItems
```

## Configuration

```json
{
  "Stripe": {
    "SecretKey": "sk_test_..."
  }
}
```

## Usage

```csharp
using Soenneker.Stripe.SubscriptionItems.Abstract;
using Soenneker.Stripe.SubscriptionItems.Registrars;
using Stripe;

services.AddStripeSubscriptionItemsUtilAsScoped();

StripeList<SubscriptionItem> items = await subscriptionItemsUtil.List(
    new SubscriptionItemListOptions
    {
        Subscription = "sub_...",
        Limit = 25
    },
    cancellationToken: cancellationToken);

SubscriptionItem updated = await subscriptionItemsUtil.Update(
    "si_...",
    new SubscriptionItemUpdateOptions
    {
        Quantity = 5,
        ProrationBehavior = "create_prorations"
    },
    cancellationToken: cancellationToken);
```

`List` returns one Stripe page; use its pagination fields when more results are available. Creating, updating, or deleting a subscription item changes the subscription's billing configuration and can create prorations according to the supplied Stripe options.
