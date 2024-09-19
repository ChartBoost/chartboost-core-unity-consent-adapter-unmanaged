# Chartboost Core Consent Unmanaged Adapter

The Chartboost Core Unmanaged Consent Adapter allows users to manage their own CMP integration directly, instead of relying
on Chartboost Core and a consent adapter to manage the CMP integration for them.

The use of the Unmanaged Consent Adapter is not preferred. Use one of the public Core consent adapters instead, for a 
streamlined integration without the need to to manage the CMP SDK yourself.

Important information regarding the Unmanaged Consent Adapter:

- Users are responsible for setting new consent info in the Unmanaged Consent Adapter when this info is updated by the CMP.
Failure to do so will result in frameworks that depend on Core for consent to have outdated consent info.

- Users must take care to format the consent info set in the Unmanaged Consent Adapter by using the constants defined in
`ConsentKeys` and `ConsentValues` when proper. For more info see the ChartboostCore SDK documentation.
Failure to do so will result in frameworks that depend on Core for consent to have outdated consent info.

- Chartboost Core SDK APIs to show consent dialogs are no-ops with this adapter.

## Minimum Requirements

| Plugin              | Version |
| ------------------- | ------- |
| Chartboost Core SDK | 1.0.0+  |
| Android API         | 21+     |
| Cocoapods           | 1.11.3+ |
| iOS                 | 13.0+   |
| Xcode               | 15.0+   |

## Integration

Chartboost Core - Consent Unmanaged is distributed using the public [npm registry](https://www.npmjs.com/search?q=com.chartboost.core.consent.unmanaged) as such it is compatible with the Unity Package Manager (UPM). In order to add the Chartboost Core - Consent Unmanaged to your project, just add the following to your Unity Project's ***manifest.json*** file. The scoped registry section is required in order to fetch packages from the NpmJS registry.

```json
  "dependencies": {
    "com.chartboost.core.consent.unmanaged" : "1.0.0",
    ...
  },
  "scopedRegistries": [
    {
      "name": "NpmJS",
      "url": "https://registry.npmjs.org",
      "scopes": [
        "com.chartboost"
      ]
    }
  ]
```

## Using the public [NuGet package](https://www.nuget.org/packages/Chartboost.CSharp.Core.Unity.Consent.Unmanaged)

To add the Chartboost Core - Consent Unmanaged to your project using the NuGet package, you will first need to add the [NugetForUnity](https://github.com/GlitchEnzo/NuGetForUnity) package into your Unity Project.

This can be done by adding the following to your Unity Project's ***manifest.json***

```json
  "dependencies": {
    "com.github-glitchenzo.nugetforunity": "https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity",
    ...
  },
```

Once <code>NugetForUnity</code> is installed, search for `Chartboost.CSharp.Core.Unity.Consent.Unmanaged` in the search bar of Nuget Explorer window(Nuget -> Manage Nuget Packages).
You should be able to see the `Chartboost.CSharp.Core.Unity.Consent.Unmanaged` package. Choose the appropriate version and install.

## Contributions

We are committed to a fully transparent development process and highly appreciate any contributions. Our team regularly monitors and investigates all submissions for the inclusion in our official adapter releases.

Please refer to our [CONTRIBUTING](CONTRIBUTING.md) file for more information on how to contribute.

## License

Please refer to our [LICENSE](LICENSE.md) file for more information.