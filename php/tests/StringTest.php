<?php

namespace AlibabaCloud\Darabonba\String\Tests;

use AlibabaCloud\Darabonba\String\StringUtil;
use PHPUnit\Framework\TestCase;

/**
 * @internal
 * @coversNothing
 */
class StringTest extends TestCase
{
    public function testSplit()
    {
        $this->assertEquals([], StringUtil::split(null, '.', null));
        $this->assertEquals(['a', 'b'], StringUtil::split('a.b', '.', null));
        $this->assertEquals(['a', 'b.c'], StringUtil::split('a.b.c', '.', 2));
        $this->assertEquals(['a', 'b?c'], StringUtil::split('a?b?c', '?', 2));
    }

    public function testReplace()
    {
        $this->assertEquals(
            'this is test string',
            StringUtil::replace('this is test string', 'not exist', 'abcd')
        );
        $this->assertEquals(
            'this is abcd string',
            StringUtil::replace('this is test string', 'test', 'abcd')
        );
        $this->assertEquals(
            'this is abcd string',
            StringUtil::replace('this is abcd string', 'i', 'z', 0)
        );
        $this->assertEquals(
            'thzs zs abcd strzng',
            StringUtil::replace('this is abcd string', 'i', 'z', 2)
        );
    }

    public function testContains()
    {
        $this->assertFalse(StringUtil::contains('test', 'abcd'));
        $this->assertTrue(StringUtil::contains('test', 's'));
    }

    public function testCount()
    {
        $this->assertEquals(2, StringUtil::count('test', 't'));
        $this->assertEquals(0, StringUtil::count('test', 'abcd'));
    }

    public function testHasPrefix()
    {
        $this->assertFalse(StringUtil::hasPrefix('test', 'est'));
        $this->assertTrue(StringUtil::hasPrefix('test', 'tes'));
    }

    public function testHasSuffix()
    {
        $this->assertFalse(StringUtil::hasSuffix('test', 'tes'));
        $this->assertTrue(StringUtil::hasSuffix('test', 'est'));
    }

    public function testIndex()
    {
        $this->assertEquals(-1, StringUtil::index('test', 'a'));
        $this->assertEquals(2, StringUtil::index('test', 's'));
    }

    public function testToLower()
    {
        $this->assertEquals('test', StringUtil::toLower('Test'));
    }

    public function testToUpper()
    {
        $this->assertEquals('TEST', StringUtil::toUpper('Test'));
    }

    public function testSubString()
    {
        $this->assertEquals('Tes', StringUtil::subString('Test', 0, 3));
        $this->assertEquals('es', StringUtil::subString('Test', 1, 3));
        $this->assertEquals('Test', StringUtil::subString('Test', 0, 4));
        $this->assertEquals('', StringUtil::subString('Test', 5, 1));
    }

    public function testTrim()
    {
        $this->assertEquals('Test', StringUtil::trim('Test '));
        $this->assertEquals('Test', StringUtil::trim(' Test'));
    }

    public function testToBytes()
    {
        $this->assertEquals([
            115, 116, 114, 105, 110, 103,
        ], StringUtil::toBytes('string'));
    }

    public function testEquals()
    {
        $this->assertEquals(false, StringUtil::equals('string','bytes'));
        $this->assertEquals(true,  StringUtil::equals('string','string'));
        $this->assertEquals(false, StringUtil::equals('false',0));
        $this->assertEquals(false, StringUtil::equals('true',true));
        $this->assertEquals(false, StringUtil::equals('true',NULL));
    }
}
