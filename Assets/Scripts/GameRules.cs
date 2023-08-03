using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    private int x, y;
    public bool R, L, B, F;
    public bool _rulesOn;
    public char direction;    // направление движения кубтка L,R,B,F
    public char states;

    // кубик (gameObject.name) и (Vector3 dir), проверяем и если ход возможен, то меняем данные в массивах и даем возможность сходить
    public void Rules(Vector3 dir )  
    {
        _rulesOn = false;
        FindCube();  //  поиск кубика в массиве по gameObject.name
        CheckPositions(); // проверяем свободные позиции
        
        // заполняем переменные 
        if (dir == Vector3.left && L) {
            _rulesOn = true;
            direction = 'L';
        }
        if (dir == Vector3.right && R) {
            _rulesOn = true;
            direction = 'R';
        }
        if (dir == Vector3.forward && F) {
            _rulesOn = true;
            direction = 'F';
        }
        if (dir == Vector3.back && B) {
            _rulesOn = true;
            direction = 'B';
        }

        if (_rulesOn) ChangingDataArrays(); // изменение данных в массивах
    }

    public void FindCube() //  поиск кубика в массиве по gameObject.name
    {
        x=3;
        y=-1;
        do { x++;
            if (x==4) { x=0; y++; }
        } while (StartGame.cubeSide[x,y] != gameObject.name);
    }

    public void CheckPositions() // проверяем свободные позиции
    {
        if (x+1 == 4) R=false;
        else if (StartGame.cubeSideS[x+1,y] == '.') R=true;
        else R=false;

        if (x-1 == -1) L=false;
        else if (StartGame.cubeSideS[x-1,y] == '.') L=true;
        else L=false;

        if (y+1 == 4) B=false;
        else if (StartGame.cubeSideS[x,y+1] == '.') B=true;
        else B=false;

        if (y-1 == -1) F=false;
        else if (StartGame.cubeSideS[x,y-1] == '.') F=true;
        else F=false;
    }

    public void ChangingDataArrays() // изменение данных в массивах
    {
        states = StartGame.cubeSideS[x, y]; // старое состояние
        states = StateChange(states, direction);
        
        
        if (direction == 'B') 
        {
            StartGame.cubeSide[x,y+1] = StartGame.cubeSide[x,y] ;
            StartGame.cubeSideS[x,y+1] =  states;
        }
        else if (direction == 'F') 
        {
            StartGame.cubeSide[x,y-1] = StartGame.cubeSide[x,y] ;
            StartGame.cubeSideS[x,y-1] =  states;
        }
        else if (direction == 'R') 
        {
            StartGame.cubeSide[x+1,y] = StartGame.cubeSide[x,y] ;
            StartGame.cubeSideS[x+1,y] =  states;
        }
        else if (direction == 'L') 
        {
            StartGame.cubeSide[x-1,y] = StartGame.cubeSide[x,y] ;
            StartGame.cubeSideS[x-1,y] =  states;
        }
        StartGame.cubeSide[x,y] = "";
        StartGame.cubeSideS[x,y] = '.';
        

        //  вывод данных массива
        for (int i = 0; i <= 3; i++)
        {
            Debug.Log(StartGame.cubeSideS[0,i]+" "+StartGame.cubeSideS[1,i]+" "+StartGame.cubeSideS[2,i]+ " "+StartGame.cubeSideS[3,i]);
        } 
        
        
    }

    // функция получения нового состояния (states) кубика от кантования (direction) и старого состояния
    public char StateChange(char states, char direction)
    {
        if (states == 'o' && direction == 'L') states = '←';
        else if (states == '←' && direction == 'L') states = '+';
        else if (states == '+' && direction == 'L') states = '→';
        else if (states == '→' && direction == 'L') states = 'o';
        else if (states == 'o' && direction == 'R') states = '→';
        else if (states == '→' && direction == 'R') states = '+';
        else if (states == '+' && direction == 'R') states = '←';
        else if (states == '←' && direction == 'R') states = 'o';
        else if (states == 'o' && direction == 'F') states = '↑';
        else if (states == '↑' && direction == 'F') states = '+';
        else if (states == '+' && direction == 'F') states = '↓';
        else if (states == '↓' && direction == 'F') states = 'o';
        else if (states == 'o' && direction == 'B') states = '↓';
        else if (states == '↓' && direction == 'B') states = '+';
        else if (states == '+' && direction == 'B') states = '↑';
        else if (states == '↑' && direction == 'B') states = 'o';
        return states;
        
    }


}
