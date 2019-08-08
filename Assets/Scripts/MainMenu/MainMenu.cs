using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level0()
    {
        SceneManager.LoadScene("Level0_Guide");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1_SenseOfSpace");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2_SenceOfDirection");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3_MovingObject");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
