using System;
using Quantities;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Accepted;
using Quantities.Unit.Imperial.Length;
using Quantities.Prefixes;

namespace sample
{
    class Program
    {
        static void Main(string[] args)
        {            /* a) Easy creation of and operation on quantities */
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
        }
    }
}
