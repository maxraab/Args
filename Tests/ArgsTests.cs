
using Utilities;
using Xunit;

namespace Tests
{
    public class ArgsTests
    {
        [Fact]
        public void CreateWithNoSchemaOrArguments()
        {
            var args = new Args("", new string[0]);
            Assert.Equal(0, args.Cardinality());
        }

        [Fact]
        public void CreateWithNoSchemaButWithOneArgument()
        {
            try
            {
                var args = new Args("", new string[] { "-x" });
                Assert.False(true, "Args constructor shoud have thrown exception.");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Unexpected_Argument, e.ErrorCode);
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        [Fact]
        public void CreateWithNoSchemaButWithMultipleArguments()
        {
            try
            {
                var args = new Args("", new string[] { "-x", "-y" });
                Assert.False(true, "Args constructor shoud have thrown exception.");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Unexpected_Argument, e.ErrorCode);
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        [Fact]
        public void NonLetterSchema()
        {
            try
            {
                var args = new Args("*", new string[0]);
                Assert.False(true, "Args constructor shoud have thrown exception.");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Invalid_Argument_Name, e.ErrorCode);
                Assert.Equal('*', e.ErrorArgumentId);
            }
        }

        [Fact]
        public void InvalidArgumentFormat()
        {
            try
            {
                var args = new Args("f~", new string[0]);
                Assert.False(true, "Args constructor shoud have thrown exception.");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Invalid_Argument_Format, e.ErrorCode);
                Assert.Equal('f', e.ErrorArgumentId);
            }
        }

        [Fact]
        public void SimpleBooleanPresent()
        {
            var args = new Args("x", new string[] { "-x" });
            Assert.Equal(1, args.Cardinality());
            Assert.Equal(true, args.GetBoolean('x'));
        }

        [Fact]
        public void SimpleStringPresent()
        {
            var args = new Args("x*", new string[] { "-x", "param" });
            Assert.Equal(1, args.Cardinality());
            Assert.True(args.Has('x'));
            Assert.Equal("param", args.GetString('x'));
        }

        [Fact]
        public void MissingStringArgument()
        {
            try
            {
                var args = new Args("x*", new string[] { "-x", "param" });
                Assert.Equal(1, args.Cardinality());
                Assert.True(args.Has('x'));
                Assert.Equal("param", args.GetString('x'));
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Missing_String, e.ErrorCode);
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        [Fact]
        public void SpacesInFormat()
        {
            var args = new Args("x, y", new string[] { "-xy" });
            Assert.Equal(2, args.Cardinality());
            Assert.True(args.Has('x'));
            Assert.True(args.Has('y'));
        }

        [Fact]
        public void SimpleIntPresent()
        {
            var args = new Args("x#", new string[] { "-x", "42" });
            Assert.Equal(1, args.Cardinality());
            Assert.True(args.Has('x'));
            Assert.Equal(42, args.GetInteger('x'));
        }

        [Fact]
        public void InvalidInteger()
        {
            try
            {
                var args = new Args("x#", new string[] { "-x", "Forty two" });
                Assert.True(false, "Args constructor shoud have thrown exception.");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Invalid_Integer, e.ErrorCode);
                Assert.Equal('x', e.ErrorArgumentId);
                Assert.Equal("Forty two", e.ErrorParameter);
            }
        }

        [Fact]
        public void MissingInteger()
        {
            try
            {
                var args = new Args("x#", new string[] { "-x" });
                Assert.True(false, "Args constructor shoud have thrown exception.");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Missing_Integer, e.ErrorCode);
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        [Fact]
        public void SimpleDoublePresent()
        {
            var args = new Args("x##", new string[] { "-x", "42,3" });
            Assert.Equal(1, args.Cardinality());
            Assert.True(args.Has('x'));
            Assert.Equal(42.3, args.GetDouble('x'));
        }

        [Fact]
        public void InvalidDouble()
        {
            try
            {
                var args = new Args("x##", new string[] { "-x", "Forty two" });
                Assert.True(false, "Args constructor shoud have thrown exception.");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Invalid_Double, e.ErrorCode);
                Assert.Equal('x', e.ErrorArgumentId);
                Assert.Equal("Forty two", e.ErrorParameter);
            }
        }

        [Fact]
        public void MissingDouble()
        {
            try
            {
                var args = new Args("x##", new string[] { "-x" });
                Assert.True(false, "Args constructor shoud have thrown exception.");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.Missing_Double, e.ErrorCode);
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        [Fact]
        public void Usage()
        {
            var args = new Args("x", new string[] { "-x" });
            Assert.Equal("-[x]", args.Usage());
        }
    }
}
