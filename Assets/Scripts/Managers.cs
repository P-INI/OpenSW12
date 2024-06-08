using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    static GameObject _player;
    static HashSet<GameObject> _monsters = new HashSet<GameObject>();
    void Start()
    {
        Init();
    }

    void Update()
    {

    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers"); 
            s_instance = go.GetComponent<Managers>();

        }
        GameObject eneme = Resources.Load<GameObject>("Prefabs/dd");
        Vector3 spawnPosition = new Vector3(3, 4, 3);
        Quaternion spawnRotation = Quaternion.identity; 
        GameObject enemy = Object.Instantiate(eneme, spawnPosition, spawnRotation);
        
        _monsters.Add(enemy);

        _player = GameObject.Find("BoxMan@Stand");
    }

    

}
