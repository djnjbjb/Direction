using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInit : MonoBehaviour
{
    public GameObject active_ui = null;
    public GameObject inactive_ui = null;
    public GameObject inactive_ui1 = null;
    // Start is called before the first frame update
    void Awake()
    {
        if(active_ui)
            active_ui.SetActive(true);
        if(inactive_ui)
            inactive_ui.SetActive(false);
        if(inactive_ui1)
            inactive_ui1.SetActive(false);
    }
}
