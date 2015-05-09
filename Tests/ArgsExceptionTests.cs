using Utilities;
using Xunit;

namespace Tests
{
    public class ArgsExceptionTests
    {
        [Fact]
        public void UnexpectedMessage()
        {
            var e = new ArgsException(ErrorCode.UnexpectedArgument, null, 'x');
            Assert.Equal("Argument -x unexpected.", e.ErrorMessage());
        }

        [Fact]
        public void MissingStringMessage()
        {
            var e = new ArgsException(ErrorCode.MissingString, null, 'x');
            Assert.Equal("Could not find string parameter for -x.", e.ErrorMessage());
        }

        [Fact]
        public void InvalidIntegerMessage()
        {
            var e = new ArgsException(ErrorCode.InvalidInteger, "Forty two", 'x');
            Assert.Equal("Argument -x expects an integer but was 'Forty two'.", e.ErrorMessage());
        }

        [Fact]
        public void MissingIntegerMessage()
        {
            var e = new ArgsException(ErrorCode.MissingInteger, null, 'x');
            Assert.Equal("Could not find integer parameter for -x.", e.ErrorMessage());
        }

        [Fact]
        public void InvalidDoubleMessage()
        {
            var e = new ArgsException(ErrorCode.InvalidDouble, "Forty two", 'x');
            Assert.Equal("Argument -x expects a double but was 'Forty two'.", e.ErrorMessage());
        }

        [Fact]
        public void MissingDoubleMessage()
        {
            var e = new ArgsException(ErrorCode.MissingDouble, null, 'x');
            Assert.Equal("Could not find double parameter for -x.", e.ErrorMessage());
        }

        [Fact]
        public void InvalidArgumentNameMessage()
        {
            var e = new ArgsException(ErrorCode.InvalidArgumentName, null, 'x');
            Assert.Equal("'x' is not a valid argument name.", e.ErrorMessage());
        }

        [Fact]
        public void InvalidArgumentFormatMessage()
        {
            var e = new ArgsException(ErrorCode.InvalidArgumentFormat, "?", 'x');
            Assert.Equal("'?' is not a valid argument format.", e.ErrorMessage());
        }
    }
}
