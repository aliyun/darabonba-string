using System;
using System.Collections.Generic;
using AlibabaCloud.DarabonbaString;
using Xunit;

namespace tests
{
    public class StringUtilTest
    {
        [Fact]
        public void Test_Split()
        {
            Assert.Null(StringUtil.Split(null, "."));

            Assert.Equal(new List<string> { "aa", "bb" }, StringUtil.Split("aa.bb", ".", null));

            Assert.Equal(new List<string> { "aa", "bb.cc" }, StringUtil.Split("aa.bb.cc", ".", 2));

            Assert.Equal(new List<string> { "/test", "path=1&name=2" }, StringUtil.Split("/test?path=1&name=2", "?", null));

            Assert.Equal(new List<string> { "/test", "path=1&name=2" }, StringUtil.Split("/test?path=1&name=2", "?", -1));
        }

        [Fact]
        public void Test_Replace()
        {
            Assert.Null(StringUtil.Replace(null, "bb", "ff"));
            Assert.Equal("aaffffccddbbee", StringUtil.Replace("aabbccddbbee", "b", "ff", 2));
            Assert.Equal("aabbccddbbee", StringUtil.Replace("aabbccddbbee", "aa", "ff", 0));
            Assert.Equal("aaffccddffee", StringUtil.Replace("aabbccddbbee", "bb", "ff", -1));
            Assert.Equal("ffaabbcc", StringUtil.Replace("aaaabbcc", "aa", "ff", 1));
            Assert.Equal("/test+path=1&name=2", StringUtil.Replace("/test?path=1&name=2", "?", "+", 1));
            Assert.Equal("/test+path+name", StringUtil.Replace("/test?path?name", "?", "+", null));
            Assert.Equal("/test+path+name", StringUtil.Replace("/test?path?name", "?", "+", -1));
            Assert.Equal(new List<string> { "/test", "path?name" }, StringUtil.Split("/test?path?name", "?", 2));
        }

        [Fact]
        public void Test_Contains()
        {
            Assert.False(StringUtil.Contains(null, "s"));
            Assert.False(StringUtil.Contains("test", "abcd"));
            Assert.True(StringUtil.Contains("test", "s"));
        }

        [Fact]
        public void Test_Count()
        {
            Assert.Equal(0, StringUtil.Count(null, "t"));
            Assert.Equal(2, StringUtil.Count("test", "t"));
            Assert.Equal(0, StringUtil.Count("test", "abcd"));
        }

        [Fact]
        public void Test_HasPrefix()
        {
            Assert.False(StringUtil.HasPrefix(null, "tes"));
            Assert.True(StringUtil.HasPrefix("test", "tes"));
            Assert.False(StringUtil.HasPrefix("test", "es"));
        }


        [Fact]
        public void Test_HasSuffix()
        {
            Assert.False(StringUtil.HasSuffix(null, "est"));
            Assert.True(StringUtil.HasSuffix("test", "est"));
            Assert.False(StringUtil.HasSuffix("test", "tes"));
        }

        [Fact]
        public void Test_Index()
        {
            Assert.Equal(-1, StringUtil.Index(null, "s"));
            Assert.Equal(-1, StringUtil.Index("test", "a"));
            Assert.Equal(2, StringUtil.Index("test", "s"));
        }

        [Fact]
        public void Test_ToLower()
        {
            Assert.Null(StringUtil.ToLower(null));
            Assert.Equal("test", StringUtil.ToLower("Test"));
        }

        [Fact]
        public void Test_ToUpper()
        {
            Assert.Null(StringUtil.ToUpper(null));
            Assert.Equal("TEST", StringUtil.ToUpper("Test"));
        }

        [Fact]
        public void Test_SubString()
        {
            Assert.Null(StringUtil.SubString(null, 0, 3));
            Assert.Equal("tes", StringUtil.SubString("test", 0, 3));
            Assert.Equal("es", StringUtil.SubString("test", 1, 3));
            Assert.Equal("est", StringUtil.SubString("test", 1, 4));
            Assert.Equal("", StringUtil.SubString("test", 3, 0));
        }

        [Fact]
        public void Test_Equals()
        {
            Assert.Equal(true, StringUtil.Equals("abc", "abc"));
            Assert.Equal(false, StringUtil.Equals("abc", "ab"));
        }

        [Fact]
        public void Test_Trim()
        {
            Assert.Equal("abc", StringUtil.Trim("  abc   "));
            Assert.Equal("abc", StringUtil.Trim("\t\nabc\t\t\t\n"));
        }

        [Fact]
        public void Test_ToBytes()
        {
            Assert.Equal(49, StringUtil.ToBytes("123", "utf-8")[0]);
        }
    }
}
