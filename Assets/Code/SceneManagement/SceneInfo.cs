// ----------------------------------------------------------------------------
//  Chatham University
//  Week 3
//  JANUARY 2023
// ----------------------------------------------------------------------------
using System;
using UnityEngine;
[Serializable]
public class SceneInfo {
    /// <summary>
    /// The id specified by the build index in build settings
    /// </summary>
    [Header("Must match Project Build Settings")]
    public string indexBuildId;

    /// <summary>
    /// The displayed readable level name for printing
    /// </summary>
    public string displayName;

    /// <summary>
    /// The description of the level
    /// </summary>
    [TextArea]
    public string sceneDescription;

    /// <summary>
    /// The name specified by the build index in build settings
    /// </summary>
    [Header("Must match Project Build Settings")]
    public string sceneName;
}
