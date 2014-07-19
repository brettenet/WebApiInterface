namespace WebApiInterface.Models
{
    public interface IFoo : IActionParameter
    {
        string FooName { get; set; }
    }

    public class Foo : IFoo
    {
        public string FooName { get; set; }
    }
}