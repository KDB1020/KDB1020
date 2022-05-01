using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    // 해당 도구를 현재 가지고 있는지
    bool isHand = true;
    public static bool isSword = false;
    public static bool isAxe = false;

    ToolSlot[] toolSlots;
    public GameObject[] tools;

    [SerializeField] GameObject toolSlotsParent;

    // Start is called before the first frame update
    void Start()
    {
        toolSlots = toolSlotsParent.GetComponentsInChildren<ToolSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTool();
        UseTool();
    }

    void SetTool()
    {
        if (isSword) toolSlots[1].AppearTool(tools[0].GetComponent<ItemPickUp>().item);
        if (isAxe) toolSlots[2].AppearTool(tools[1].GetComponent<ItemPickUp>().item);
    }

    void UseTool()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < tools.Length; i++) tools[i].SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (isSword)
            {
                tools[0].SetActive(true);

                for (int i = 1; i < tools.Length; i++) tools[i].SetActive(false);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (isAxe) 
            {
                tools[0].SetActive(false);
                tools[1].SetActive(true);

                for (int i = 2; i < tools.Length; i++) tools[i].SetActive(false);
            }
        }
    }
}
