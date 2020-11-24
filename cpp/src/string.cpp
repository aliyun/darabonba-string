// This file is auto-generated, don't edit it. Thanks.

#include <boost/algorithm/string.hpp>
#include <darabonba/string.hpp>
#include <iostream>
#include <vector>

using namespace std;

using namespace Darabonba_String;

vector<string> Darabonba_String::Client::split(shared_ptr<string> raw,
                                               shared_ptr<string> sep,
                                               shared_ptr<int> limit) {
  vector<string> split_str;
  boost::split(split_str, *raw, boost::is_any_of(*sep));
  if (!limit || *limit < 0) {
    return split_str;
  } else {
    vector<string> result = vector<string>(split_str.begin(), split_str.begin() + *limit);
    vector<string> join_str = vector<string>(split_str.begin() + *limit, split_str.end());
    result.push_back(boost::join(join_str, *sep));
    return result;
  }
}

string Darabonba_String::Client::replace(shared_ptr<string> raw,
                                         shared_ptr<string> oldStr,
                                         shared_ptr<string> newStr,
                                         shared_ptr<int> count) {
  string result;
  if (raw && oldStr && newStr) {
    if (count) {
      while (*count > 0) {
        raw->replace(raw->find(*oldStr), 1, *newStr);
        (*count)--;
      }
      return *raw;
    } else {
      result = boost::replace_all_copy(*raw, *oldStr, *newStr);
    }
  }
  return result;
}

bool Darabonba_String::Client::contains(shared_ptr<string> s,
                                        shared_ptr<string> substr) {
  if (s && substr) {
    if (s->find(*substr) != std::string::npos) {
      return true;
    }
  }
  return false;
}

int Darabonba_String::Client::count(shared_ptr<string> s,
                                    shared_ptr<string> substr) {

  int result = 0;
  if (s && substr) {
    std::string::size_type i = s->find(*substr);
    while (i != std::string::npos)
    {
      result++;
      i = s->find(*substr, i+substr->length());
    }
  }
  return result;
}

bool Darabonba_String::Client::hasPrefix(shared_ptr<string> s,
                                         shared_ptr<string> prefix) {
  if (s && prefix) {
    return boost::starts_with(*s, *prefix);
  }
  return false;
}

bool Darabonba_String::Client::hasSuffix(shared_ptr<string> s,
                                         shared_ptr<string> substr) {
  if (s && substr) {
    return boost::ends_with(*s, *substr);
  }
  return false;
}

int Darabonba_String::Client::index(shared_ptr<string> s,
                                    shared_ptr<string> substr) {
  int i = -1;
  if (s && substr) {
    i = s->find(*substr);
  }
  return i;
}

string Darabonba_String::Client::toLower(shared_ptr<string> s) {
  string result;
  if (s) {
    result = boost::to_lower_copy(*s);
  }
  return result;
}

string Darabonba_String::Client::toUpper(shared_ptr<string> s) {
  string result;
  if (s) {
    result = boost::to_upper_copy(*s);
  }
  return result;
}

string Darabonba_String::Client::subString(shared_ptr<string> s,
                                           shared_ptr<int> start,
                                           shared_ptr<int> end) {
  if (s && start && end) {
    return s->substr(*start, *end - *start);
  }
}
