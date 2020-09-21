using System;
using System.Dynamic;
using TheGoodReturnModel;

namespace TheGoodReturnWebModel
{
    public static class TheGoodReturnWebModelExtendors
    {
        public static Return<T> ReturnAs<T>(this object me, T data)
        {
            return new Return<T>() 
            { 
                ReturnData = data, 
                Status = ReturnState.Success, 
                Metadata = new ExpandoObject() 
            };
        }
    }
}
