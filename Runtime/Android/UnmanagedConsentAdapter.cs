using System.Collections.Generic;
using Chartboost.Constants;
using Chartboost.Core.Android.Modules;
using Chartboost.Core.Android.Utilities;
using Chartboost.Core.Consent;
using UnityEngine;
using UnityEngine.Scripting;

namespace Chartboost.Core.Unmanaged.Android
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class UnmanagedConsentAdapter : NativeModule, IUnmanagedConsentAdapter
    {
        // ReSharper disable InconsistentNaming
        private const string ClassUnmanagedAdapter = "com.chartboost.core.consent.unmanaged.UnmanagedAdapter";
        private const string FunctionSetShouldUseIabStringsFromSharedPreferences = "setShouldUseIabStringsFromSharedPreferences";
        private const string FunctionGetShouldCollectConsent = "getShouldCollectConsent";
        private const string FunctionSetShouldCollectConsent = "setShouldCollectConsent";
        private const string FunctionGetConsents = "getConsents";
        private const string FunctionSetConsents = "setConsents";
        
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
        
        // ReSharper disable once InconsistentNaming
        public bool ShouldCollectConsent {
            get => NativeInstance != null && NativeInstance.Call<bool>(FunctionGetShouldCollectConsent);
            set => NativeInstance?.Call(FunctionSetShouldCollectConsent, value);
        }

        public IReadOnlyDictionary<ConsentKey, ConsentValue> Consents {
            get
            {
                if (NativeInstance == null)
                    return new Dictionary<ConsentKey, ConsentValue>();

                var consentAsMap = NativeInstance.Call<AndroidJavaObject>(FunctionGetConsents);
                return consentAsMap.MapToConsentDictionary();
            }
            set => NativeInstance?.Call(FunctionSetConsents, DictionaryToMap(value));
        }

        private static AndroidJavaObject CreateInstance(bool usesIABStringsFromAppPreferences)
        {
            var unmanagedAdapter = new AndroidJavaObject(ClassUnmanagedAdapter);
            unmanagedAdapter.Call(FunctionSetShouldUseIabStringsFromSharedPreferences, usesIABStringsFromAppPreferences);
            return unmanagedAdapter;
        }
        
        private static AndroidJavaObject DictionaryToMap(IReadOnlyDictionary<ConsentKey, ConsentValue> source)
        {
            var map = new AndroidJavaObject(SharedAndroidConstants.ClassHashMap);
            
            if (source == null)
                return map;
            
            foreach (var kv in source)
            {
                if (string.IsNullOrEmpty(kv.Key.Value))
                    continue;
                using var key = new AndroidJavaObject(SharedAndroidConstants.ClassString, kv.Key.Value);
                using var value = new AndroidJavaObject(SharedAndroidConstants.ClassString, kv.Value.Value);
                map.Call<AndroidJavaClass>(SharedAndroidConstants.FunctionPut, key, value);
            }
            return map;
        }
    }
}
