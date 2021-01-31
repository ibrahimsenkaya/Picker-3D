using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevelForStart : MonoBehaviour
{
    [SerializeField] LevelAsset levels;
    [SerializeField] GameObject Road, CheckPoint, Finish;
    int xPosition;
    public GameObject picker;

    void Awake()
    {
        CreateNewLevel();
    }

    public void CreateNewLevel()
    {
        int CurrentLevel = levels.CurrrentLevel;
        int RoadCount = (levels.GameLevel[CurrentLevel].HowManyRoad);
        int CheckPointCounter = (levels.GameLevel[CurrentLevel].HowManyCheckpoint);
        if (xPosition != 0) xPosition += 6;
        else if(xPosition==0) xPosition=0;

        for (int i = 0; i < CheckPointCounter; i++)
        {
            for (int j = 0; j < RoadCount / CheckPointCounter; j++)
            {
                Transform TempRoad = Instantiate(Road, new Vector3(xPosition, 0, 0), Quaternion.identity).transform;
                TempRoad.transform.parent = this.transform;
                TempRoad.name = "Road" + j.ToString() + i.ToString();
                xPosition += 6;

            }
            Transform TempCheck = Instantiate(CheckPoint, new Vector3(xPosition, 0, 0), Quaternion.identity).transform;
            TempCheck.transform.parent = this.transform;
            TempCheck.name = "Check" + i.ToString();
            xPosition += 6;
        }

        Transform TempFinish = Instantiate(Finish, new Vector3(xPosition+13f, 0, 0), Quaternion.identity).transform;
        xPosition += 26;
    }

}
