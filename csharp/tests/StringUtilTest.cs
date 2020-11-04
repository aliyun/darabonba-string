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
        }

        [Fact]
        public void Test_Replace()
        {
            Assert.Null(StringUtil.Replace(null, "bb", "ff"));
            Assert.Equal("aaffccddffee", StringUtil.Replace("aabbccddbbee", "bb", "ff"));
            Assert.Equal("aabbccddffee", StringUtil.Replace("aabbccddbbee", "bb", "ff", 1));
            Assert.Equal("aabbccddbbee", StringUtil.Replace("aabbccddbbee", "bb", "ff", 2));
            Assert.Equal("ffbbccddbbee", StringUtil.Replace("aabbccddbbee", "aa", "ff", 0));
            Assert.Equal("aabbccddbbff", StringUtil.Replace("aabbccddbbee", "ee", "ff", 0));
            Assert.Equal("aaffbbcc", StringUtil.Replace("aaaabbcc", "aa", "ff", 1));
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
            Assert.Equal("test", StringUtil.SubString("test", 0, 3));
            Assert.Equal("est", StringUtil.SubString("test", 1, 3));
            Assert.Equal("est", StringUtil.SubString("test", 1, 4));
            Assert.Equal("", StringUtil.SubString("test", 3, 0));
        }
    }
}
