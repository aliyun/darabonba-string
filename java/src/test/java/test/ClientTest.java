// This file is auto-generated, don't edit it. Thanks.
package test;

import com.aliyun.darabonbastring.Client;
import org.junit.Assert;
import org.junit.Test;

import java.util.List;

public class ClientTest {

    @Test
    public void splitTest() {
        List<String> list = Client.split("aabbccddbbee", "b", 4);
        Assert.assertEquals(4, list.size());
        String str = "?";
        String pathname = "/test?path=1&name=2";
        java.util.List<String> paths = Client.split(pathname, str, null);
        Assert.assertEquals(2, paths.size());
        paths = Client.split(pathname, str, -1);
        Assert.assertEquals(2, paths.size());
        pathname = "/test?path?name";
        paths = Client.split(pathname, str, 2);
        Assert.assertEquals("path?name", paths.get(1));
        paths = Client.split(pathname, str, 0);
        Assert.assertEquals("path", paths.get(1));
    }

    @Test
    public void replaceTest() {
        Assert.assertEquals("a*a*ff*c*c*d*d*bb*e*e", Client.replace("a*a*bb*c*c*d*d*bb*e*e", "bb", "ff", 1));
        Assert.assertEquals("aaffffccddbbee", Client.replace("aabbccddbbee", "b", "ff", 2));
        Assert.assertEquals("aabbccddbbee", Client.replace("aabbccddbbee", "aa", "ff", 0));
        Assert.assertEquals("aaffccddffee", Client.replace("aabbccddbbee", "bb", "ff", -1));
        Assert.assertEquals("ffaabbcc", Client.replace("aaaabbcc", "aa", "ff", 1));
        Assert.assertEquals("/test+path=1&name=2", Client.replace("/test?path=1&name=2", "?", "+", 1));
        Assert.assertEquals("/test+path+name", Client.replace("/test?path?name", "?", "+", null));
        Assert.assertEquals("/test+path+name", Client.replace("/test?path?name", "?", "+", -1));
    }

    @Test
    public void containsTest() {
        Assert.assertTrue(Client.contains("a", "a"));
        Assert.assertFalse(Client.contains("a", "b"));
    }

    @Test
    public void countTest() {
        int result = Client.count("aba", "b");
        Assert.assertEquals(2, result);
    }

    @Test
    public void hasPrefix() {
        Assert.assertTrue(Client.hasPrefix("abc", "a"));
        Assert.assertFalse(Client.hasPrefix("abc", "b"));
    }

    @Test
    public void hasSuffix() {
        Assert.assertTrue(Client.hasSuffix("abc", "c"));
        Assert.assertFalse(Client.hasSuffix("abc", "b"));
    }

    @Test
    public void indexTest() {
        int result = Client.index("aba", "b");
        Assert.assertEquals(1, result);
    }

    @Test
    public void toLower() {
        Assert.assertEquals("s", Client.toLower("S"));
    }

    @Test
    public void toUpper() {
        Assert.assertEquals("S", Client.toUpper("s"));
    }

    @Test
    public void subString() {
        Assert.assertEquals("b", Client.subString("abc", 1, 2));
        Assert.assertEquals("ab", Client.subString("abc", 0, -1));
        Assert.assertEquals("", Client.subString("", 0, -1));
    }

    @Test
    public void equalsTest() {
        Assert.assertEquals(true, Client.equals("abc", "abc"));
        Assert.assertEquals(false, Client.equals("abc", "ab"));
    }

    @Test
    public void trimTest() {
        Assert.assertEquals("b", Client.trim(" b    "));
        Assert.assertEquals("b", Client.trim("\t\nb\t\t\t\n"));
    }

    @Test
    public void toBytesTest() {
        Assert.assertEquals(49, Client.toBytes("123", "utf-8")[0]);
    }
}
