using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Stripe.Client;
using Soenneker.Stripe.Client.Abstract;
using Soenneker.Stripe.OpenApiClient.Models;
using Soenneker.Stripe.SubscriptionItems.Abstract;

namespace Soenneker.Stripe.SubscriptionItems;

public sealed class StripeSubscriptionItemsUtil(IStripeClientUtil client) : IStripeSubscriptionItemsUtil
{
    public async ValueTask<SubscriptionItem> Create(PostSubscriptionItemsXWwwFormUrlencodedRequest options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Subscription_items.PostAsync(options, c => requestOptions?.Apply(c.Headers), cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public async ValueTask<SubscriptionItem> Get(string id, Soenneker.Stripe.OpenApiClient.V1.Subscription_items.Item.WithItemItemRequestBuilder.WithItemItemRequestBuilderGetQueryParameters options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Subscription_items[id].GetAsync(new(), c => { c.QueryParameters = options; requestOptions?.Apply(c.Headers); }, cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public async ValueTask<SubscriptionItem> Update(string id, PostSubscriptionItemsItemXWwwFormUrlencodedRequest options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Subscription_items[id].PostAsync(options, c => requestOptions?.Apply(c.Headers), cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public async ValueTask<DeletedSubscriptionItem> Delete(string id, DeleteSubscriptionItemsItemXWwwFormUrlencodedRequest options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Subscription_items[id].DeleteAsync(options, c => requestOptions?.Apply(c.Headers), cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public async ValueTask<SubscriptionsItemsSubscriptionItemList> List(Soenneker.Stripe.OpenApiClient.V1.Subscription_items.Subscription_itemsRequestBuilder.Subscription_itemsRequestBuilderGetQueryParameters options, StripeRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        var api = await client.Get(cancellationToken);
        return await api.V1.Subscription_items.GetAsync(new(), c => { c.QueryParameters = options; requestOptions?.Apply(c.Headers); }, cancellationToken)
            ?? throw new InvalidOperationException("Stripe returned an empty response.");
    }

    public void Dispose() { }
    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}
