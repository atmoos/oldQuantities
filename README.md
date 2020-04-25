# Quantities
A library to safely handle various types of quantities, typically physical quantities.

# Sample
```csharp
using Quantities;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Accepted;
using Quantities.Unit.Imperial.Length;
using Quantities.Prefixes;

// ...
/* a) Easy creation of and operation on quantities */
Length macroscopic = Length.Si<Kilo, Metre>(6378.16);
Length microscopic = Length.Si<Micro, Metre>(0.89);
Length nonSiUnit = Length.Imperial<Foot>(1737.1);
Length sum = macroscopic + microscopic + nonSiUnit;
Console.WriteLine($"{macroscopic} + {microscopic} + {nonSiUnit} = {sum:g8}");
// Writes: 6378.16 Km + 0.89 μm + 1737.1 ft = 6378.6895 Km

/* b) Combine quantities to form other quantities */
/* b.i) Length -> Volume */
Length width = Length.Si<Deci, Metre>(3.1415);
Length height = Length.Imperial<Mile>(27.18);
Length depth = Length.Si<Kilo, Metre>(33);
Volume volume = width * height * depth;
Console.WriteLine($"{width} * {height} * {depth} = {volume:g4}");
// Writes: 3.1415 dm * 27.18 mi * 33 Km = 0.4535 Km³

/* b.ii) Length & Time -> Velocity */
// indirect (computation) of velocity
Length distance = Length.Si<Kilo, Metre>(160.9344);
Time duration = Time.Seconds(7200);
Velocity velocity = distance / duration;
// direct (creation) of velocity
Velocity otherVelocity = Velocity.Imperial<Mile>(50).Per<Hour>();

// which represent the same linear velocity
String comparison = velocity.Equals(otherVelocity) ? "yes" : "no";
Console.WriteLine($"Is {velocity} equal to {otherVelocity}? -> {comparison}");
// Writes: Is 0.022352 Km/s equal to 50 mi/h? -> yes

/* c) Transform quantities to other representations */
Velocity velInKmph = velocity.To<Kilo, Metre>().Per<Hour>();
Velocity velInMiph = velocity.ToImperial<Mile>().Per<Hour>();
Console.WriteLine($"{velInKmph} and {velInMiph} are equal velocities");
// Writes: 80.4672 Km/h and 50 mi/h are equal velocities
```

# Project Goals
## A Generic API 
This is primarily a project that lets me explore how far one can push C#'s generics in an API. The goal is to create "some" api where generics apply naturally and enhance readability. On the flip side, some implementation details in this library are plain out scary and weird, but heaps of fun to explore.

## Why Physical Quantities?
Using physical quantities as test subject seemed appropriate, as there are a limited number of units and SI-prefixes. Using generics, these prefixes and units can be combined neatly to create all sorts of representations of quantities. The generic constraints then allow for the API to restrict the prefixes and units to a subset that actually make sense on a particular quantity.
A concrete example helps to illustrate that point: A length may be represented in the SI-unit of metres or imperial units feet, but not with a unit that is used to represent time. Furthermore, it is standard usage to use the SI-units with prefixes, such as "Kilo" or "Milli", but not on imperial units. Hence, the generic constraints are set appropriately.

## Should I Use It?
It turns out the API goals could largely be achieved. So from an API point of view this library may be useful and may help solve real world problems.
From an implementation point of view the picture is quite different. This library is neither fast nor particularly memory efficient. Also, maintainability of the implementation is not straight forward as there are a number of quirky concepts that require a deep understanding of C#'s generics and how the CLR handles generics at runtime.
Just to give you a pointer to some weirdness: Check out type injection on the [IInjectable](measures/Core/Injectables.cs) interfaces!

So currently I'd advise **not** to use this library. But if you would like to collaborate, send me an email :-)

# To Do
  * Add more quantities and units
  * Benchmark and improve memory efficiency
  * Benchmark and improve (computational) efficiency without sacrificing precision
  * Investigate serialisation and de-serialisation

# See Also
<other projects>
