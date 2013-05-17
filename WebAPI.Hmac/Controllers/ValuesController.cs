namespace WebAPI.Hmac.Controllers
{
    using System.Web.Http;

    using WebApi.Core;

    using WebAPI.Hmac.Filters;

    /// <summary>
    /// The values controller.
    /// </summary>
    [Authenticate]
    public class ValuesController : ApiController
    {
        private readonly IValueService _valueService;

        public ValuesController(IValueService valueService)
        {
            _valueService = valueService;
        }

        public string[] Get()
        {
            return _valueService.GetValues();
        }

        public string Get(int id)
        {
            return _valueService.GetValue(id);
        }

        public void Post(string value)
        {
        }

        public void Put(int id, string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}