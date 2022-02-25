using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    [SerializeField] public GameObject Basket;
    [SerializeField] public GameObject StartFlag;
    [SerializeField] public GameObject EndFlag;
    [SerializeField] public List<GameObject> Items = new List<GameObject>();
    [SerializeField] public GameObject Player;

    private bool done;

    private void Start()
    {
        GlobalEvents.StartFlagTouched.AddListener(StartSimulation);
        GlobalEvents.EndFlagTouched.AddListener(EndGame);

        done = false;
        EndFlag.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void StartSimulation()
    {
        EndFlag.GetComponent<Rigidbody>().isKinematic = false;
        Player.layer = 3;
    }

    public void EndGame()
    {
        done = true;
        SaveManager.LevelDone(SceneManager.GetActiveScene().name);
    }

    public void Restart()
    {
        GameScenesControl.Reload();
    }

    public void LoadHub()
    {
        if(done)
            GameScenesControl.Load("Hub");
    }
}
