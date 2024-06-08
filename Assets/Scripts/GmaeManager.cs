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
        _monsters.Add(eneme);
        Object.Instantiate(eneme);

        _player = GameObject.Find("Sphere");
    }

    

}
