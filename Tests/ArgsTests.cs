
using Utilities;
using Xunit;

namespace Tests
{
    public class ArgsTests
    {
        [Fact]
        public void TestCreateWithNoSchemaOrArguments()
        {
            var args = new Args("", new string[0]);
            Assert.Equal(0, args.car)
        }
    }
}
