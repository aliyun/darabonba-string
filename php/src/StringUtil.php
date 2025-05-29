<?php

namespace AlibabaCloud\Darabonba\String;

/**
 * This is a string module.
 */
class StringUtil
{
    /**
     * @param string   $raw
     * @param string   $sep
     * @param null|int $limit
     *
     * @return array
     */
    public static function split($raw, $sep, $limit = null)
    {
        if (empty($raw)) {
            return [];
        }

        return null === $limit ? explode($sep, $raw) : explode($sep, $raw, $limit);
    }

    /**
     * @param string $raw
     * @param string $oldStr
     * @param string $newStr
     * @param int    $index
     *
     * @return string
     */
    public static function replace($raw, $oldStr, $newStr, $index = null)
    {
        if (0 === $index) {
            return $raw;
        }

        return str_replace(
            self::_value($oldStr),
            self::_value($newStr),
            self::_value($raw),
            $index
        );
    }

    /**
     * @param string $s
     * @param string $substr
     *
     * @return bool
     */
    public static function contains($s, $substr)
    {
        return false !== strpos(self::_value($s), self::_value($substr));
    }

    /**
     * @param string $s
     * @param string $substr
     *
     * @return int
     */
    public static function count($s, $substr)
    {
        return substr_count(self::_value($s), self::_value($substr));
    }

    /**
     * @param string $s
     * @param string $prefix
     *
     * @return bool
     */
    public static function hasPrefix($s, $prefix)
    {
        return 0 === strpos(self::_value($s), self::_value($prefix));
    }

    /**
     * @param string $s
     * @param string $substr
     *
     * @return bool
     */
    public static function hasSuffix($s, $substr)
    {
        $s      = self::_value($s);
        $substr = self::_value($substr);
        $length = \strlen($substr);
        if (!$length) {
            return true;
        }

        return substr($s, -$length) === $substr;
    }

    /**
     * @param string $s
     * @param string $substr
     *
     * @return int
     */
    public static function index($s, $substr)
    {
        $s      = self::_value($s);
        $substr = self::_value($substr);
        $index  = strpos($s, $substr);

        return false === $index ? -1 : $index;
    }

    /**
     * @param string $s
     *
     * @return \string
     */
    public static function toLower($s)
    {
        $s = self::_value($s);

        return strtolower($s);
    }

    /**
     * @param string $s
     *
     * @return \string
     */
    public static function toUpper($s)
    {
        $s = self::_value($s);

        return strtoupper($s);
    }

    /**
     * @param string $s
     * @param int    $start
     * @param int    $end
     *
     * @return \string
     */
    public static function subString($s, $start, $end)
    {
        return substr($s, $start, $end - $start);
    }

    private static function _value($value, $default = '')
    {
        return null === $value ? $default : $value;
    }

    public static function equals($expect, $actual)
    {
        return false == strcmp(self::_value($expect), self::_value($actual));
    }

    public static function trim($str)
    {
        return trim($str);
    }

    public static function toBytes($str)
    {
        $bytes = [];
        for ($i = 0; $i < \strlen($str); ++$i) {
            $bytes[] = \ord($str[$i]);
        }

        return $bytes;
    }
}
