using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.Stripe.Client.Abstract;
using Soenneker.Stripe.SubscriptionItems.Abstract;
using Soenneker.Utils.AsyncSingleton;
using Stripe;

namespace Soenneker.Stripe.SubscriptionItems;

///<inheritdoc cref="IStripeSubscriptionItemsUtil"/>
public sealed class StripeSubscriptionItemsUtil : IStripeSubscriptionItemsUtil
{
    private readonly ILogger<StripeSubscriptionItemsUtil> _logger;
    private readonly IStripeClientUtil _stripeUtil;
    private readonly AsyncSingleton<SubscriptionItemService> _service;

    public StripeSubscriptionItemsUtil(ILogger<StripeSubscriptionItemsUtil> logger, IStripeClientUtil stripeUtil)
    {
        _logger = logger;
        _stripeUtil = stripeUtil;

        _service = new AsyncSingleton<SubscriptionItemService>(CreateService);
    }

    private async ValueTask<SubscriptionItemService> CreateService(CancellationToken cancellationToken)
    {
        StripeClient client = await _stripeUtil.Get(cancellationToken)
                                               .NoSync();
        return new SubscriptionItemService(client);
    }

    public async ValueTask<SubscriptionItem> Create(SubscriptionItemCreateOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        SubscriptionItemService svc = await _service.Get(cancellationToken)
                                                    .NoSync();
        try
        {
            return await svc.CreateAsync(options, requestOptions, cancellationToken)
                            .NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating subscription item {@Options}", options);
            throw;
        }
    }

    public async ValueTask<SubscriptionItem> Get(string subscriptionItemId, SubscriptionItemGetOptions getOptions, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        SubscriptionItemService svc = await _service.Get(cancellationToken)
                                                    .NoSync();
        try
        {
            return await svc.GetAsync(subscriptionItemId, getOptions, requestOptions, cancellationToken)
                            .NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving subscription item {SubscriptionItemId}", subscriptionItemId);
            throw;
        }
    }

    public async ValueTask<SubscriptionItem> Update(string subscriptionItemId, SubscriptionItemUpdateOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        SubscriptionItemService svc = await _service.Get(cancellationToken)
                                                    .NoSync();
        try
        {
            return await svc.UpdateAsync(subscriptionItemId, options, requestOptions, cancellationToken)
                            .NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating subscription item {SubscriptionItemId} {@Options}", subscriptionItemId, options);
            throw;
        }
    }

    public async ValueTask<SubscriptionItem> Delete(string subscriptionItemId, SubscriptionItemDeleteOptions deleteOptions,
        RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        SubscriptionItemService svc = await _service.Get(cancellationToken)
                                                    .NoSync();
        try
        {
            return await svc.DeleteAsync(subscriptionItemId, deleteOptions, requestOptions, cancellationToken)
                            .NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting subscription item {SubscriptionItemId}", subscriptionItemId);
            throw;
        }
    }

    public async ValueTask<StripeList<SubscriptionItem>> List(SubscriptionItemListOptions options, RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        SubscriptionItemService svc = await _service.Get(cancellationToken)
                                                    .NoSync();
        try
        {
            return await svc.ListAsync(options, requestOptions, cancellationToken)
                            .NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error listing subscription items {@Options}", options);
            throw;
        }
    }

    public void Dispose() => _service.Dispose();

    public ValueTask DisposeAsync() => _service.DisposeAsync();
}