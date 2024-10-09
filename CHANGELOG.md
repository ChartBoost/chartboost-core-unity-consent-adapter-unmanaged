## Changelog
All notable changes to this project will be documented in this file using the standards as defined at [Keep a Changelog](https://keepachangelog.com/en/1.0.0/). This project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0).

Note the first digit of every adapter version corresponds to the major version of the Chartboost Core SDK compatible with that adapter. 
Adapters are compatible with any Chartboost Core SDK version within that major version.

### Version 1.0.1 *(2024-10-08)*

Bug Fixes:
- Fixed an issue where attempting to use the `UnmanagedConsentAdapter` in the Unity Editor would result in `NullReferenceExceptions`.

### Version 1.0.0 *(2024-09-19)*
First version of the Core Consent Unmanaged Adapter.

This version of the Core Consent Unmanaged Adapter supports the following native SDK dependencies:
* Android: `com.chartboost:chartboost-core-consent-adapter-unmanaged:1.1.0.+`
* iOS: `ChartboostCoreConsentAdapterUnmanaged ~> 1.1.0.0` 

Added: 

- `UnmanagedConsentAdapter` module to be utilized with `ChartboostCore`.
