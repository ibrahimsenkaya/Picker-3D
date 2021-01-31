using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBarCreator : MonoBehaviour
{
    [SerializeField] Image LevelBar;
    [SerializeField] LevelAsset levelAsset;
    [SerializeField] Transform PrevLevel, Nextlevel;
    int CheckPointCounter;
    int TempCheckPointCounter = 1;
    void OnEnable()
    {

        SetUpbar();

    }
    private void OnDisable()
    {
        TempCheckPointCounter = 1;
        CheckPointCounter = 0;
      
        for (int i = 1; i < transform.childCount-1; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

    }

    public void SetUpbar()
    {
        int CurrentLevel = levelAsset.CurrrentLevel;
        PrevLevel.parent = transform;
        Nextlevel.parent = transform.parent;
        PrevLevel.GetComponent<TextMeshProUGUI>().text = CurrentLevel.ToString();
        CheckPointCounter = levelAsset.GameLevel[CurrentLevel].HowManyCheckpoint;
        for (int i = 0; i < CheckPointCounter; i++)
        {
            Instantiate(LevelBar, this.transform);
        }
        Nextlevel.parent = transform;
        Nextlevel.GetComponent<TextMeshProUGUI>().text = (CurrentLevel + 1).ToString();
    }

    public void CheckPointReached()
    {
        transform.GetChild(TempCheckPointCounter).GetComponent<Image>().color = Color.green;
        TempCheckPointCounter++;
    }
}
