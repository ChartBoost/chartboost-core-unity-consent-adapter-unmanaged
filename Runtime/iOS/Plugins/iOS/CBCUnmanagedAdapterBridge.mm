#import "CBCUnityObserver.h"
#import "ChartboostCoreConsentAdapterUnmanaged-Swift.h"

static CBCUnmanagedConsentAdapter * GetUnmanagedAdapter(const void* uniqueId){
    return (__bridge CBCUnmanagedConsentAdapter*)uniqueId;
}

extern "C" {
    const void* _CBCGetUnmanagedAdapter(bool usesIABStringsFromAppPreferences){
        id<CBCModule> unmanagedAdapter = [[CBCUnmanagedConsentAdapter alloc] initWithUsesIABStringsFromUserDefaults:usesIABStringsFromAppPreferences];
        [[CBCUnityObserver sharedObserver] storeModule:unmanagedAdapter];
        return (__bridge void*)unmanagedAdapter;
    }

    bool _CBCUnmanagedAdapterGetShouldCollectConsent(const void* uniqueId){
        CBCUnmanagedConsentAdapter* unmanagedAdapter = GetUnmanagedAdapter(uniqueId);
        return [unmanagedAdapter shouldCollectConsent];
    }

    void _CBCUnmanagedAdapterSetShouldCollectConsent(const void* uniqueId, bool shouldCollectConsent){
        CBCUnmanagedConsentAdapter* unmanagedAdapter = GetUnmanagedAdapter(uniqueId);
        [unmanagedAdapter setShouldCollectConsent:shouldCollectConsent];
    }

    const char* _CBCUnmanagedAdapterGetConsents(const void* uniqueId){
        CBCUnmanagedConsentAdapter* unmanagedAdapter = GetUnmanagedAdapter(uniqueId);
        return toJSON([unmanagedAdapter consents]);
    }

    void _CBCUnmanagedAdapterSetConsents(const void* uniqueId, const char* consentsJson){
        CBCUnmanagedConsentAdapter* unmanagedAdapter = GetUnmanagedAdapter(uniqueId);
        NSDictionary* consents = toNSDictionary(consentsJson);
        [unmanagedAdapter setConsents:consents];
    }
}
