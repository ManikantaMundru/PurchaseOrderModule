using Newtonsoft.Json;
using PurchaseOrderModule.Models;
using System.Collections.Generic;

namespace PurchaseOrderModule.Utilities
{
    public class ResponseUtility
    {
        public const string Success = "Request was successfull";
        public const string UnSuccessful = "Request was unsuccessfull";

        internal static ResponseModel CreateResponse<T>(T response, bool isSucessful = true)
        {
            return new ResponseModel
            {
                Message = isSucessful ? Success : UnSuccessful,
                Success = isSucessful,
                Result = !EqualityComparer<T>.Default.Equals(response, default(T)) ? JsonConvert.SerializeObject(response) : null
            };
        }
    }
}
