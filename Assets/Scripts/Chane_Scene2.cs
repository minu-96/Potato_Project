using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chane_Scene2 : MonoBehaviour
{
    public void ChangeScene2(string InGame0)
    {
        SceneManager.LoadScene(InGame0);
    }
}
