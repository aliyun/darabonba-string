// This file is auto-generated, don't edit it. Thanks.

#ifndef DARABONBA_STRING_H_
#define DARABONBA_STRING_H_

#include <iostream>
#include <vector>

using namespace std;

namespace Darabonba_String {
class Client {
public:
  static vector<string> split(shared_ptr<string> raw, shared_ptr<string> sep,
                              shared_ptr<int> limit);
  static string replace(shared_ptr<string> raw, shared_ptr<string> oldStr,
                        shared_ptr<string> newStr, shared_ptr<int> count);
  static bool contains(shared_ptr<string> s, shared_ptr<string> substr);
  static int count(shared_ptr<string> s, shared_ptr<string> substr);
  static bool hasPrefix(shared_ptr<string> s, shared_ptr<string> prefix);
  static bool hasSuffix(shared_ptr<string> s, shared_ptr<string> substr);
  static int index(shared_ptr<string> s, shared_ptr<string> substr);
  static string toLower(shared_ptr<string> s);
  static string toUpper(shared_ptr<string> s);
  static string subString(shared_ptr<string> s, shared_ptr<int> start,
                          shared_ptr<int> end);

  Client(){};
};
} // namespace Darabonba_String

#endif
