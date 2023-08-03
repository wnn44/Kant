using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
 
public class ActivateObject : MonoBehaviour
{
    public Text MoveText; 


// Start вызывается перед первым обновлением кадра
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("После загрузки сцены и запуска игры");
        StartGame.RestartLevel();
    }
 
    void Update()
    {

        if (Input.GetMouseButtonDown(0) )
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            
             //var objectScript = hit.collider.GetComponent<DragAndRotateCube>();
            if (groundPlane.Raycast(ray, out float position))
            {

                //if (groundPlane.Raycast(ray, out float position))
                {
                    Vector3 worldPosition = ray.GetPoint(position);

                    int x = Mathf.RoundToInt(worldPosition.x);
                    int y = Mathf.RoundToInt(worldPosition.z);

               //     objectScript.transform.position = new Vector3(x+.5f,0,y);
                    if (Input.GetMouseButtonDown(0))
                    {
                 //       objectScript = null;
                    }

                }

                //if (hit.transform.tag == "cubeR" && MoveText.text == "Red Player"  )  // ходят красные  
               /* {
                    var objectScript = hit.collider.GetComponent<DragAndRotateCube>();
                    objectScript.isActive = !objectScript.isActive; 
                    Debug.Log(objectScript);
				}*/
				
            }
        }

    }
}