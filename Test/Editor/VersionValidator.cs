using Chartboost.Editor;
using NUnit.Framework;

namespace Chartboost.Core.Consent.Unmanaged.Tests.Editor
{
    public class VersionValidator
    {
        private const string UnityPackageManagerPackageName = "com.chartboost.core.consent.unmanaged";
        private const string NuGetPackageName = "Chartboost.CSharp.Core.Unity.Consent.Unmanaged";
        
        [Test]
        public void ValidateVersion() 
            => VersionCheck.ValidateVersions(UnityPackageManagerPackageName, NuGetPackageName);
    }
}
