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
    }

    @Test
    public void replaceTest() {
        Assert.assertEquals("a*a*bb*c*c*d*d*ff*e*e", Client.replace("a*a*bb*c*c*d*d*bb*e*e", "bb", "ff", 1));
        Assert.assertEquals("aabbccddbbee", Client.replace("aabbccddbbee", "b", "ff", 2));
        Assert.assertEquals("ffbbccddbbee", Client.replace("aabbccddbbee", "aa", "ff", 0));
        Assert.assertEquals("aabbccddbbff", Client.replace("aabbccddbbee", "ee", "ff", 0));
        Assert.assertEquals("aaffbbcc", Client.replace("aaaabbcc", "aa", "ff", 1));
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
}
