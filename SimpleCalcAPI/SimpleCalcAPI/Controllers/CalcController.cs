using SimpleCalcAPI.Models;
using System;
using System.Web.Http;

namespace SimpleCalcAPI.Controllers
{
    public class CalcController : ApiController {
        [Route("api/servertime")]
        [HttpGet]
        public DateResponse GetServerTime()
        {
            return new DateResponse  { ServerTime = DateTime.Now };
        }

        [Route("api/add")]
        [HttpPost]
        public CalcResponse Add(CalcRequest request)
        {
            try {
                return new CalcResponse { Success = true, Value = request.a + request.b };
            }
            catch(Exception e) {
                return new CalcResponse { Success = false, Error = e.Message };
            }
        }

        [Route("api/sub")]
        [HttpPost]
        public CalcResponse Subtract(CalcRequest request)
        {
            try {
                return new CalcResponse { Success = true, Value = request.a - request.b };
            } catch (Exception e) {
                return new CalcResponse { Success = false, Error = e.Message };
            }
        }

        [Route("api/mul")]
        [HttpPost]
        public CalcResponse Multiply(CalcRequest request)
        {
            try {
                return new CalcResponse { Success = true, Value = request.a * request.b };
            } catch (Exception e) {
                return new CalcResponse { Success = false, Error = e.Message };
            }
        }

        [Route("api/div")]
        [HttpPost]
        public CalcResponse Divide(CalcRequest request)
        {
            try {
                return new CalcResponse { Success = true, Value = request.a / request.b };
            } catch (Exception e) {
                return new CalcResponse { Success = false, Error = e.Message };
            }
        }
    }
}
