
using System.Net;
using System.Net.Security;
using System.Web;
using System.Net.Http;
using SOAP_Serv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using RestSharp;

namespace tp_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Paises")]
    public class PaisesController : Controller
    {
        // GET: api/Paises
        [HttpGet]
        public JsonResult Get()
        {
            var service = new WCFReservaVehiculosClient();

            //service.CancelarReservaAsync();
            
            var credentials = new Credentials();
            credentials.UserName = "grupo_nro2";
            credentials.Password = "crkVYDPh";
            ConsultarPaisesResponse1 result = service.ConsultarPaisesAsync(credentials).Result;

            var json = new JsonResult(result.ConsultarPaisesResult.Paises);

            return json;
        }


        [HttpGet("{code}")]
        public JsonResult Get(string code)
        {
            var client = new RestClient("http://ec2-54-87-197-49.compute-1.amazonaws.com/v1/oauth/tokens");
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "4f489d7e-596e-4335-b6c3-2beed8ccb791");
            request.AddHeader("Authorization", "Basic dGVzdF9jbGllbnRfMTp0ZXN0X3NlY3JldA==");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", $"grant_type=authorization_code&code={code}&redirect_uri=https%3A%2F%2Fwww.example.com", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return new JsonResult( response.Content);
        }



    }
}
