using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{

        static public string[,] cubeSide;
        static public char[,] cubeSideS;
        static public char[,] cubeTable;
        static public bool iiGameOn = false;  // Контроль хода Компьютера
        

    // Start is called before the first frame update
    static public void RestartLevel()
    {
        
SceneManager.LoadScene("KantGame");


        // первоначальные положения кубиков
        cubeSide = new string[4,4];

        cubeSide[0,0] = "CubeR1";
        cubeSide[1,0] = "CubeR2";
        cubeSide[2,0] = "CubeR3";
        cubeSide[3,0] = "CubeR4";

        cubeSide[0,3] = "CubeB1";
        cubeSide[1,3] = "CubeB2";
        cubeSide[2,3] = "CubeB3";
        cubeSide[3,3] = "CubeB4";  

        // первоночальные стороны кубиков
        cubeSideS = new char[4,4];     

        cubeSideS[0,0] = 'o';
        cubeSideS[1,0] = 'o';
        cubeSideS[2,0] = 'o';
        cubeSideS[3,0] = 'o';

        cubeSideS[0,1] = '.';
        cubeSideS[1,1] = '.';
        cubeSideS[2,1] = '.';
        cubeSideS[3,1] = '.';

        cubeSideS[0,2] = '.';
        cubeSideS[1,2] = '.';
        cubeSideS[2,2] = '.';
        cubeSideS[3,2] = '.'; 

        cubeSideS[0,3] = 'o';
        cubeSideS[1,3] = 'o';
        cubeSideS[2,3] = 'o';
        cubeSideS[3,3] = 'o'; 
    }
}
