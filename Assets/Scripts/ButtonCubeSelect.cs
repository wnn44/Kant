using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCubeSelect : MonoBehaviour
{
    private static string _nameCube; 


  
    public void ClickR1()
    {
        _nameCube = "CubeR1";
    }
    public void ClickR2()
    {
        _nameCube = "CubeR2";
    }
    
    public void ClickUP()
    {
        GameObject.Find(_nameCube).GetComponent<CubeKant>().Assemble(Vector3.forward);
    }
    public void ClickDown()
    {
        GameObject.Find(_nameCube).GetComponent<CubeKant>().Assemble(Vector3.back);
    }
    public void ClickLeft()
    {
        GameObject.Find(_nameCube).GetComponent<CubeKant>().Assemble(Vector3.left);
    }
    public void ClickRight()
    {
        GameObject.Find(_nameCube).GetComponent<CubeKant>().Assemble(Vector3.right);
    }
}
