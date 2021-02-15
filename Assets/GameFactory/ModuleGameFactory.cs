using TestProject.DevOOP.Units.Modules;

namespace TestProject.DevOOP.Factory
{
    /// <summary>
    /// This class contains all unit modules.
    /// </summary>
    /// <remarks>
    /// <para>Don't fogget register new ctor prototype-object in storage!</para>
    /// Use function - <see cref="BaseGameFactory{K, T}.RegisterPrototype(K, System.Func{T})"/>
    /// </remarks>
    /// 
    internal sealed class ModuleGameFactory : BaseGameFactory<ModuleType, IUnitModule>
    {
        internal ModuleGameFactory() : base()
        {
            RegisterPrototype(ModuleType.Visual, () => new UnitVisualModule());
            RegisterPrototype(ModuleType.Physics, () => new UnitPhysicModule());
            RegisterPrototype(ModuleType.Navigation, () => new UnitNavigationModule());
        }
    }
}