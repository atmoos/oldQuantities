using Quantities.Unit.Transformation;

namespace Quantities.Unit
{
    // ToDo: Deal with non SI units a more elegantly
    public interface INonSiUnit : IUnit, ITransform { /* marker interface */ }
}