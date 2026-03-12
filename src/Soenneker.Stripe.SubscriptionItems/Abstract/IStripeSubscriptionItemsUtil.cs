using System;
using System.Threading;
using System.Threading.Tasks;
using Stripe;

namespace Soenneker.Stripe.SubscriptionItems.Abstract;

/// <summary>
/// Defines utility methods for managing Stripe subscription items.
/// </summary>
public interface IStripeSubscriptionItemsUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Creates a new subscription item on a subscription.
    /// </summary>
    /// <param name="options">The options for creating the subscription item.</param>
    /// <param name="requestOptions">Optional Stripe request options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The created <see cref="SubscriptionItem"/>.</returns>
    ValueTask<SubscriptionItem> Create(SubscriptionItemCreateOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an existing subscription item by its identifier.
    /// </summary>
    /// <param name="subscriptionItemId">The identifier of the subscription item to retrieve.</param>
    /// <param name="getOptions">Options for retrieving the subscription item.</param>
    /// <param name="requestOptions">Optional Stripe request options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The retrieved <see cref="SubscriptionItem"/>.</returns>
    ValueTask<SubscriptionItem> Get(string subscriptionItemId, SubscriptionItemGetOptions getOptions, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing subscription item.
    /// </summary>
    /// <param name="subscriptionItemId">The identifier of the subscription item to update.</param>
    /// <param name="options">The update options.</param>
    /// <param name="requestOptions">Optional Stripe request options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The updated <see cref="SubscriptionItem"/>.</returns>
    ValueTask<SubscriptionItem> Update(string subscriptionItemId, SubscriptionItemUpdateOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a subscription item.
    /// </summary>
    /// <param name="subscriptionItemId">The identifier of the subscription item to delete.</param>
    /// <param name="deleteOptions">The delete options.</param>
    /// <param name="requestOptions">Optional Stripe request options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The deleted <see cref="SubscriptionItem"/>.</returns>
    ValueTask<SubscriptionItem> Delete(string subscriptionItemId, SubscriptionItemDeleteOptions deleteOptions, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists subscription items for a given subscription.
    /// </summary>
    /// <param name="options">The list options.</param>
    /// <param name="requestOptions">Optional Stripe request options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A <see cref="StripeList{SubscriptionItem}"/> containing the subscription items.</returns>
    ValueTask<StripeList<SubscriptionItem>> List(SubscriptionItemListOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);
}