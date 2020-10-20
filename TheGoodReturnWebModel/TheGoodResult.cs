using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using TheGoodReturnModel;
using static TheGoodReturnWebModel.GlobalConst;

namespace TheGoodReturnWebModel
{
    public static class GlobalConst 
    {
        internal const string MultipartFormData = "multipart/form-data";
    }

    public class TheGoodResult<TValue> : ActionResult
    {
        private Return<TValue> _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheGoodResult{TValue}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public TheGoodResult(TValue inValue)
        {
            _value = new Return<TValue>() { ReturnData = inValue, Status = ReturnState.Success };
            _value.Metadata.ContentType = new MediaTypeHeaderValue(MultipartFormData);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TheGoodResult{TValue}"/> class.
        /// </summary>
        /// <param name="inValue">The value.</param>
        /// <param name="mediaType">Type of the media.</param>
        public TheGoodResult(TValue inValue, string mediaType = GlobalConst.MultipartFormData)
        {
            _value = new Return<TValue>() { ReturnData = inValue, Status = ReturnState.Success };
            _value.Metadata.ContentType = new MediaTypeHeaderValue(mediaType);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TheGoodResult{TValue}"/> class.
        /// </summary>
        /// <param name="inValue">The value.</param>
        /// <param name="mediaType">Type of the media.</param>
        public TheGoodResult(TValue inValue, int? statusCode, string mediaType = MultipartFormData)
        {
            _value = new Return<TValue>() { ReturnData = inValue, Status = ReturnState.Success };
            _value.Metadata.StatusCode = statusCode;
            _value.Metadata.ContentType = new MediaTypeHeaderValue(mediaType);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TheGoodResult{TValue}"/> class.
        /// </summary>
        /// <param name="inValue">The value.</param>
        /// <param name="mediaType">Type of the media.</param>
        public TheGoodResult(TValue inValue, int? statusCode, Type declaredType, string mediaType = MultipartFormData)
        {
            _value = new Return<TValue>() { ReturnData = inValue, Status = ReturnState.Success };
            _value.Metadata.StatusCode = statusCode;
            _value.Metadata.ContentType = new MediaTypeHeaderValue(mediaType);
            _value.Metadata.DeclaredType = declaredType;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public Return<TValue> Value 
        { 
            get => _value; 
            set => _value = value; 
        }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public int? StatusCode 
        { 
            get => _value.Metadata.StatusCode; 
            set => _value.Metadata.StatusCode = value; 
        }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content. Default is multipart/form-data
        /// </value>
        /// <remarks>
        /// More information can be found at: https://www.iana.org/assignments/media-types/media-types.xhtml#multipart. 
        /// However, any mime type can be used.
        /// </remarks>
        public MediaTypeHeaderValue ContentType 
        { 
            get => _value.Metadata.ContentType; 
            set => _value.Metadata.ContentType = value; 
        }

        /// <summary>
        /// Gets or sets the type of the declared.
        /// </summary>
        /// <value>
        /// The type of the declared.
        /// </value>
        public Type DeclaredType 
        {
            get => _value.Metadata.DeclaredType;
            set => _value.Metadata.DeclaredType = value;
        }
    }
}
