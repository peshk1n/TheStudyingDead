using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string name;
    public void LoadScene()
    {
        GameObjControl objContr = new GameObjControl();
        objContr.SavePlayer();
        SceneManager.LoadScene(name);
    }
}
