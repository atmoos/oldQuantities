using System;
using Quantities.Unit;
using Quantities.Measures.Core;

// ToDo: Merger INormalise and ITransform?

namespace Quantities.Measures.Other.Core
{
    internal sealed class SiWrapper<TSiMeasure> : IUnit, ITransform
        where TSiMeasure : SiMeasure, new()
    {
        private static readonly TSiMeasure SI_MEASURE = Pool<TSiMeasure>.Item;
        public Double FromSi(in Double siValue) => SI_MEASURE.Renormalise(in siValue);
        public Double ToSi(in Double nonSiValue) => SI_MEASURE.Normalise(in nonSiValue);
    }
}