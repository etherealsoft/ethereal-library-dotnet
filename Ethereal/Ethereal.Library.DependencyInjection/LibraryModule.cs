using Autofac;

namespace Ethereal.Library.DependencyInjection
{
  public class LibraryModule : Module
  {
      protected override void Load(ContainerBuilder builder)
      {
          builder.RegisterType<SystemTime>().As<ISystemTime>().SingleInstance();
          builder.RegisterType<Invariant>().As<IInvariant>().SingleInstance();
      }
  }
}
