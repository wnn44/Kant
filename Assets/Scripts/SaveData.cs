using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Используем библиотеку ввода вывода

public class SaveData : MonoBehaviour
{
    public string filename; // Путь сохранения
    string _dirStr;
    
    void Start()
    {
        if ( filename == "" ) filename = "z:/KantBase.txt"; 
        // Если название файла не указанно то пишем по умолчанию
    }

    public void SaveDataFile(string _cube, Vector3 _dir)
    {
        
        //StreamWriter sw = new StreamWriter(filename); // Создаем файл
        
        // добавляем в существующий файл или создаем новый
        StreamWriter sw;
        FileInfo fi = new FileInfo(filename);
        sw = fi.AppendText();
        
        _cube = _cube.Replace("Cube",""); // обрезаем для компактного хранения
        if (_dir == Vector3.left) _dirStr = "L";
        else if (_dir == Vector3.right) _dirStr = "R";
        else if (_dir == Vector3.forward) _dirStr = "U";
        else if (_dir == Vector3.back) _dirStr = "D";

        
        sw.WriteLine(_cube+" "+_dirStr); // Сохраняем
        
        
        sw.Close(); // Закрываем(сохраняем)
    }
    
    
}
