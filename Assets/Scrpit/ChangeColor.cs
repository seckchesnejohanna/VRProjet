using System.Net.Sockets;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color initColor;
    private Color colorHover = Color.white;
    private Color colorGrab = Color.red;

    private bool selectMode = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initColor = GetComponent<MeshRenderer>().materials[0].color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyHoverColor(bool pway)
    {
        if (pway)
        {
            GetComponent<MeshRenderer>().materials[0].color = colorHover;
        }
        else if(!selectMode)
        {
            GetComponent<MeshRenderer>().materials[0].color = initColor;
        }
    }

    public void ModifyGrabColor(bool pway)
    {
        selectMode = pway;
        GetComponent<MeshRenderer>().materials[0].color = pway ? colorGrab initColor;
        
    }
}
