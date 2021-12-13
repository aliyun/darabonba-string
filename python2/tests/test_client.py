import unittest

from alibabacloud_darabonba_string.client import Client


class TestClient(unittest.TestCase):
    def test_split(self):
        expected = ['py', 'js', 'go', 'c', 'java']
        self.assertEqual(expected, Client.split('py|js|go|c|java', '|', None))

        expected = ['py', 'js|go|c|java']
        self.assertEqual(expected, Client.split('py|js|go|c|java', '|', 2))

        expected = ['/test', 'path=1&name=2']
        self.assertEqual(expected, Client.split('/test?path=1&name=2', '?', 2))

        self.assertEqual(3, len(Client.split('/test?path?name', '?', None)))

        self.assertEqual(['/test', 'path?name'], Client.split('/test?path?name', '?', 2))

    def test_replace(self):
        expected = 'py/js/go/c/java'
        self.assertEqual(expected, Client.replace('py|js|go|c|java', '|', '/', None))

        expected = '|py|js|go|c|java'
        self.assertEqual(expected, Client.replace('|py|js|go|c|java', '|', '/', 0))

        expected = 'py/js|go|c|java'
        self.assertEqual(expected, Client.replace('py|js|go|c|java', '|', '/', 1))

        expected = 'py/js/go|c|java'
        self.assertEqual(expected, Client.replace('py|js|go|c|java', '|', '/', 2))

        expected = 'py/js/go/c|java'
        self.assertEqual(expected, Client.replace('py|js|go|c|java', '|', '/', 3))

        expected = 'py/js/go/c/java'
        self.assertEqual(expected, Client.replace('py|js|go|c|java', '|', '/', 4))

        expected = 'py/js/go/c/java'
        self.assertEqual(expected, Client.replace('py|js|go|c|java', '|', '/', 5))

        expected = '/test+path=1&name=2'
        self.assertEqual(expected, Client.replace('/test?path=1&name=2', '?', '+', 1))

        expected = '/test+path+name'
        self.assertEqual(expected, Client.replace('/test?path?name', '?', '+', -1))

    def test_contains(self):
        self.assertTrue(Client.contains('py|js|go|c|java', 'java'))
        self.assertFalse(Client.contains('py|js|go|c|java', 'php'))

    def test_count(self):
        self.assertEqual(2, Client.count('py|js|go|c|java', 'j'))
        self.assertEqual(0, Client.count('py|js|go|c|java', 'ts'))

    def test_has_prefix(self):
        self.assertTrue(Client.has_prefix('py|js|go|c|java', 'py'))
        self.assertFalse(Client.has_prefix('py|js|go|c|java', 'java'))

    def test_has_suffix(self):
        self.assertFalse(Client.has_suffix('py|js|go|c|java', 'py'))
        self.assertTrue(Client.has_suffix('py|js|go|c|java', 'java'))

    def test_index(self):
        self.assertEqual(3, Client.index('py|js|go|c|java', 'js'))
        self.assertEqual(11, Client.index('py|js|go|c|java', 'java'))
        self.assertEqual(-1, Client.index('py|js|go|c|java', 'php'))

    def test_to_lower(self):
        self.assertEqual('python', Client.to_lower('PYTHON'))
        self.assertFalse('PYTHON' == Client.to_lower('PYTHON'))

    def test_to_upper(self):
        self.assertEqual('PYTHON', Client.to_upper('python'))
        self.assertFalse('python' == Client.to_upper('python'))

    def test_sub_string(self):
        self.assertEqual('py|', Client.sub_string('py|js|go|c|java', 0, 3))
        self.assertEqual('js|go|', Client.sub_string('py|js|go|c|java', 3, 9))

    def test_equals(self):
        self.assertEqual(True, Client.equals('python', 'python'))
        self.assertEqual(False, Client.equals('python', 'py'))

    def test_trim(self):
        self.assertEqual('python', Client.trim('   python     '))
        self.assertEqual('python', Client.trim('\t\npython\t\t\t\n'))

    def test_to_bytes(self):
        self.assertEqual(b'abc', Client.to_bytes('abc', 'utf-8'))
