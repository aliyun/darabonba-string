package client

import (
	"testing"

	"github.com/alibabacloud-go/tea/tea"
	"github.com/alibabacloud-go/tea/utils"
)

func Test_Split(t *testing.T) {
	strs := Split(tea.String("abcdca"), tea.String("c"), nil)
	utils.AssertEqual(t, len(strs), 3)
	utils.AssertEqual(t, tea.StringValue(strs[0]), "ab")
	utils.AssertEqual(t, tea.StringValue(strs[1]), "d")
	utils.AssertEqual(t, tea.StringValue(strs[2]), "a")
	strs = Split(tea.String("/test?path=1&name=2"), tea.String("?"), nil)
	utils.AssertEqual(t, []string{"/test", "path=1&name=2"}, tea.StringSliceValue(strs))
	strs = Split(tea.String("abcdca"), tea.String("c"), tea.Int(2))
	utils.AssertEqual(t, len(strs), 2)
	utils.AssertEqual(t, tea.StringValue(strs[0]), "ab")
	utils.AssertEqual(t, tea.StringValue(strs[1]), "dca")
}

func Test_Replace(t *testing.T) {
	tmp := Replace(tea.String("ab d e f"), tea.String(" "), tea.String("c"), tea.Int(1))
	utils.AssertEqual(t, tea.StringValue(tmp), "abcd e f")
	tmp = Replace(tea.String("a*a*ff*c*c*d*d*bb*e*e"), tea.String("ff"), tea.String("bb"), nil)
	utils.AssertEqual(t, "a*a*bb*c*c*d*d*bb*e*e", tea.StringValue(tmp))
	tmp = Replace(tea.String("ab d e f"), tea.String(" "), tea.String("c"), tea.Int(5))
	utils.AssertEqual(t, tea.StringValue(tmp), "abcdcecf")
}
func Test_Contains(t *testing.T) {
	ok := Contains(tea.String("abcd"), tea.String("ab"))
	utils.AssertEqual(t, tea.BoolValue(ok), true)
}
func Test_Count(t *testing.T) {
	num := Count(tea.String("abcccd"), tea.String("c"))
	utils.AssertEqual(t, tea.IntValue(num), 3)
}
func Test_HasPrefix(t *testing.T) {
	ok := HasPrefix(tea.String("abcd"), tea.String("ab"))
	utils.AssertEqual(t, tea.BoolValue(ok), true)

	ok = HasPrefix(tea.String("abcd"), tea.String("b"))
	utils.AssertEqual(t, tea.BoolValue(ok), false)
}
func Test_HasSuffix(t *testing.T) {
	ok := HasSuffix(tea.String("abc  d"), tea.String("c"))
	utils.AssertEqual(t, tea.BoolValue(ok), false)

	ok = HasSuffix(tea.String("abc  d"), tea.String("d"))
	utils.AssertEqual(t, tea.BoolValue(ok), true)
}
func Test_Index(t *testing.T) {
	tmp := Index(tea.String("abcd"), tea.String("c"))
	utils.AssertEqual(t, tea.IntValue(tmp), 2)
}
func Test_ToLower(t *testing.T) {
	tmp := ToLower(tea.String("aBCd"))
	utils.AssertEqual(t, tea.StringValue(tmp), "abcd")
}

func Test_ToUpper(t *testing.T) {
	tmp := ToUpper(tea.String("abcd"))
	utils.AssertEqual(t, tea.StringValue(tmp), "ABCD")
}

func Test_SubString(t *testing.T) {
	tmp := SubString(tea.String("abcd"), tea.Int(0), tea.Int(2))
	utils.AssertEqual(t, tea.StringValue(tmp), "ab")

	tmp = SubString(tea.String("abcd"), tea.Int(0), tea.Int(-1))
	utils.AssertEqual(t, tea.StringValue(tmp), "abc")
}

func TestToBytes(t *testing.T) {
	res := ToBytes(tea.String("123"), nil)
	utils.AssertEqual(t, []byte{49, 50, 51}, res)
}

func TestTrim(t *testing.T) {
	res := Trim(tea.String(" b    "))
	utils.AssertEqual(t, "b", tea.StringValue(res))
}
