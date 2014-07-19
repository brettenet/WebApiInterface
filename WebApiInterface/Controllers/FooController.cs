using System.Web.Http;
using WebApiInterface.Models;

namespace WebApiInterface.Controllers
{
    public class FooController : ApiController
    {
        public FooController(IFoo foo)
        {
            
        }

        public IFoo Get()
        {
            return new Foo(){FooName = "SomeFoo"};
        }
        public void Post(IFoo foo)
        {
            //Do some stuff to foo
        }
    }
}
