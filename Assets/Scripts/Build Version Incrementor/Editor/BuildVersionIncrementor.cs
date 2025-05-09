using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

/// <summary>
/// Auto-increment the version number before every build
/// (Fine for working alone on a project but how to keep version sync with multiple user and version control ?)
/// </summary>
public class BuildVersionIncrementor : IPreprocessBuildWithReport
{
    // Order to run this IPreprocessBuildWithReport (Lower number is first)
    public int callbackOrder => 0;

    // Action to execute before processing the build
    public void OnPreprocessBuild(BuildReport report)
    {
        // Get bundle version
        bool versionSuccess = Version.TryParse(PlayerSettings.bundleVersion, out Version version);
        
        if(!versionSuccess)
        {
            bool intSuccess = int.TryParse(PlayerSettings.bundleVersion, out int versionNumber);
            if (!intSuccess)
            {
                throw new Exception($"Failed to parse version from player settings, the version should respect a semantic versioning format: Major.Minor.Patch (ex: 1.0.5).");
            }

            // Create a version number using the int parsed as a major
            version = new Version(versionNumber, 0);
            Debug.LogWarning($"The version should have a semantic versioning format (Major.Minor.Patch), the version '{PlayerSettings.bundleVersion}' has been automatically converted to '{version}'");
        }

        // Increment revision number
        int newRevision = version.Revision < 0 ? 1 : version.Revision + 1;
        int newPatch = version.Build < 0 ? 0 : version.Build; // Ensure patch number is set
        Version newVersion = new Version(version.Major, version.Minor, newPatch, newRevision);

        // Update version number
        PlayerSettings.bundleVersion = newVersion.ToString();

        // Also increment version code for platforms that use a bundle version code
        switch (report.summary.platform)
        {
            // Apple
            case BuildTarget.StandaloneOSX:
                PlayerSettings.macOS.buildNumber = IncrementVersionCode(PlayerSettings.macOS.buildNumber);
                break;
            case BuildTarget.iOS:
                PlayerSettings.iOS.buildNumber = IncrementVersionCode(PlayerSettings.iOS.buildNumber);
                break;
            case BuildTarget.tvOS:
                PlayerSettings.tvOS.buildNumber = IncrementVersionCode(PlayerSettings.tvOS.buildNumber);
                break;
            case BuildTarget.VisionOS:
                PlayerSettings.VisionOS.buildNumber = IncrementVersionCode(PlayerSettings.VisionOS.buildNumber);
                break;

            // Windows
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                break;
            case BuildTarget.WSAPlayer:
                PlayerSettings.WSA.packageVersion = newVersion;
                break;

            // Android 
            case BuildTarget.Android:
                PlayerSettings.Android.bundleVersionCode++;
                break;

            // Linux
            case BuildTarget.StandaloneLinux64:
            case BuildTarget.EmbeddedLinux:
                break;

            // WebGL
            case BuildTarget.WebGL:
                break;
                
            // Console
            case BuildTarget.PS4:
                PlayerSettings.PS4.appVersion = IncrementVersionCode(PlayerSettings.PS4.appVersion);
                break; 
            case BuildTarget.Switch:
                break;
            case BuildTarget.PS5:
                break;
            
            // QNX
            case BuildTarget.QNX:
                break;
            
            // Not target and default
            case BuildTarget.NoTarget:
            default:
                break;
        }
    }

    private string IncrementVersionCode(string versionCode)
    {
        int.TryParse(versionCode, out int versionCodeAsInt);
        return (versionCodeAsInt + 1).ToString();
    }
}
