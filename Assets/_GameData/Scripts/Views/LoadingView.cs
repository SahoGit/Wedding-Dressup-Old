using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingView : MonoBehaviour
{
    
    public Image LoadingFilled;

    void Start()
    {
        LoadingBgActive();
        //AdsManager.Instance.ShowInterstitial("Ad Show on loading Screen");
        Invoke("callAd", 1.5f);
    }

    public void LoadingBgActive()
    {
        StartCoroutine(FillAction(LoadingFilled));
    }

    IEnumerator FillAction(Image img)
    {
        if (img.fillAmount < 1)
        {
            img.fillAmount = img.fillAmount + 0.009f;
            yield return new WaitForSeconds(0.02f);
            StartCoroutine(FillAction(img));
        }
        else if (img.color.a >= 1f)
        {
            StopCoroutine(FillAction(img));
        }
    }

    void callAd()
    {
       // if (PlayerPrefs.GetInt("first", 0) == 1){
       // AdsManager.Instance.ShowInterstitial("Ad Show on loading Screen");
          
        //}
    }

}
