using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeKant : MonoBehaviour



{
    [SerializeField] private int _rollSpeed;
    [SerializeField] private SaveData _saveData;
    [SerializeField] private GameRules _gameRules;
    //[SerializeField] private iiGame _iiGame;
    public bool _isMoving = false;
    public Text MoveText; 
    
    





    public void Assemble(Vector3 dir)
    {
        
        
        
        
        _gameRules.Rules(dir);
        if (!_gameRules._rulesOn) return;
         //_saveData.SaveDataFile(gameObject.name,dir); //запись хода в файл
        
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
    }
    
	
// поворот перемещение кубика	
    private IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        ChangingPlayer();
        _isMoving = false;
    }
    
    // меняем игрока
    void ChangingPlayer()        
    {
        if ( MoveText.text == "Red Player") 
        {
            MoveText.text ="Black Player";
            StartGame.iiGameOn = true;
        }
        else if (MoveText.text == "Black Player") 
        {
            MoveText.text ="Red Player";
        }  
    }
}
