using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest
{
    public static class Progarm
    {
        static void Main()
        {
            MoqTest test = new MoqTest(new Foo());
            var result = test.Run("id","pass");
            Console.Read();
        }
    }

    public class MoqTest
    {
        private IFoo _foo;

        public MoqTest(IFoo foo)
        {
            this._foo = foo;
        }

        public string Run(string id, string pass)
        {
            var result = _foo.Bar.DoBar(id, pass);

            return result;
        }
    }

    public interface IFoo
    {
        IBar Bar { get; }
        string DoFoo();
    }

    public class Foo : IFoo
    {
        private IBar _bar;

        public IBar Bar => _bar ?? (_bar = new Bar());

        public string DoFoo()
        {
            return "Foo done";
        }
    }

    public interface IBar
    {
        string DoBar(string id, string pass);
    }

    public class Bar : IBar
    {
        public string DoBar(string id, string pass)
        {
            return "Bar done";
        }
    }

}
