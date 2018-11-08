using Newtonsoft.Json;
using ReactReduxAxiosAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ReactReduxAxiosAPI.Controllers
{
    public class MerchantController : ApiController
    {
        [HttpGet]
        [ActionName("GetMerchantList")]
        [Route("api/GetMerchantList")]
        public async Task<HttpResponseMessage> GetMerchantList()
        {
            bool blnSuccess = false;
            string Msg = string.Empty;
            string responseSentSMSString = string.Empty;
            string SendMsg = string.Empty;
            IEnumerable<Merchant> resultData = null;
            try
            {

                using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/Data/data.json")))
                {
                    var json =await r.ReadToEndAsync();
                    resultData =JsonConvert.DeserializeObject<List<Merchant>>(json);
                   
                }

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Success = blnSuccess,
                        Message = Msg,
                        data = resultData
                    })
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Success = blnSuccess,
                        Msg = ex.Message
                    })
                };

            }
        }

        [HttpPost]
        [ActionName("AddMerchant")]
        [Route("AddMerchant")]
        public async Task<HttpResponseMessage> AddMerchant(Merchant obj)
        {
            bool blnSuccess = false;
            string Msg = string.Empty;
            string responseSentSMSString = string.Empty;
            string SendMsg = string.Empty;
            IEnumerable<Merchant> resultData = null;
            try
            {

                using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/Data/data.json")))
                {
                    var json = await r.ReadToEndAsync();
                    string updatedJson = AddObjectsToJson(json, obj);
                    File.WriteAllText(HttpContext.Current.Server.MapPath("~/Data/data.json"), updatedJson);

                }

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Success = blnSuccess,
                        Message = Msg,
                        data = resultData
                    })
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Success = blnSuccess,
                        Msg = ex.Message
                    })
                };

            }
        }

        public string AddObjectsToJson<T>(string json, T objects)
        {
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
            list.Add(objects);
            return JsonConvert.SerializeObject(list);
        }
    }
}
