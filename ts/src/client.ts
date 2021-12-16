// This file is auto-generated, don't edit it
/**
 * This is a string module
 */


export default class Client {

  static split(raw: string, sep: string, limit: number): string[] {
    if (null === limit || typeof (limit) === 'undefined' || limit < 1) {
      return raw.split(sep);
    }
    let result = raw.split(sep, limit)
    if (result.length >= limit) {
      result[limit - 1] = [result[limit - 1], ...raw.split(sep).splice(limit)].join(sep)
    }
    return result;
  }

  static replace(raw: string, oldStr: string, newStr: string, count: number = null): string {
    if (null === count || typeof (count) === 'undefined' || count < 0) {
      return raw.split(oldStr).join(newStr);
    }
    let tmp = raw.split(oldStr);
    if (count >= tmp.length - 1) {
      return raw.split(oldStr).join(newStr);
    }
    let left = tmp.slice(0, count + 1).join(newStr);
    let right = tmp.slice(count + 1).join(oldStr);
    return left + oldStr + right;
  }

  static contains(s: string, substr: string): boolean {
    return s.indexOf(substr) !== -1;
  }

  static count(s: string, substr: string): number {
    return s.split(substr).length;
  }

  static hasPrefix(s: string, prefix: string): boolean {
    return s.startsWith(prefix);
  }

  static hasSuffix(s: string, substr: string): boolean {
    return s.endsWith(substr);
  }

  static index(s: string, substr: string): number {
    return s.indexOf(substr);
  }

  static toLower(s: string): string {
    return s.toLowerCase();
  }

  static toUpper(s: string): string {
    return s.toUpperCase();
  }

  static subString(s: string, strat: number, end: number): string {
    return s.slice(strat, end);
  }

  static equals(expect: string, actual: string): boolean {
    return expect === actual;
  }

  static trim(str: string): string {
    return str.trim();
  }

  static toBytes(str: string, encoding: BufferEncoding): Buffer {
    return Buffer.from(str, encoding);
  }


}
