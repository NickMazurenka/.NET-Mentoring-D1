using Microsoft.Practices.Unity;
using MvcMusicStore.Services;

namespace MvcMusicStore
{
    public static class UnityConfig
	{
		public static void RegisterTypes(IUnityContainer container)
		{
			// Performance counter
			container.RegisterType<IPerformanceCounter, StandardPerformanceCounter>(
				new ContainerControlledLifetimeManager());
		}
	}
}