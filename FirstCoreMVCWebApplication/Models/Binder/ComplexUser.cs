using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCWebApplication.Models.Binder
{
    public class ComplexUser
    {
        [FromHeader(Name = "X-Username")]
        public string? UserName { get; set; }
        [FromQuery(Name = "age")]
        public int Age { get; set; }
        [FromRoute(Name = "country")]
        public string Country { get; set; }
        [FromQuery(Name = "refid")]
        public string ReferencedId { get; set; }
    }
}
