package com.aliyun.darabonbastring;

import java.io.UnsupportedEncodingException;
import java.util.Arrays;
import java.util.regex.Pattern;

public class Client {

    public static java.util.List<String> split(String raw, String sep, Integer limit) {
        if (limit == null) {
            return Arrays.asList(raw.split(Pattern.quote(sep)));
        }
        return Arrays.asList(raw.split(Pattern.quote(sep), limit));
    }

    public static String replace(String raw, String oldStr, String newStr, Integer count) {
        if (count == null) {
            return raw.replaceAll(Pattern.quote(oldStr), newStr);
        }
        String[] array = raw.split(Pattern.quote(oldStr), count + 1);
        StringBuilder sb = new StringBuilder();
        if (array.length > 0) {
            sb.append(array[0]);
            for (int i = 1; i < array.length; i++) {
                sb.append(newStr).append(array[i]);
            }
            return sb.toString();
        }
        return raw;
    }

    public static Boolean contains(String s, String substr) {
        return s.contains(substr);
    }

    public static Integer count(String s, String substr) {
        return s.split(substr).length;
    }

    public static Boolean hasPrefix(String s, String prefix) {
        return s.startsWith(prefix);
    }

    public static Boolean hasSuffix(String s, String substr) {
        return s.endsWith(substr);
    }

    public static Integer index(String s, String substr) {
        return s.indexOf(substr);
    }

    public static String toLower(String s) {
        return s.toLowerCase();
    }

    public static String toUpper(String s) {
        return s.toUpperCase();
    }

    public static String subString(String s, Integer start, Integer end) {
        if (end < 0) {
            end = s.length() + end;
        }
        if (end <= 0) {
            return "";
        }
        return s.substring(start, end);
    }

    public static Boolean equals(String expect, String actual) {
        return expect.equals(actual);
    }

    public static String trim(String raw) {
        return raw.trim();
    }

    public static byte[] toBytes(String raw, String encoding) {
        try {
            return raw.getBytes(encoding);
        } catch (UnsupportedEncodingException e) {
            throw new IllegalArgumentException("encoding is not valid");
        }
    }
}


