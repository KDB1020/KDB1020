using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSlot : MonoBehaviour
{
    public Item tool;
    public Image toolImage;

    void SetColor(float _alpha)
    {
        Color color = toolImage.color;
        color.a = _alpha;
        toolImage.color = color;
    }

    public void AppearTool(Item _tool)
    {
        tool = _tool;
        toolImage.sprite = tool.itemImage;

        SetColor(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
