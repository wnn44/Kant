
using System;
using System.Collections;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class DragAndRotateCube : ActivateObject
{
    public bool isActive;
 
    private float _rollSpeed = 5;
    private bool _isMoving;	
    public int x;
    public int y;
    public char direction;    // направление движения кубтка L,R,B,F
    public bool R;
    public bool L;
    public bool B;
    public bool F;
    public int activCube;
    [SerializeField]  PlayerNetwork _playerNetwork;




    




    void Update()
    {

        activCube = 0;
// подавление ложных срабатываний

                    if (_isMoving) return;
                    if (GameObject.Find("CubeR1").GetComponent<DragAndRotateCube>().isActive) ++activCube;
                    if (GameObject.Find("CubeR2").GetComponent<DragAndRotateCube>().isActive) ++activCube;
                    if (GameObject.Find("CubeR3").GetComponent<DragAndRotateCube>().isActive) ++activCube;
                    if (GameObject.Find("CubeR4").GetComponent<DragAndRotateCube>().isActive) ++activCube;
                    if (GameObject.Find("CubeB1").GetComponent<DragAndRotateCube>().isActive) ++activCube;
                    if (GameObject.Find("CubeB2").GetComponent<DragAndRotateCube>().isActive) ++activCube;
                    if (GameObject.Find("CubeB3").GetComponent<DragAndRotateCube>().isActive) ++activCube;
                    if (GameObject.Find("CubeB4").GetComponent<DragAndRotateCube>().isActive) ++activCube;   
        if (isActive && activCube==1)
        {
            if (Input.touchCount == 1)
            {
                Touch screenTouch = Input.GetTouch(0); 
                
                
             
                if (screenTouch.phase == TouchPhase.Moved) // Если движение зафиксированно
                {

                    //  поиск кубика в массиве по gameObject.name    
                    x=3;
                    y=-1;
                    do { x++;
                       if (x==4) { x=0; y++; }
                    } while (StartGame.cubeSide[x,y] != gameObject.name);    
                    // -------------




// проверяем свободные позиции
                if (x+1 == 4) R=false;
                else if (StartGame.cubeSideS[x+1,y] == 99) R=true;
                else R=false;

                if (x-1 == -1) L=false;
                else if (StartGame.cubeSideS[x-1,y] == 99) L=true;
                else L=false;

                if (y+1 == 4) B=false;
                else if (StartGame.cubeSideS[x,y+1] == 99) B=true;
                else B=false;

                if (y-1 == -1) F=false;
                else if (StartGame.cubeSideS[x,y-1] == 99) F=true;
                else F=false;
                


// поиск направления поворота
                    if (screenTouch.deltaPosition.x < -20 && !L ) BrekScript();
                    if (screenTouch.deltaPosition.x > 20 && !R)  BrekScript();
                    if (screenTouch.deltaPosition.y > 20 && !F)  BrekScript();
                    if (screenTouch.deltaPosition.y < -20 && !B)  BrekScript();

                    if 		(screenTouch.deltaPosition.x < -20 && L ) 
                    {
                        direction = 'L';
                        Dir(direction);
                    }
                    else if (screenTouch.deltaPosition.x > 20 && R) 
                    {
                        direction = 'R';
                        Dir(direction);
                    }
                    else if (screenTouch.deltaPosition.y > 20 && F)        
                    {
                        direction = 'F';
                        Dir(direction);
                    }
                    else if (screenTouch.deltaPosition.y < -20 && B)         
                    {
                        direction = 'B';
                        Dir(direction);
                    }
                    

                }
            }
        }


        
        

      // 

      if (MoveText.text == "Black Player" & isActive)
      {
          // тут надо получить данные из сети 
         
          x = 0;
          y = 3;
          direction = 'F';
          Dir(direction);
          

      }
                
        
        
            
      

        
    }

// -----------------------------------------------------------------------------------------------------
// направление поворота    
    void Dir(Char dir)
    {
   
        if (dir =='L') Assemble(Vector3.left);
        if (dir =='R') Assemble(Vector3.right);
        if (dir =='F') Assemble(Vector3.forward);
        if (dir =='B') Assemble(Vector3.back);
    }

// подготовка к перемещению кубика    
    void Assemble(Vector3 dir) 
    {
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
    }
    
// прерывание скрипта
    void BrekScript()
    {
        _isMoving = false;
		isActive = false;
        return;
    }
	
// поворот перемещение кубика	
    private IEnumerator Roll(Vector3 anchor, Vector3 axis)   
	{
        _isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++) {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
		isActive = false;

            // изменение данных в массивах
            if (direction == 'B') 
            {
                StartGame.cubeSide[x,y+1] = StartGame.cubeSide[x,y] ;
                StartGame.cubeSideS[x,y+1] =  StartGame.cubeTable[StartGame.cubeSideS[x,y],0];
            }
            else if (direction == 'F') 
            {
                StartGame.cubeSide[x,y-1] = StartGame.cubeSide[x,y] ;
                StartGame.cubeSideS[x,y-1] =  StartGame.cubeTable[StartGame.cubeSideS[x,y],1];
            }
            else if (direction == 'R') 
            {
                StartGame.cubeSide[x+1,y] = StartGame.cubeSide[x,y] ;
                StartGame.cubeSideS[x+1,y] =  StartGame.cubeTable[StartGame.cubeSideS[x,y],2];
            }
            else if (direction == 'L') 
            {
                StartGame.cubeSide[x-1,y] = StartGame.cubeSide[x,y] ;
                StartGame.cubeSideS[x-1,y] =  StartGame.cubeTable[StartGame.cubeSideS[x,y],3];
            }
            StartGame.cubeSide[x,y] = "";
            StartGame.cubeSideS[x,y] = '.';

            
            ChangingPlayer();
            

    }

// меняем игрока
    void ChangingPlayer()        
    {
        if ( MoveText.text == "Red Player") 
        {
            MoveText.text ="Black Player";
            GameObject.Find("CubeBPlay").transform.position = new Vector3(0f, -3.7f, 3.00f);
            GameObject.Find("CubeRPlay").transform.position = new Vector3(4f, -3.7f, 3f);  
            
            
            
            
        }
        else if (MoveText.text == "Black Player") 
        {
            MoveText.text ="Red Player";
            GameObject.Find("CubeRPlay").transform.position = new Vector3(0f, -3.7f, 3f);
            GameObject.Find("CubeBPlay").transform.position = new Vector3(4f, -3.7f, 3.00f);
        }  
    }

}

