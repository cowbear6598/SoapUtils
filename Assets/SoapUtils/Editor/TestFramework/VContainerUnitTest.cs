using NUnit.Framework;
using VContainer;

namespace SoapUtils.Editor.TestFramework
{
    public abstract class VContainerUnitTest
    {
        protected ContainerBuilder builder;

        [SetUp]
        public virtual void Setup()
        {
            builder = new ContainerBuilder();
        }
    }
}