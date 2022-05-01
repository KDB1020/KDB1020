using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Worktable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeSword()
    {
        ToolManager.isSword = true;
    }

    public void MakeAxe()
    {
        ToolManager.isAxe = true;
    }

    public void CloseWorktable()
    {
        SceneManager.LoadScene("Main");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("Worktable");
        }
    }
}
