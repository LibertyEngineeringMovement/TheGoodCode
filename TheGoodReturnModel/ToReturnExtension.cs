using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TheGoodReturnModel
{
    public static class ToReturnExtension
    {

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="task">The task.</param>
        /// <param name="SuccessMessage">The success message.</param>
        /// <param name="FailMessage">The fail message.</param>
        /// <param name="CancelledMessage">The cancelled message.</param>
        /// <returns></returns>
        public static async Task<Return<Tout>> ToReturn<Tout>(
            this Task<Tout> task,
            string SuccessMessage,
            string FailMessage,
            string CancelledMessage)
        {
            dynamic meta = new ExpandoObject();
            if (task.Status == TaskStatus.RanToCompletion)
            {
                Tout ret = await task;
                meta.message = SuccessMessage;
                Return<Tout> Cret = new Return<Tout>()
                {
                    ReturnData = ret,
                    Status = ReturnState.Success,
                    Metadata = meta
                };
                return Cret;
            }
            else if (task.Status == TaskStatus.Faulted)
            {
                Tout ret = Activator.CreateInstance<Tout>();
                meta.message = FailMessage;
                meta.Exception = task.Exception;
                Return<Tout> Fret = new Return<Tout>()
                {
                    ReturnData = ret,
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
                return Fret;
            }
            else if (task.Status == TaskStatus.Canceled)
            {
                Tout ret = Activator.CreateInstance<Tout>();
                meta.message = CancelledMessage;
                Return<Tout> Xret = new Return<Tout>()
                {
                    ReturnData = ret,
                    Status = ReturnState.Cancelled,
                    Metadata = meta
                };
                return Xret;
            }
            else
            {
                meta.message = "Unhandled State";
                Return<Tout> Xret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed | ReturnState.Unhandled,
                    Metadata = meta
                };
                return Xret;
            }
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="state">The state.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static async Task<Return<Tout>> ToReturn<Tout>(
            this Tout value,
            ReturnState state,
            string message)
        {
            dynamic meta = new ExpandoObject();
            meta.message = message;
            Return<Tout> Cret = new Return<Tout>()
            {
                ReturnData = value,
                Status = state,
                Metadata = meta
            };
            return Cret;
        }

    }
}
