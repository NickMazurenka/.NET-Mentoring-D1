using Microsoft.Practices.Unity;

namespace MvcMusicStore.Services
{
	public sealed class IocContainer : UnityContainer
	{
		private static volatile IocContainer _instance;
		private static readonly object SyncRoot = new object();

		public static IocContainer Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (SyncRoot)
					{
						if (_instance == null)
						{
							_instance = new IocContainer();
							UnityConfig.RegisterTypes(_instance);
						}
					}
				}
				return _instance;
			}
		}
	}
}
