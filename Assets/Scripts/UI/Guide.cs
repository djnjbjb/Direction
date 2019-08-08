using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Guide : MonoBehaviour
{
    public GameObject guide;
    public GameObject show_guide;
    public GameObject guide_text_gameobject;
    Text guide_text;
    List<string> guide_list;
    int current;
    // Start is called before the first frame update
    void Start()
    {
        guide_list = new List<string>();
        guide_list.Add("驾驶小船，寻找宝藏。\n宝藏是地图上的橘黄色的圆形。\n小船触碰宝藏即寻宝成功。\n");
        guide_list.Add("键盘的  上下左右  控制小船的行驶和转向。\n");
        guide_list.Add("游戏开始时，在小船的出生位置附近，会标示出宝藏相对小船的方向和距离。\n是寻宝最重要的依据。\n");
        guide_list.Add("地图上有很多礁石。\n触碰礁石将造成视角的旋转，为寻宝增加难度。\n");
        guide_list.Add("在规定时间找到宝藏才算成功，屏幕的右上角显示剩余时间。\n");
        guide_list.Add("屏幕右下方是寻宝小助手。\n速度与里程时刻显示当前速度与航行的总里程。\n（指针 工具，见下一条）\n");
        guide_list.Add("指针会在一定范围内摆动，显示宝藏的大致方向。\n宝藏一定在指针范围内。\n靠近宝藏，指针的摆动速度会快一些。\n停船时指针打开，船速较快时指针自动关闭。\n");
        guide_text = guide_text_gameobject.GetComponent<Text>();

        current = 0;
        MakeGuideText();
    }

    public void PreGuide()
    {
        if (guide_list.Count <= 0)
            return;
        current = current - 1;
        current = Mathf.Clamp(current, 0, guide_list.Count - 1);
        MakeGuideText();
    }

    public void NextGuide()
    {
        if (guide_list.Count <= 0)
            return;
        current = current + 1;
        current = Mathf.Clamp(current, 0, guide_list.Count - 1);
        MakeGuideText();
    }

    public void GotoLevel1()
    {
        SceneManager.LoadScene("Level1_SenseOfSpace");
    }

    public void CloseGuide()
    {
        guide.SetActive(false);
        show_guide.SetActive(true);
    }

    public void ShowGuide()
    {
        guide.SetActive(true);
        show_guide.SetActive(false);
    }

    void MakeGuideText()
    {
        if (guide_list.Count <= 0)
            return;
        string process_string = (current + 1).ToString() + "/" + guide_list.Count.ToString() + "\n";
        guide_text.text = process_string + guide_list[current];
    }
}
