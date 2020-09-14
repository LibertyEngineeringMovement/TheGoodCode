using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TheGoodReturnModel
{
    /// <summary>
    /// Async Wrapper Extensions.
    /// </summary>
    public static class RunAsyncExtensions
    {
        public static object Metadata { get; private set; }

        /// <summary>
        /// Runs the asymc.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="act">The act.</param>
        /// <returns></returns>
        public static Task RunAsymc(
            this Action act
            )
        {
            return Task.Run(act);
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="act">The act.</param>
        /// <returns></returns>
        public static Task<Tout> RunAsync<Tout>(
            this Func<Tout> act
            )
        {
            return Task.Run<Tout>(act);
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <typeparam name="Tin">The type of the in.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="act">The act.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Task<Tout> RunAsync<Tin, Tout>(
            this Func<Tin, Tout> act,
            Tin value
            )
        {
            try
            {
                Tout ret = act.Invoke(value);
                return Task.FromResult(ret);
            }
            catch (Exception ex)
            {
                return Task.FromException<Tout>(ex);
            }
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="act">The act.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public static Task<Tout> RunAsync<Tin1, Tin2, Tout>(
            this Func<Tin1, Tin2, Tout> act,
            Tin1 value1, Tin2 value2
            )
        {
            try
            {
                Tout ret = act.Invoke(value1, value2);
                return Task.FromResult(ret);
            }
            catch (Exception ex)
            {
                return Task.FromException<Tout>(ex);
            }
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="act">The act.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="Value3">The value3.</param>
        /// <returns></returns>
        public static Task<Tout>
            RunAsync<Tin1, Tin2, Tin3, Tout>(
            this Func<Tin1, Tin2, Tin3, Tout> act,
            Tin1 value1, Tin2 value2, Tin3 Value3
            )
        {
            try
            {
                Tout ret = act.Invoke(value1, value2, Value3);
                return Task.FromResult(ret);
            }
            catch (Exception ex)
            {
                return Task.FromException<Tout>(ex);
            }
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="act">The act.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="Value3">The value3.</param>
        /// <param name="Value4">The value4.</param>
        /// <returns></returns>
        public static Task<Tout>
            RunAsync<Tin1, Tin2, Tin3, Tin4, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tout> act,
            Tin1 value1, Tin2 value2, Tin3 Value3,
            Tin4 Value4
            )
        {
            try
            {
                Tout ret = act.Invoke(
                    value1,
                    value2,
                    Value3,
                    Value4);
                return Task.FromResult(ret);
            }
            catch (Exception ex)
            {
                return Task.FromException<Tout>(ex);
            }
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tin5">The type of the in5.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="act">The act.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="Value3">The value3.</param>
        /// <param name="Value4">The value4.</param>
        /// <param name="Value5">The value5.</param>
        /// <returns></returns>
        public static Task<Tout>
            RunAsync<Tin1, Tin2, Tin3, Tin4, Tin5, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tin5, Tout> act,
            Tin1 value1, Tin2 value2, Tin3 Value3,
            Tin4 Value4, Tin5 Value5
            )
        {
            try
            {
                Tout ret = act.Invoke(
                    value1,
                    value2,
                    Value3,
                    Value4,
                    Value5);
                return Task.FromResult(ret);
            }
            catch (Exception ex)
            {
                return Task.FromException<Tout>(ex);
            }
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tin5">The type of the in5.</typeparam>
        /// <typeparam name="Tin6">The type of the in6.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="act">The act.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="Value3">The value3.</param>
        /// <param name="Value4">The value4.</param>
        /// <param name="Value5">The value5.</param>
        /// <param name="Value6">The value6.</param>
        /// <returns></returns>
        public static Task<Tout>
            RunAsync<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tout> act,
            Tin1 value1, Tin2 value2, Tin3 Value3,
            Tin4 Value4, Tin5 Value5, Tin6 Value6
            )
        {
            try
            {
                Tout ret = act.Invoke(
                    value1, value2, Value3,
                    Value4, Value5, Value6);
                return Task.FromResult(ret);
            }
            catch (Exception ex)
            {
                return Task.FromException<Tout>(ex);
            }
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <typeparam name="Tin1">The type of the in1.</typeparam>
        /// <typeparam name="Tin2">The type of the in2.</typeparam>
        /// <typeparam name="Tin3">The type of the in3.</typeparam>
        /// <typeparam name="Tin4">The type of the in4.</typeparam>
        /// <typeparam name="Tin5">The type of the in5.</typeparam>
        /// <typeparam name="Tin6">The type of the in6.</typeparam>
        /// <typeparam name="Tin7">The type of the in7.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="act">The act.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="Value3">The value3.</param>
        /// <param name="Value4">The value4.</param>
        /// <param name="Value5">The value5.</param>
        /// <param name="Value6">The value6.</param>
        /// <param name="Value7">The value7.</param>
        /// <returns></returns>
        public static Task<Tout>
            RunAsync<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tin7, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tin7, Tout> act,
            Tin1 value1, Tin2 value2, Tin3 Value3,
            Tin4 Value4, Tin5 Value5, Tin6 Value6,
            Tin7 Value7
            )
        {
            try
            {
                Tout ret = act.Invoke(
                    value1, value2, Value3,
                    Value4, Value5, Value6,
                    Value7);
                return Task.FromResult(ret);
            }
            catch (Exception ex)
            {
                return Task.FromException<Tout>(ex);
            }
        }

        /// <summary>
        /// Runs the asynchronous.
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
        /// <param name="act">The act.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="Value3">The value3.</param>
        /// <param name="Value4">The value4.</param>
        /// <param name="Value5">The value5.</param>
        /// <param name="Value6">The value6.</param>
        /// <param name="Value7">The value7.</param>
        /// <param name="Value8">The value8.</param>
        /// <returns></returns>
        public static Task<Tout>
            RunAsync<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tin7, Tin8, Tout>(
            this Func<Tin1, Tin2, Tin3, Tin4, Tin5, Tin6, Tin7, Tin8, Tout> act,
            Tin1 value1, Tin2 value2, Tin3 Value3,
            Tin4 Value4, Tin5 Value5, Tin6 Value6,
            Tin7 Value7, Tin8 Value8
            )
        {
            try
            {
                Tout ret = act.Invoke(
                    value1, value2, Value3,
                    Value4, Value5, Value6,
                    Value7, Value8);
                return Task.FromResult(ret);
            }
            catch (Exception ex)
            {
                return Task.FromException<Tout>(ex);
            }
        }

    }
}
