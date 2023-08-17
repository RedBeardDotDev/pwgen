# pwgen

A simple password generator. An attempt at something like https://github.com/tytso/pwgen

```
Description:
  Password Generator

Usage:
  pwgen [options]

Options:
  --alpha            Lowercase letters [a..z] [default: True]
  --ALPHA            Capital letters [A..Z] [default: True]
  --numbers          Numbers [0..9] [default: True]
  --special          Special characters [!@#$%^&*()...] - ASCII values 33..47, 58..64, 91..96, 123..126 [default: True]
  --count <count>    The number of passwords you want generated [default: 10]
  --length <length>  The the length of the passwords to be generated [default: 12]
  --verbose          Prints additional information [default: False]
  --version          Show version information
  -?, -h, --help     Show help and usage information
```