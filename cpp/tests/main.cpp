#include "gtest/gtest.h"
#include <darabonba/string.hpp>

int main(int argc, char **argv) {
  ::testing::InitGoogleTest(&argc, argv);
  return RUN_ALL_TESTS();
}

TEST(tests_Client, test_split)
{
  shared_ptr<string> raw = make_shared<string>("1=2=3=4=5");
  shared_ptr<string> sep = make_shared<string>("=");
  shared_ptr<int> limit;
  vector<string> result = Darabonba_String::Client::split(raw, sep, limit);
  ASSERT_EQ("5", result[4]);

  limit = make_shared<int>(2);
  vector<string> result1 = Darabonba_String::Client::split(raw, sep, limit);
  ASSERT_EQ("3=4=5", result1[2]);
}

TEST(tests_Client, test_replace)
{
  shared_ptr<string> raw = make_shared<string>("1=2=3=4=5");
  shared_ptr<string> oldStr = make_shared<string>("=");
  shared_ptr<string> newStr = make_shared<string>("@");
  shared_ptr<int> count;
  string result = Darabonba_String::Client::replace(raw, oldStr, newStr, count);
  ASSERT_EQ("1@2@3@4@5", result);

  count = make_shared<int>(2);
  string result1 = Darabonba_String::Client::replace(raw, oldStr, newStr, count);
  ASSERT_EQ("1@2@3=4=5", result1);
}

TEST(tests_Client, test_contains)
{
  bool r1 = Darabonba_String::Client::contains(
      make_shared<string>("hello world"),
      make_shared<string>("hello")
  );

  bool r2 = Darabonba_String::Client::contains(
      make_shared<string>("world"),
      make_shared<string>("hello")
  );

  ASSERT_EQ(true, r1);
  ASSERT_EQ(false, r2);
}

TEST(tests_Client, test_count)
{
  shared_ptr<string> s = make_shared<string>("1=2=3=4=5");
  shared_ptr<string> subStr = make_shared<string>("=");
  int count1 = Darabonba_String::Client::count(s, subStr);
  ASSERT_EQ(4, count1);

  s = make_shared<string>("1=2=3=4=5");
  subStr = make_shared<string>("@");
  int count2 = Darabonba_String::Client::count(s, subStr);
  ASSERT_EQ(0, count2);
}

TEST(tests_Client, test_hasPrefix)
{
  shared_ptr<string> s = make_shared<string>("1=2=3=4=5");
  shared_ptr<string> prefix = make_shared<string>("1=");
  ASSERT_TRUE(Darabonba_String::Client::hasPrefix(s, prefix));

  s = make_shared<string>("1=2=3=4=5");
  prefix = make_shared<string>("=");
  ASSERT_FALSE(Darabonba_String::Client::hasPrefix(s, prefix));
}

TEST(tests_Client, test_hasSuffix)
{
  shared_ptr<string> s = make_shared<string>("1=2=3=4=5");
  shared_ptr<string> subStr = make_shared<string>("=5");
  ASSERT_TRUE(Darabonba_String::Client::hasSuffix(s, subStr));

  s = make_shared<string>("1=2=3=4=5");
  subStr = make_shared<string>("=");
  ASSERT_FALSE(Darabonba_String::Client::hasSuffix(s, subStr));
}

TEST(tests_Client, test_index)
{
  shared_ptr<string> s = make_shared<string>("1=2=3=4=5");
  shared_ptr<string> subStr = make_shared<string>("2");
  ASSERT_EQ(2, Darabonba_String::Client::index(s, subStr));
  subStr = make_shared<string>("=");
  ASSERT_EQ(1, Darabonba_String::Client::index(s, subStr));
  subStr = make_shared<string>("=5");
  ASSERT_EQ(7, Darabonba_String::Client::index(s, subStr));
}

TEST(tests_Client, test_toLower)
{
  ASSERT_EQ("cpp", Darabonba_String::Client::toLower(make_shared<string>("CPP")));
  ASSERT_FALSE("CPP" == Darabonba_String::Client::toLower(make_shared<string>("CPP")));
}

TEST(tests_Client, test_toUpper)
{
  ASSERT_EQ("CPP", Darabonba_String::Client::toUpper(make_shared<string>("cpp")));
  ASSERT_FALSE("cpp" == Darabonba_String::Client::toUpper(make_shared<string>("cpp")));
}

TEST(tests_Client, test_subString)
{
  shared_ptr<string> s = make_shared<string>("py|js|go|c|java");
  shared_ptr<int> start = make_shared<int>(0);
  shared_ptr<int> end = make_shared<int>(3);
  ASSERT_EQ("py|", Darabonba_String::Client::subString(s, start, end));

  start = make_shared<int>(3);
  end = make_shared<int>(9);
  ASSERT_EQ("js|go|", Darabonba_String::Client::subString(s, start, end));
}
