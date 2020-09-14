using System;
using System.Dynamic;

namespace TheGoodReturnModel
{
    /// <summary>
    /// This is a wrap for returns to eliminate the need to throw exceptions.
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class Return<T>
    {
        /// <summary>
        /// Data being returned.
        /// </summary>
        public T ReturnData { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ReturnState Status { get; set; } = ReturnState.Indeterminate;

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>
        /// The metadata.
        /// </value>
        public dynamic Metadata { get; set; } = new ExpandoObject();
    }

    /// <summary>
    /// Enum defining the retirn state.
    /// </summary>
    /// <remarks>
    /// Do not mix Indeterminant, Success, Failed, and Exception with each pther. 
    /// However, you can mix them with Custom 1 - 3 and Unhandled, 
    /// if you want to provide more detail of what type of success, failure, or other.
    /// </remarks>
    [Flags]
    public enum ReturnState
    {
        Indeterminate = 0,
        Success = 1,
        Failed = 2,
        Cancelled = 4,
        Custom1 = 8,
        Custom2 = 16,
        Custom3 = 32,
        Unhandled = 64
    }
}
