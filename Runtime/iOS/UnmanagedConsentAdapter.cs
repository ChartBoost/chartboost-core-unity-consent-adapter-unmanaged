using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Chartboost.Constants;
using Chartboost.Core.Consent;
using Chartboost.Core.iOS.Modules;
using Chartboost.Core.Utilities;
using Chartboost.Json;
using UnityEngine;
using UnityEngine.Scripting;

namespace Chartboost.Core.Unmanaged.iOS
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class UnmanagedConsentAdapter : NativeModule, IUnmanagedConsentAdapter
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void SetInstance()
        {
            if (Application.isEditor)
                return;
            
            Unmanaged.UnmanagedConsentAdapter.InstanceType = typeof(UnmanagedConsentAdapter);
        }

        // ReSharper disable once InconsistentNaming
        [Preserve]
        public UnmanagedConsentAdapter(bool usesIABStringsFromAppPreferences) : base(CreateInstance(usesIABStringsFromAppPreferences)) { }

        public bool ShouldCollectConsent
        {
            get => _CBCUnmanagedAdapterGetShouldCollectConsent(NativeInstance);
            set => _CBCUnmanagedAdapterSetShouldCollectConsent(NativeInstance, value);
        }

        public IReadOnlyDictionary<ConsentKey, ConsentValue> Consents {
            get
            {
                var consentsJson = _CBCUnmanagedAdapterGetConsents(NativeInstance);
                return consentsJson.ToConsentDictionary();
            }
            set
            {
                var consents = value ?? new Dictionary<ConsentKey, ConsentValue>(); 
                var consentsJson = JsonTools.SerializeObject(consents);
                _CBCUnmanagedAdapterSetConsents(NativeInstance, consentsJson);
            }
        }

        // ReSharper disable once InconsistentNaming
        private static IntPtr CreateInstance(bool usesIABStringsFromAppPreferences) 
            => _CBCGetUnmanagedAdapter(usesIABStringsFromAppPreferences);

        // ReSharper disable once InconsistentNaming
        [DllImport(SharedIOSConstants.DLLImport)] private static extern IntPtr _CBCGetUnmanagedAdapter(bool usesIABStringsFromAppPreferences);
        [DllImport(SharedIOSConstants.DLLImport)] private static extern bool _CBCUnmanagedAdapterGetShouldCollectConsent(IntPtr uniqueId);
        [DllImport(SharedIOSConstants.DLLImport)] private static extern void _CBCUnmanagedAdapterSetShouldCollectConsent(IntPtr uniqueId,  bool shouldCollectConsent);
        [DllImport(SharedIOSConstants.DLLImport)] private static extern string _CBCUnmanagedAdapterGetConsents(IntPtr uniqueId);
        [DllImport(SharedIOSConstants.DLLImport)] private static extern void _CBCUnmanagedAdapterSetConsents(IntPtr uniqueId, string consentsJson);
    }
}
