// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;
/// <summary>
/// ScriptableObject that contains SceneInfo
/// </summary>
[CreateAssetMenu(fileName = "newSceneAsset", menuName = "Scene Managment/SceneAsset")]
public class SceneAsset : ScriptableObject {
    public SceneInfo sceneInfo;
}
