# Molecules:
* Molecules is a class library targeting the .NETStandard 2.0 and 2.1, and is also available as a Nuget package.
* Simply reference the library/package as preferred, and add the below using
```csharp
using Molecules;
```

## Elements:
* Instances of the `Element` class represent chemical elements.
* 118 static instance are provided on this class, allowing easy access to elements.
* `Element` also implements `IEquatable<Element>` using property comparison.

```csharp
var hydrogen = Element.H;
Console.WriteLine(hydrogen); 
// Output: 1 Hydrogen (H)
```

## Element Collections:
* The `ElementCollection` class implements `ICollection<Element>` but also provides indexers for easy access.
* `ElementCollection` contains a static member `ElementCollection.PeriodicTable` which is an `ElementCollection` formed with the 118 elements mentioned above..

```csharp
var hydrogen = ElementCollection.PeriodicTable["H"]; // Access by symbol
var oxygen = ElementCollection.PeriodicTable[8]; // Access by atomic number.
var carbon = ElementCollection.PeriodicTable[12.0107] // Access by atomic mass.
var nitrogen = ElementCollection.GetByName("Nitrogen"); // Note that this method is case insensitive.
Console.WriteLine(hydrogen);
Console.WriteLine(oxygen); 
Console.WriteLine(carbon); 
Console.WriteLine(nitrogen); 
// Output:
// 1 Hydrogen (H)
// 8 Oxygen (O)
// 6 Carbon (C)
// 7 Nitrogen (N)
```

## Molecules:
* The `Molecule` class is the core of the project.
* It contains no public constructors, but does have static methods: `Molecule.Parse()` and `Molecule.TryParse()` for parsing strings containing chemical formulae.
* The format of strings to be parsed is as follows: 
  - The string may contain letters in either upper or lower case, digits and parentheses - "(" and ")".
  - The character after any parentheses must be a digit or be upper case.
  - Nested parentheses are not yet supported.
* By default, the parsing methods will use `ElementCollection.PeriodicTable` as a reference, but there are overloads to allow users to define an `ElementCollection` to use instead.
```csharp
var water = Molecule.Parse("H2O");
Console.WriteLine(water.Mass);
// Output: 18.01528
```