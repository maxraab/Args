using Utilities;
using Xunit;

namespace Tests
{
    public class ArgsExceptionTests
    {
        [Fact]
        public void UnexpectedMessage()
        {
            var e = new ArgsException(ErrorCode.Unexpected_Argument, 'x', null);
            Assert.Equal("Argument -x unexpected.", e.ErrorMessage());
        }

        [Fact]
        public void MissingStringMessage()
        {
            var e = new ArgsException(ErrorCode.Missing_String, 'x', null);
            Assert.Equal("Could not find string parameter for -x.", e.ErrorMessage());
        }

        [Fact]
        public void InvalidIntegerMessage()
        {
            var e = new ArgsException(ErrorCode.Invalid_Integer, 'x', "Forty two");
            Assert.Equal("Argument -x expects an integer but was 'Forty two'.", e.ErrorMessage());
        }

        [Fact]
        public void MissingIntegerMessage()
        {
            var e = new ArgsException(ErrorCode.Missing_Integer, 'x', null);
            Assert.Equal("Could not find integer parameter for -x.", e.ErrorMessage());
        }

        [Fact]
        public void InvalidDoubleMessage()
        {
            var e = new ArgsException(ErrorCode.Invalid_Double, 'x', "Forty two");
            Assert.Equal("Argument -x expects a double but was 'Forty two'.", e.ErrorMessage());
        }

        [Fact]
        public void MissingDoubleMessage()
        {
            var e = new ArgsException(ErrorCode.Missing_Double, 'x', null);
            Assert.Equal("Could not find double parameter for -x.", e.ErrorMessage());
        }

        [Fact]
        public void InvalidArgumentNameMessage()
        {
            var e = new ArgsException(ErrorCode.Invalid_Argument_Name, 'x', null);
            Assert.Equal("'x' is not a valid argument name.", e.ErrorMessage());
        }

        [Fact]
        public void InvalidArgumentFormatMessage()
        {
            var e = new ArgsException(ErrorCode.Invalid_Argument_Format, 'x', "?");
            Assert.Equal("'?' is not a valid argument format.", e.ErrorMessage());
        }
    }
}
