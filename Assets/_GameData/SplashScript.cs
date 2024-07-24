using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SplashScript : MonoBehaviour
{
    public GameObject Loading, Policy;
    public GameObject PolicyPanel;
    public UnityEvent OnPolicyAccept;

    public Image LoadingFilled;
    void Awake()
    {
        PlayerPrefs.SetInt("first", 0);
        PlayerPrefs.SetInt("GameStart", 1);
        PlayerPrefs.SetInt("GameCount", 0);
        //int temp = PlayerPrefs.GetInt("PolicyLink", 0);
        //if (temp == 0)
        //{
        //    LoadingBgActive();

        //}
        //else
        //{
        //   LoadingBgActive();

        //}
    }

   
    public void Accept()
    {
        PlayerPrefs.SetInt("PolicyLink", 1);
        Policy.SetActive(false);
        LoadingBgActive();
       
    }

    public void Visit()
    {
        Application.OpenURL("https://bestone-games.webnode.com/privacy-policy/");
        //PlayerPrefs.SetInt("PolicyLink", 1);
        //Policy.SetActive(false);
        //LoadingBgActive();
       
    }
   public void LoadingBgActive(){
       // AdsManager.SetActive(true);
        Loading.SetActive (true);
		StartCoroutine (FillAction(LoadingFilled));
		Invoke ("LoadingFull", 4.0f);
	}

	IEnumerator FillAction (Image img){
		if (img.fillAmount < 1) {
			img.fillAmount = img.fillAmount + 0.009f;
			yield return new WaitForSeconds (0.025f);
			StartCoroutine (FillAction (img));
		}  else if (img.color.a >= 1f) {
			StopCoroutine (FillAction (img));
		}
	}

	private void LoadingFull(){
        GameConstant.IsFromSplash = true;
        SceneManager.LoadScene(1);
	}

}
