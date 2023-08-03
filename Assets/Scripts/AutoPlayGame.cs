using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;

public class AutoPlayGame : MonoBehaviour
{
    
    private static string str_temp;
    private string str;
    
    
    public void PlayGameOfFile()
    {
        StartCoroutine(MyCoroutine());
    }
   

    IEnumerator MyCoroutine(){
        StreamReader streamReader = new StreamReader("z:/KantBase.txt");


        while ((str = streamReader.ReadLine()) != null) 
        { 
                yield return new WaitForSeconds(0.7f); // задержка на время перемещения кубика               
                Debug.Log(str);
               switch (str)
               {
                   case ("R1 D"):
                       str_temp = "CubeR1";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.back);
                       break;
                   case ("R2 D"):
                       str_temp = "CubeR2";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.back);
                       break;
                   case ("R3 D"):
                       str_temp = "CubeR3";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.back);
                       break;
                   case ("R4 D"):
                       str_temp = "CubeR4";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.back);
                       break;
                   case ("B1 D"):
                       str_temp = "CubeB1";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.back);
                       break;
                   case ("B2 D"):
                       str_temp = "CubeB2";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.back);
                       break;
                   case ("B3 D"):
                       str_temp = "CubeB3";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.back);
                       break;
                   case ("B4 D"):
                       str_temp = "CubeB4";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.back);
                       break;
                   
                   case ("R1 U"):
                       str_temp = "CubeR1";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
                       break;
                   case ("R2 U"):
                       str_temp = "CubeR2";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
                       break;
                   case ("R3 U"):
                       str_temp = "CubeR3";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
                       break;
                   case ("R4 U"):
                       str_temp = "CubeR4";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
                       break;
                   case ("B1 U"):
                       str_temp = "CubeB1";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
                       break;
                   case ("B2 U"):
                       str_temp = "CubeB2";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
                       break;
                   case ("B3 U"):
                       str_temp = "CubeB3";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
                       break;
                   case ("B4 U"):
                       str_temp = "CubeB4";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
                       break;

                   case ("R1 L"):
                       str_temp = "CubeR1";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.left);
                       break;
                   case ("R2 L"):
                       str_temp = "CubeR2";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.left);
                       break;
                   case ("R3 L"):
                       str_temp = "CubeR3";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.left);
                       break;
                   case ("R4 L"):
                       str_temp = "CubeR4";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.left);
                       break;
                   case ("B1 L"):
                       str_temp = "CubeB1";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.left);
                       break;
                   case ("B2 L"):
                       str_temp = "CubeB2";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.left);
                       break;
                   case ("B3 L"):
                       str_temp = "CubeB3";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.left);
                       break;
                   case ("B4 L"):
                       str_temp = "CubeB4";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.left);
                       break;
                   
                   case ("R1 R"):
                       str_temp = "CubeR1";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.right);
                       break;
                   case ("R2 R"):
                       str_temp = "CubeR2";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.right);
                       break;
                   case ("R3 R"):
                       str_temp = "CubeR3";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.right);
                       break;
                   case ("R4 R"):
                       str_temp = "CubeR4";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.right);
                       break;
                   case ("B1 R"):
                       str_temp = "CubeB1";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.right);
                       break;
                   case ("B2 R"):
                       str_temp = "CubeB2";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.right);
                       break;
                   case ("B3 R"):
                       str_temp = "CubeB3";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.right);
                       break;
                   case ("B4 R"):
                       str_temp = "CubeB4";
                       GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.right);
                       break;
               }
        }
        streamReader.Close();
    }
}
