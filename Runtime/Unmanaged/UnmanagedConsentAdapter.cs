using Chartboost.Core.Consent;
using Chartboost.Core.Initialization;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Chartboost.Core.Unmanaged
{
    /// <summary>
    /// 
    /// </summary>
    public class UnmanagedConsentAdapter : NativeModuleWrapper<UnmanagedConsentAdapter>, IUnmanagedConsentAdapter
    {
        private IUnmanagedConsentAdapter UnmanagedInstance
        {
            get
            {
                var adapter = (IUnmanagedConsentAdapter)Instance;
                return adapter;
            }
        }
        
        protected override string DefaultModuleId => "unmanaged_consent_adapter";
        protected override string DefaultModuleVersion => "1.0.0";

        /// <summary>
        ///  Indicates whether the CMP has determined that consent should be collected from the user.
        /// </summary>
        public bool ShouldCollectConsent
        {
            get => UnmanagedInstance.ShouldCollectConsent;
            set => UnmanagedInstance.ShouldCollectConsent = value;
        }

        /// <summary>
        /// <para>
        /// Current user consent info as determined by the CMP.
        /// </para>
        ///
        /// <para>
        /// Consent info may include IAB strings, like TCF or GPP, and parsed boolean-like signals like "CCPA Opt In Sale"
        /// and partner-specific signals.
        /// </para>
        ///
        /// <para>
        /// Predefined consent key constants, such as `ConsentKeys/tcf` and `ConsentKeys/usp`, are provided
        /// by Core. Adapters should use them when reporting the status of a common standard.
        /// Custom keys should only be used by adapters when a corresponding constant is not provided by the Core.
        /// </para>
        ///
        /// <para>
        /// Predefined consent value constants are also provided, but are only applicable to non-IAB string keys, like
        /// `ConsentKeys/ccpaOptIn` and `ConsentKeys/gdprConsentGiven`.
        /// </para>
        /// </summary>
        public IReadOnlyDictionary<ConsentKey, ConsentValue> Consents
        {
            get => UnmanagedInstance.Consents;
            set => UnmanagedInstance.Consents = value;
        }

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// <para>
        /// A flag that indicates if the adapter observers and fetches standard IAB consent strings from the
        /// user defaults. If enabled, this info is merged with the user-provided info to obtain the final
        /// map of consents.
        /// </para>
        ///
        /// <para>
        /// In some cases setting this flag to true is everything that's needed to receive CMP consent info.
        /// If the CMP used provides other consent information besides standard IAB consent strings, that info
        /// will need to be explicitly set by the user.
        ///</para>
        /// 
        /// <para>
        /// This should be set to false if the user does not want to get this automatic behavior, and instead
        /// prefers to set all the consent info explicitly themselves.
        /// </para>
        /// </summary>
        public bool UsesIABStringsFromAppPreferences { get; }

        // ReSharper disable once InconsistentNaming
        [Preserve]
        public UnmanagedConsentAdapter(bool usesIABStringsFromAppPreferences) : base(usesIABStringsFromAppPreferences) => UsesIABStringsFromAppPreferences = usesIABStringsFromAppPreferences;
    }
}
