namespace MentalDesk.AsyncVoid;

/// <summary>
/// Utility class for running `async void` methods safely
/// </summary>
public static class AsyncVoid
{
    /// <summary>
    /// Runs an `async void` method safely.
    /// </summary>
    /// <param name="task">Typically either a method group or an async lambda that executes some async void code</param>
    /// <param name="handler">The exception handler callback that will run if an exception is thrown</param>
    /// <example>
    /// <code>
    /// AsyncVoid.RunSafely(async () => await MyAsyncMethod(), ex => Console.WriteLine(ex.Message));
    /// </code>
    /// </example>
    public static void RunSafely(Action task, Action<Exception> handler)
    {
        var syncCtx = SynchronizationContext.Current;
        try
        {
            SynchronizationContext.SetSynchronizationContext(new ExceptionHandlingSynchronizationContext(handler, syncCtx));
            task();
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(syncCtx);
        }
    }
}