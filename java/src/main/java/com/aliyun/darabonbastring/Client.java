package com.aliyun.darabonbastring;

import java.util.Arrays;

public class Client {

    public static java.util.List<String> split(String raw, String sep, Integer limit) {
        return Arrays.asList(raw.split(sep, limit));
    }

    public static String replace(String raw, String oldStr, String newStr, Integer index) {
        int times = -1;
        int newStrLength = newStr.length();
        int stringIndex = -newStrLength;
        while (times < index) {
            stringIndex = raw.indexOf(oldStr, stringIndex + newStrLength);
            times++;
        }
        if (stringIndex > -1) {
            String needRepace = raw.substring(stringIndex);
            String replaceStr = needRepace.replace(oldStr, newStr);
            return raw.replace(needRepace, replaceStr);
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
        return s.substring(start, end);
    }
}


