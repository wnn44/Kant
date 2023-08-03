using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadDate : MonoBehaviour
{
    private string str;
    private string str_temp;

    public void LoadDataFile()
    {


        StreamReader streamReader = new StreamReader("z:/KantBase.txt");


        while ((str_temp = streamReader.ReadLine()) != null)
        {
            Debug.Log(str_temp);
            
           // str += str_temp;
        }

        streamReader.Close();
    }
}
