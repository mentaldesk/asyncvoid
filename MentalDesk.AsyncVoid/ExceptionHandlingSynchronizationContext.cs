using System.Runtime.ExceptionServices;

namespace MentalDesk.AsyncVoid;

internal class ExceptionHandlingSynchronizationContext(Action<Exception> exceptionHandler, SynchronizationContext? innerContext)
    : SynchronizationContext
{
    public override void Post(SendOrPostCallback d, object? state)
    {
        if (state is ExceptionDispatchInfo exceptionInfo)
        {
            exceptionHandler(exceptionInfo.SourceException);
            return;
        }
        if (innerContext != null)
        {
            innerContext.Post(d, state);
            return;
        }
        base.Post(d, state);
    }
}