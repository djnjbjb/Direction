using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject MissionPanel;
    public void OK()
    {
        MissionPanel.SetActive(false);
    }
}
