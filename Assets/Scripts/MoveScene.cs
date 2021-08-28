using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public string transferMapName;
    public AudioSource aud;
    public int fadeTime = 0;
    // Start is called before the first frame update
    public void LoadScene()
    {
        aud.Play();
        if (fadeTime != 0)
        {
            FadeObject obj = FindObjectOfType<FadeObject>();
            obj.FadeIn(fadeTime);
            Invoke("Load", fadeTime);
        }
        else
            Invoke("Load", 0.5f);
    }

    public void Start()
    {
        LocalDBManager.Instance.LoadGameData();
        LocalDBManager.Instance.SaveGameData();
        if(LocalDBManager.Instance.returnIsSaved() == true)
        {
            transferMapName = "M-1";
        }
    }
    private void Load()
    {
        SceneManager.LoadScene(transferMapName);
    }
}
