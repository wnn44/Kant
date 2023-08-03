using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class OnMous : MonoBehaviour
{
   private int x, y, old_x, old_y, delta_x, delta_y;
  

   public Vector2Int GridSize = new Vector2Int(4, 4);
   
   private Camera mainCamera;
   [SerializeField] private GameObject _gameObject;
   [SerializeField] private CubeKant _cubeKant;
   [SerializeField] private iiGame _iiGame;
   private bool _grablya;
   
   public Text MoveText; 
  
      
      
   
   void OnMouseDown()
   {
      _gameObject = gameObject;
      //Debug.Log(_cubeKant);
      _grablya = false;
   }
   
   private void Awake()
   {
      
      mainCamera = Camera.main;
   
   }
   
   private void Update()
   {
      
      if (_cubeKant._isMoving) return;
      

      if (_gameObject != null)
      {
         var groundPlane = new Plane(Vector3.up, Vector3.zero);
         Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

         if (groundPlane.Raycast(ray, out float position))
         {
            Vector3 worldPosition = ray.GetPoint(position);

            x = Mathf.RoundToInt(worldPosition.x+.5f);
            y = Mathf.RoundToInt(worldPosition.z+.5f);
            
            delta_x = old_x - x;
            delta_y = old_y - y;
            old_x = x;
            old_y = y;
            if (_grablya)
            {
               if (gameObject.tag == "cubeR" && MoveText.text == "Red Player" && StartGame.iiGameOn == false) // ходят красные, компьютеру нельзя
               {
                  if (delta_x == 1) _cubeKant.Assemble(Vector3.left);
                  else if (delta_x == -1) _cubeKant.Assemble(Vector3.right);
                  else if (delta_y == -1) _cubeKant.Assemble(Vector3.forward);
                  else if (delta_y == 1) _cubeKant.Assemble(Vector3.back);
               }
               
               // раскоментировать, если играть самс собой
               /*if (gameObject.tag == "cubeB" && MoveText.text == "Black Player") // ходят черные
               {
                  if (delta_x == 1) _cubeKant.Assemble(Vector3.left);
                  else if (delta_x == -1) _cubeKant.Assemble(Vector3.right);
                  else if (delta_y == -1) _cubeKant.Assemble(Vector3.forward);
                  else if (delta_y == 1) _cubeKant.Assemble(Vector3.back);                  
               }*/


            }
            
            _grablya = true;


            
            if (!Input.GetMouseButton(0))
            {

               _gameObject = null;
            }

         }
      }
   }


}
