using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chane_Scene2 : MonoBehaviour
{
    public void ChangeScene2(string TestScene2)
    {
        SceneManager.LoadScene(TestScene2);
    }
}
