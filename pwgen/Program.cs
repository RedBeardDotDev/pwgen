// See https://aka.ms/new-console-template for more information

using pwgen;
using System.CommandLine;

var rootCommand = new RootCommand("Password Generator");

var alphaOption = new Option<bool>(
            name: "--alpha",
            description: "Lowercase letters [a..z]",
            getDefaultValue: () => true
        );
var ALPHAOption = new Option<bool>(
            name: "--ALPHA",
            description: "Uppercase letters [A..Z]",
            getDefaultValue: () => true
        );
var numbersOption = new Option<bool>(
            name: "--numbers",
            description: "Numbers [0..9]",
            getDefaultValue: () => true
        );
var specialOption = new Option<bool>(
            name: "--special",
            description: "Special characters [!@#$%^&*()...] - ASCII values 33..47, 58..64, 91..96, 123..126",
            getDefaultValue: () => true
        );
var countOption =
        new Option<int>(
            name: "--count",
            description: "The number of passwords you want generated",
            getDefaultValue: () => 10
        );
var lengthOption = new Option<int>(
            name: "--length",
            description: "The the length of the passwords to be generated",
            getDefaultValue: () => 12
    );
var verboseOption = new Option<bool>(
            name: "--verbose",
            description: "Prints additional information",
            getDefaultValue: () => false
    );

rootCommand.AddOption(alphaOption);
rootCommand.AddOption(ALPHAOption);
rootCommand.AddOption(numbersOption);
rootCommand.AddOption(specialOption);
rootCommand.AddOption(countOption);
rootCommand.AddOption(lengthOption);
rootCommand.AddOption(verboseOption);

rootCommand.SetHandler((alpha, ALPHA, numbers, special, count, length, verbose) => {
    var pws = Utils.GeneratePasswords(alpha, ALPHA, numbers, special, count, length);

    if (verbose) {
        Console.WriteLine($"Input Parameters:");
        Console.WriteLine($"-----------------");
        Console.WriteLine($"alpha:   {alpha}");
        Console.WriteLine($"ALPHA:   {ALPHA}");
        Console.WriteLine($"numbers: {numbers}");
        Console.WriteLine($"special: {special}");
        Console.WriteLine($"count:   {count}");
        Console.WriteLine($"length:  {length}");

        Console.WriteLine($"");
        Console.WriteLine("Passwords:");
        Console.WriteLine("----------");
    }

    foreach (var pw in pws) {
        Console.WriteLine($"{pw}");
    }
}, alphaOption, ALPHAOption, numbersOption, specialOption, countOption, lengthOption, verboseOption);
await rootCommand.InvokeAsync(args);