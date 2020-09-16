using System;
using System.Dynamic;
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
        public static async Task<Return<Tout>> ToReturnAsync<Tout>(
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
        public static Task<Return<Tout>> ToReturnAsync<Tout>(
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
            return Task.FromResult(Cret);
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="state">The state.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static Return<Tout> ToReturn<Tout>(
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

        public static Return<Tout> ToReturn<Tout>(
            this Func<Tout> call,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

        public static Return<Tout> ToReturn<Tin, Tout>(
            this Func<Tin, Tout> call,
            Tin Val1,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(Val1),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="call">The call.</param>
        /// <param name="Val1">The val1.</param>
        /// <param name="Val2">The val2.</param>
        /// <param name="SuccessMessage">The success message.</param>
        /// <param name="FailMessage">The fail message.</param>
        /// <returns></returns>
        public static Return<Tout> ToReturn<Tin1, Tin2, Tout>(
            this Func<Tin1, Tin2, Tout> call,
            Tin1 Val1,
            Tin2 Val2,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(Val1, Val2),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="call">The call.</param>
        /// <param name="Val1">The val1.</param>
        /// <param name="Val2">The val2.</param>
        /// <param name="Val3">The val3.</param>
        /// <param name="SuccessMessage">The success message.</param>
        /// <param name="FailMessage">The fail message.</param>
        /// <returns></returns>
        public static Return<Tout> ToReturn<Tin1, Tin2, Tin3, Tout>(
            this Func<Tin1, Tin2, Tin3, Tout> call,
            Tin1 Val1,
            Tin2 Val2,
            Tin3 Val3,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(Val1, Val2, Val3),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="call">The call.</param>
        /// <param name="Val1">The val1.</param>
        /// <param name="Val2">The val2.</param>
        /// <param name="Val3">The val3.</param>
        /// <param name="Val4">The val4.</param>
        /// <param name="SuccessMessage">The success message.</param>
        /// <param name="FailMessage">The fail message.</param>
        /// <returns></returns>
        public static Return<Tout> ToReturn<Tin1, Tin2, Tin3, Tin4, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tout> call,
            Tin1 Val1,
            Tin2 Val2,
            Tin3 Val3,
            Tin4 Val4,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(Val1, Val2, Val3, Val4),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tin5">The type of the in5.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="call">The call.</param>
        /// <param name="Val1">The val1.</param>
        /// <param name="Val2">The val2.</param>
        /// <param name="Val3">The val3.</param>
        /// <param name="Val4">The val4.</param>
        /// <param name="Val5">The val5.</param>
        /// <param name="SuccessMessage">The success message.</param>
        /// <param name="FailMessage">The fail message.</param>
        /// <returns></returns>
        public static Return<Tout> ToReturn<Tin1, Tin2, Tin3, Tin4, Tin5, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tin5, Tout> call,
            Tin1 Val1,
            Tin2 Val2,
            Tin3 Val3,
            Tin4 Val4,
            Tin5 Val5,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(Val1, Val2, Val3, Val4, Val5),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tin5">The type of the in5.</typeparam>
        /// <typeparam name="Tin6">The type of the in6.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="call">The call.</param>
        /// <param name="Val1">The val1.</param>
        /// <param name="Val2">The val2.</param>
        /// <param name="Val3">The val3.</param>
        /// <param name="Val4">The val4.</param>
        /// <param name="Val5">The val5.</param>
        /// <param name="Val6">The val6.</param>
        /// <param name="SuccessMessage">The success message.</param>
        /// <param name="FailMessage">The fail message.</param>
        /// <returns></returns>
        public static Return<Tout> ToReturn<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tout> call,
            Tin1 Val1,
            Tin2 Val2,
            Tin3 Val3,
            Tin4 Val4,
            Tin5 Val5,
            Tin6 Val6,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(Val1, Val2, Val3, Val4, Val5, Val6),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tin5">The type of the in5.</typeparam>
        /// <typeparam name="Tin6">The type of the in6.</typeparam>
        /// <typeparam name="Tin7">The type of the in7.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="call">The call.</param>
        /// <param name="Val1">The val1.</param>
        /// <param name="Val2">The val2.</param>
        /// <param name="Val3">The val3.</param>
        /// <param name="Val4">The val4.</param>
        /// <param name="Val5">The val5.</param>
        /// <param name="Val6">The val6.</param>
        /// <param name="Val7">The val7.</param>
        /// <param name="SuccessMessage">The success message.</param>
        /// <param name="FailMessage">The fail message.</param>
        /// <returns></returns>
        public static Return<Tout> ToReturn<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tin7, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tin7, Tout> call,
            Tin1 Val1,
            Tin2 Val2,
            Tin3 Val3,
            Tin4 Val4,
            Tin5 Val5,
            Tin6 Val6,
            Tin7 Val7,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(Val1, Val2, Val3, Val4, Val5, Val6, Val7),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

        /// <summary>
        /// Converts to return.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tin5">The type of the in5.</typeparam>
        /// <typeparam name="Tin6">The type of the in6.</typeparam>
        /// <typeparam name="Tin7">The type of the in7.</typeparam>
        /// <typeparam name="Tin8">The type of the in8.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="call">The call.</param>
        /// <param name="Val1">The val1.</param>
        /// <param name="Val2">The val2.</param>
        /// <param name="Val3">The val3.</param>
        /// <param name="Val4">The val4.</param>
        /// <param name="Val5">The val5.</param>
        /// <param name="Val6">The val6.</param>
        /// <param name="Val7">The val7.</param>
        /// <param name="Val8">The val8.</param>
        /// <param name="SuccessMessage">The success message.</param>
        /// <param name="FailMessage">The fail message.</param>
        /// <returns></returns>
        public static Return<Tout> ToReturn<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tin7, Tin8, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tin7, Tin8, Tout> call,
            Tin1 Val1,
            Tin2 Val2,
            Tin3 Val3,
            Tin4 Val4,
            Tin5 Val5,
            Tin6 Val6,
            Tin7 Val7,
            Tin8 Val8,
            string SuccessMessage,
            string FailMessage)
        {
            Return<Tout> ret;
            dynamic meta = new ExpandoObject();
            try
            {
                meta.message = SuccessMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = call.Invoke(Val1, Val2, Val3, Val4, Val5, Val6, Val7, Val8),
                    Status = ReturnState.Success,
                    Metadata = meta
                };
            }
            catch (Exception e)
            {
                meta.message = FailMessage;
                ret = new Return<Tout>()
                {
                    ReturnData = Activator.CreateInstance<Tout>(),
                    Status = ReturnState.Failed,
                    Metadata = meta
                };
            }
            return ret;
        }

    }
}
