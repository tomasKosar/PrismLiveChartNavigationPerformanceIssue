using Microsoft.Practices.Unity;

namespace WpfApplication11
{
    internal class UnityContainerFactory : IUnityContainerFactory
    {
        private readonly object instanceLock = new object();
        private IUnityContainer instance;

        public IUnityContainer GetContainer()
        {
            lock (this.instanceLock)
            {
                if (this.instance == null)
                {
                    this.instance = new UnityContainer();
                    this.instance.RegisterInstance<IUnityContainerFactory>(this);
                }
            }

            return this.instance;
        }
    }

    public interface IUnityContainerFactory
    {
        IUnityContainer GetContainer();
    }
}
