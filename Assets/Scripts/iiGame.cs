using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class iiGame : MonoBehaviour
{
    private static string str_temp;
    private int x, y;
    private string nameCube;
    private char[,] moveN;
    private char[,] moveBestN; 
    private bool R, L, B, F;
    private char[] direction;   // направление движения кубтка L,R,B,F
    private char dirRND;
    private char stateCube, st;     // состояние кубика
    private bool stepOn;
    private char[,] cubeSideS;
    private int numMove;      // номер хода в поиске лучшего хода
    
    
    

    
    public void FirstMove() // выбираем случайно кубик и делаем первый ход
    {
        /*
        StartGame.cubeSide[0,3] = "CubeB1";
        StartGame.cubeSide[1,3] = "CubeB2";
        StartGame.cubeSide[2,3] = "CubeB3";
        StartGame.cubeSide[3,3] = "CubeB4";
        */
        
        FindIndexCubeB(Random.Range(1, 5));
        str_temp = StartGame.cubeSide[x, y];
        GameObject.Find(str_temp).GetComponent<CubeKant>().Assemble(Vector3.forward);
    }

    private void Update()
    {

        if (StartGame.iiGameOn == true ) // ходят черные
        {
            StartGame.iiGameOn = false; // Ход разрешаю красным
            FirstMove();
        }
    }

    public void FindIndexCubeB(int B)
    {
        if (B == 1) nameCube = "CubeB1";
        if (B == 2) nameCube = "CubeB2";
        if (B == 3) nameCube = "CubeB3";
        if (B == 4) nameCube = "CubeB4";
        
        x=3;
        y=-1;
        do { x++;
            if (x==4) { x=0; y++; }
        } while (StartGame.cubeSide[x,y] != nameCube);
        
    } // ищем куб по номеру от 1 до 4
    
    public void CheckPositions() // проверяем свободные позиции
    {
        if (x+1 == 4) R=false;
        else if (cubeSideS[x+1,y] == '.') R=true;
        else R=false;

        if (x-1 == -1) L=false;
        else if (cubeSideS[x-1,y] == '.') L=true;
        else L=false;

        if (y+1 == 4) B=false;
        else if (cubeSideS[x,y+1] == '.') B=true;
        else B=false;

        if (y-1 == -1) F=false;
        else if (cubeSideS[x,y-1] == '.') F=true;
        else F=false;
    }
    public void TestStepOn(int x, int y, char dirRND)
    {
// сбрасываем разрешение на ход
        stepOn = false;
// проверяем на попадание в поле
        if (dirRND == 'L' && x > 0)
        {
            stepOn = true;
            x -= 1;
        }
        
        else if (dirRND == 'R' && x< 3)
        {
            stepOn = true;
            x += 1;
        }
        else if (dirRND == 'F' && y > 0)
        {
            stepOn = true;
            y -= 1;
        }
        else if (dirRND == 'B' && y < 3)
        {
            stepOn = true;
            y += 1;
        }
// проверяем на свободность от других кубиков
        if (cubeSideS[x,y] == '.' && stepOn) stepOn = true;
        else stepOn = false;
    }    // проверяем возсожность хода

    // функция получения нового состояния (states) кубика от кантования (directs) и старого состояния
    public void StateChange(char stateCube, char dirRND)
    {
        if (stateCube == 'o' && dirRND == 'L') stateCube = '←';
        else if (stateCube == '←' && dirRND == 'L') stateCube = '+';
        else if (stateCube == '+' && dirRND == 'L') stateCube = '→';
        else if (stateCube == '→' && dirRND == 'L') stateCube = 'o';
        else if (stateCube == 'o' && dirRND == 'R') stateCube = '→';
        else if (stateCube == '→' && dirRND == 'R') stateCube = '+';
        else if (stateCube == '+' && dirRND == 'R') stateCube = '←';
        else if (stateCube == '←' && dirRND == 'R') stateCube = 'o';
        else if (stateCube == 'o' && dirRND == 'F') stateCube = '↑';
        else if (stateCube == '↑' && dirRND == 'F') stateCube = '+';
        else if (stateCube == '+' && dirRND == 'F') stateCube = '↓';
        else if (stateCube == '↓' && dirRND == 'F') stateCube = 'o';
        else if (stateCube == 'o' && dirRND == 'B') stateCube = '↓';
        else if (stateCube == '↓' && dirRND == 'B') stateCube = '+';
        else if (stateCube == '+' && dirRND == 'B') stateCube = '↑';
        else if (stateCube == '↑' && dirRND == 'B') stateCube = 'o';
    }

    // делаем ход и вычислив новую позицию и состояние меняем данные в массиве
    public void Step(int x, int y, char dirRND, bool stepOn)
    {
        if (stepOn) stateCube = (cubeSideS[x, y]);
        StateChange(stateCube, dirRND);
        st = stateCube;
        cubeSideS[x, y] = '.';
        if (dirRND == 'L') x -= 1;
        if (dirRND == 'R') x += 1;
        if (dirRND == 'F') y -= 1;
        if (dirRND == 'B') y += 1;
        cubeSideS[x, y] = st;
        moveN[numMove, 1] = dirRND;
    }

    public void FindBestMove()
    {
        moveN = new char[9,3]; // 10 ходов, 4 кубика 
        moveBestN = new char[9,3];
        direction[0] = 'R';
        direction[1] = 'L';
        direction[2] = 'B';
        direction[3] = 'F';
        cubeSideS = StartGame.cubeSideS;
        numMove = 0;

        
        do
        {
            FindIndexCubeB(1); // выбираем кубик
            stateCube = cubeSideS[x, y]; // смотрим его состояние
            dirRND = direction[Random.Range(0, 3)]; // выбираем случайное направление
            TestStepOn(x, y, dirRND); // проверяем возсожность хода
        } while (!stepOn);
        Step(x,y,dirRND,stepOn); // всё нормально, ходим и записываем ход во временный массив
        numMove += 1;            // считаем номер хода








    }

    

}
