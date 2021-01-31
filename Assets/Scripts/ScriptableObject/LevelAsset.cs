using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Gamelevel/levels",fileName ="NewLevelAsset")]
public class LevelAsset : ScriptableObject
{
    public int CurrrentLevel;
    public List<Level> GameLevel;
  


}
[System.Serializable]
public class Level
{
    public int HowManyRoad;
    public int HowManyCheckpoint;
}
