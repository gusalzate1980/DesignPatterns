using Patrones;
using Patrones.Comportamiento;
using Patrones.Creacional;
using Patrones.Estructural;

DesignPattern activeDesignPatter = DesignPattern.Decorator;
IDesignPattern pattern = FactoryMethod.CreateObject(activeDesignPatter);


pattern.ExecutePattern();

public enum DesignPattern
{
    Decorator,
    ChainResponsability,
    Adapter,
    Composite,
    AbstractFactory,
    Command
}

public static class FactoryMethod
{
    public static IDesignPattern CreateObject(DesignPattern design)
    {
        switch (design)
        {
            case DesignPattern.AbstractFactory: return new AbstractFactory();
            case DesignPattern.Adapter: return new Adapter();
            case DesignPattern.ChainResponsability: return new ChainResponsability();
            case DesignPattern.Command: return new Command();
            case DesignPattern.Composite: return new Composite();
            case DesignPattern.Decorator: return new Decorator();
            
            default: return new Command();
        }
    }
}
