
namespace ApiPolizaSeguros.Tests.Fixtures
{
    public class BaseTest<TFixture>: IDisposable where TFixture: class
    {
        public TFixture Fixture { get; set; }

        public BaseTest()
        {
            Fixture = CreateFixture<TFixture>();
        }

        public T CreateFixture<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public void Dispose()
        {
            var method = Fixture.GetType().GetMethod("Dispose");
            if (method != null)
            {
                method.Invoke(Fixture, null);
            }
        }
    }
}
