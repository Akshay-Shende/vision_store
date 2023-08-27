using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Enums;

namespace VisionStore.Controllers
{
 
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        protected BadRequestObjectResult BadRequest(string key,string message, ErrorType  type =ErrorType.Error)
        {
            return base.BadRequest(new List<Error>
            {
                new Error
                {
                    ErrorType =type,
                    Key       = key,
                    Message = message,

                }
            });
        }
    }
}
