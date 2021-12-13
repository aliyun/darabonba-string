

import * as $tea from '@alicloud/tea-typescript';
import 'mocha';
import assert from 'assert';
import client from '../src/client'
describe('Tea Util', function () {
  it('split should ok', function () {
    let result = client.split('/test?path=1&name=2', '?', null);
    assert.strictEqual(2, result.length);
    result = client.split('/test?path=1&name=2', '?', -1);
    assert.strictEqual(2, result.length);
    result = client.split('/test?path=1&name=2', '?', -10);
    assert.strictEqual(2, result.length);
    result = client.split('/test?path=1&name=2', '?', 0);
    assert.strictEqual(2, result.length);
    result = client.split('/test?path?name?haha', '?', 2);
    assert.deepStrictEqual(['/test', 'path?name?haha'], result);
    result = client.split('/test?path', '?', 1);
    assert.deepStrictEqual(['/test?path'], result);
    result = client.split('aabbccddbbee', 'b', 4)
    assert.deepStrictEqual(['aa', '', 'ccdd', 'bee'], result);
  });

  it('replace should ok', function () {
    assert.strictEqual('a*a*ff*c*c*d*d*bb*e*e', client.replace('a*a*bb*c*c*d*d*bb*e*e', 'bb', 'ff', 1));
    assert.strictEqual('aaffffccddbbee', client.replace('aabbccddbbee', 'b', 'ff', 2));
    assert.strictEqual('aabbccddbbee', client.replace('aabbccddbbee', 'aa', 'ff', 0));
    assert.strictEqual('aaffccddffee', client.replace('aabbccddbbee', 'bb', 'ff', -1));
    assert.strictEqual('ffaabbcc', client.replace('aaaabbcc', 'aa', 'ff', 1));
    assert.strictEqual('/test+path=1&name=2', client.replace('/test?path=1&name=2', '?', '+', 1));
    assert.strictEqual('/test+path+name', client.replace('/test?path?name', '?', '+', null));
    assert.strictEqual('/test+path+name', client.replace('/test?path?name', '?', '+', -1));
  });

  it('contains should ok', function () {
    assert.strictEqual(client.contains('a', 'a'), true);
    assert.strictEqual(client.contains('a', 'b'), false);
  });

  it('count should ok', function () {
    const result = client.count('aba', 'b')
    assert.strictEqual(2, result);
  });

  it('hasPrefix should ok', function () {
    assert.strictEqual(true, client.hasPrefix('abc', 'a'));
    assert.strictEqual(false, client.hasPrefix('abc', 'b'));
  });

  it('hasSuffix should ok', function () {
    assert.strictEqual(true, client.hasSuffix('abc', 'c'));
    assert.strictEqual(false, client.hasSuffix('abc', 'b'));
  });

  it('index should ok', function () {
    const result = client.index('aba', 'b')
    assert.strictEqual(1, result);
  });

  it('toLower should ok', function () {
    assert.strictEqual('s', client.toLower('S'));
  });

  it('toUpper should ok', function () {
    assert.strictEqual('S', client.toUpper('s'));
  });

  it('subString should ok', function () {
    assert.strictEqual('b', client.subString('abc', 1, 2));
    assert.strictEqual('ab', client.subString('abc', 0, -1));
    assert.strictEqual('', client.subString('', 0, -1));
  });

  it('trim should ok', function () {
    assert.strictEqual('S', client.trim(' S '));
  });

  it('toBytes should ok', function () {
    assert.deepStrictEqual(49, client.toBytes('123', 'utf-8')[0]);
  });
})