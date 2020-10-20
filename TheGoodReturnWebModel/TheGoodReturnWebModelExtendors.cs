using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Threading.Tasks;
using TheGoodReturnModel;
using static TheGoodReturnWebModel.GlobalConst;


namespace TheGoodReturnWebModel
{
    public static class TheGoodReturnWebModelExtendors
    {
        #region Sync
        public static TheGoodResult<T> ReturnGood<T>(this Controller me, T data)
        {
            return new TheGoodResult<T>(data);
        }
        public static TheGoodResult<T> ReturnGood<T>(this Controller me, T data, string mediaType = MultipartFormData)
        {
            return new TheGoodResult<T>(data, mediaType);
        }
        public static TheGoodResult<T> ReturnGood<T>(this Controller me, T data, int? statusCode, string mediaType = MultipartFormData)
        {
            return new TheGoodResult<T>(data, statusCode, mediaType);
        }
        public static TheGoodResult<T> ReturnGood<T>(this Controller me, T data, int? statusCode, Type declaredType, string mediaType = MultipartFormData)
        {
            return new TheGoodResult<T>(data, statusCode, declaredType, mediaType);
        }
        #endregion

        #region Async
        public static async Task<TheGoodResult<T>> ReturnGoodAsync<T>(this Controller me, Task<T> data)
        {
            return new TheGoodResult<T>(await data);
        }
        public static async Task<TheGoodResult<T>> ReturnGoodAsync<T>(this Controller me, Task<T> data, string mediaType = MultipartFormData)
        {
            return new TheGoodResult<T>(await data, mediaType);
        }
        public static async Task<TheGoodResult<T>> ReturnGoodAsync<T>(this Controller me, Task<T> data, int? statusCode, string mediaType = MultipartFormData)
        {
            return new TheGoodResult<T>(await data, statusCode, mediaType);
        }
        public static async Task<TheGoodResult<T>> ReturnGoodAsync<T>(this Controller me, Task<T> data, int? statusCode, Type declaredType, string mediaType = MultipartFormData)
        {
            return new TheGoodResult<T>(await data, statusCode, declaredType, mediaType);
        }
        #endregion
    }
}
