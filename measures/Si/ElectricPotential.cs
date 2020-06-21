using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class ElectricPotential<TPrefix, TUnit> : SiMeasure<Linear, PrefixedUnit<TPrefix, TUnit>>, IElectricPotential
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, IElectricPotential, new()
    {
    }
}