using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinController : MonoBehaviour
{
    [SerializeField] Transform[] pathVal;
    [SerializeField] GameObject CoinImage;
    [SerializeField] PathType pathSystem = PathType.CubicBezier;
    [SerializeField] TextMeshProUGUI Cointext;
    int StaticEarn=100;
    Vector3[] temp1;

    private void OnEnable()
    {
        #region rect transformlari kolay alabilmek icin
        temp1 = new Vector3[pathVal.Length];
        for (int j = 0; j < pathVal.Length; j++)
        {
            temp1[j] = pathVal[j].position;
        }
        #endregion
        StartCoroutine(CreateAndMove());

    }
    IEnumerator CreateAndMove()
    {

        for (int i = 0; i < 11; i++)
        {
            GameObject tempCoin = Instantiate(CoinImage, this.transform);
            Cointext.text=StaticEarn.ToString();
            StaticEarn-=10;
            tempCoin.transform.DOScale(Vector2.one*.7f,1f);
            tempCoin.transform.DOLocalRotate(new Vector3(0, 0, 270), .2f).SetLoops(5, LoopType.Incremental).SetId(i.ToString());
            tempCoin.transform.DOPath(temp1, 1f, pathSystem).SetEase(Ease.OutQuad).OnComplete(() =>
            {

                Destroy(tempCoin);
           
                // tempCoin.SetActive(false);
            });


            yield return new WaitForSeconds(.1f);

        }
        Cointext.enabled=false;
    }

}
