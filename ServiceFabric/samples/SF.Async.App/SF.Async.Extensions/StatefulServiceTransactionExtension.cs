using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Extensions
{
    public static class StatefulServiceTransactionExtension
    {
        private const int DefaultMaxAttempts = 10;
        private static readonly TimeSpan InitialDelay = TimeSpan.FromMilliseconds(200);
        private static readonly TimeSpan MinimumDelay = TimeSpan.FromMilliseconds(200);

        /// <summary>
        /// Executes the provided callback in a StateManager transaction, with retry + exponential back-off. Returns the result.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="statefulService">for statefulservice static extension.</param>
        /// <param name="operation">operation to execute wiht retry.</param>
        /// <param name="state">state passd to callback. (optional)</param>
        /// <param name="cancellationToken">Cancellation support. (optional)</param>
        /// <param name="maxAttempts">#Attempts to execute <paramref name="operation"/> (optional)</param>
        /// <param name="initialDelay">First delay between attempts. Later on this will be exponentially grow. (optional)</param>
        /// <returns></returns>
        public static async Task<TResult> TimeoutReTryTransaction<TResult>(this StatefulService statefulService,
            Func<ITransaction, IReliableStateManager, CancellationToken, object, Task<TResult>> operation,
            object state = null,
            CancellationToken cancellationToken = default(CancellationToken),
            int maxAttempts = DefaultMaxAttempts,
            TimeSpan? initialDelay = null)
        {
            if (maxAttempts <= 0) maxAttempts = DefaultMaxAttempts;
            if (initialDelay == null || initialDelay.Value < MinimumDelay)
                initialDelay = InitialDelay;
            var stateManager = statefulService.StateManager;


            Func<CancellationToken, object, Task<TResult>> wrapped = async (token, st) =>
            {
                TResult result;
                using (var tran = stateManager.CreateTransaction())
                {
                    try
                    {
                        result = await operation(tran, stateManager, cancellationToken, state);
                        await tran.CommitAsync();
                    }
                    catch (TimeoutException)
                    {
                        tran.Abort();
                        throw;
                    }
                }
                return result;
            };

            var outerResult = await statefulService.Execute(wrapped, state, cancellationToken, maxAttempts, initialDelay);
            return outerResult;
        }

        /// <summary>
        /// Executes the provided callback in a StateManager transaction, with retry + exponential back-off.
        /// </summary>
        /// <param name="statefulService">for statefulservice static extension.</param>
        /// <param name="operation">operation to execute wiht retry.</param>
        /// <param name="state">state passd to callback. (optional)</param>
        /// <param name="cancellationToken">Cancellation support. (optional)</param>
        /// <param name="maxAttempts">#Attempts to execute <paramref name="operation"/> (optional)</param>
        /// <param name="initialDelay">First delay between attempts. Later on this will be exponentially grow. (optional)</param>
        /// <returns></returns>
        public static async Task TimeoutReTryTransactionAsync(this StatefulService statefulService,
            Func<ITransaction, IReliableStateManager, CancellationToken, object, Task> operation,
            object state = null,
            CancellationToken cancellationToken = default(CancellationToken),
            int maxAttempts = DefaultMaxAttempts,
            TimeSpan? initialDelay = null)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));
            if (maxAttempts <= 0) maxAttempts = DefaultMaxAttempts;
            if (initialDelay == null || initialDelay.Value < MinimumDelay)
                initialDelay = InitialDelay;

            var stateManager = statefulService.StateManager;

            Func<CancellationToken, object, Task<object>> wrapped = async (token, st) =>
            {
                using (var tran = stateManager.CreateTransaction())
                {
                    try
                    {
                        await operation(tran, stateManager, cancellationToken, state);
                        await tran.CommitAsync();
                    }
                    catch (TimeoutException)
                    {
                        tran.Abort();
                        throw;
                    }
                }
                return null;
            };

            await statefulService.Execute(wrapped, state, cancellationToken, maxAttempts, initialDelay);
        }

        /// <summary>
        /// Executes the provided callback with retry + exponential back-off for <see cref="TimeoutException"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="statefulService"></param>
        /// <param name="operation">Operation to execute with retry.</param>
        /// <param name="state">State passed to callback. (optional)</param>
        /// <param name="cancellationToken">Cancellation support. (optional)</param>
        /// <param name="maxAttempts">#Attempts to execute <paramref name="operation"/> (optional)</param>
        /// <param name="initialDelay">First delay between attempts. Later on this will be exponentially grow. (optional)</param>
        /// <returns></returns>
        public static async Task<TResult> Execute<TResult>(this StatefulService statefulService, Func<CancellationToken, object, Task<TResult>> operation,
            object state = null,
            CancellationToken cancellationToken = default(CancellationToken),
            int maxAttempts = DefaultMaxAttempts,
            TimeSpan? initialDelay = null)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));
            if (maxAttempts <= 0) maxAttempts = DefaultMaxAttempts;
            if (initialDelay == null || initialDelay.Value < MinimumDelay)
                initialDelay = InitialDelay;

            var result = default(TResult);
            for (int attempts = 0; attempts < maxAttempts; attempts++)
            {
                try
                {
                    result = await operation(cancellationToken, state);
                    break;
                }
                catch (TimeoutException)
                {
                    if (attempts == DefaultMaxAttempts)
                    {
                        throw;
                    }
                }

                //exponential back-off
                int factor = (int)Math.Pow(2, attempts) + 1;
                int delay = new Random(Guid.NewGuid().GetHashCode()).Next((int)(initialDelay.Value.TotalMilliseconds * 0.5D), (int)(initialDelay.Value.TotalMilliseconds * 1.5D));
                await Task.Delay(factor * delay, cancellationToken);
            }
            return result;
        }

    }
}
