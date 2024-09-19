using System.Collections.Generic;
using Chartboost.Core.Consent;

namespace Chartboost.Core.Unmanaged
{
    public interface IUnmanagedConsentAdapter
    {
        bool ShouldCollectConsent { get; set; }
        
        IReadOnlyDictionary<ConsentKey, ConsentValue> Consents { get; set; }
    }
}
