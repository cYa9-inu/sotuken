using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuButton : MonoBehaviour
{
    //スタートゲームボタン押下時
    public void StartGameButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //カスタマイズボタン押下時
    public void CustomizeButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
