using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public enum PlayerState { Starting, Charge, BulletPick, Shoot }

public class PlayerControls : MonoBehaviour
{

    Prova provaLinker;

    public PlayerState State = PlayerState.Starting;
    public int randomPick;
    public float time = 0;
    public float timing = 5;

    void Awake()
    {
        provaLinker = GetComponent<Prova>();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
  
    }


    void OnMouseDown()
    {
        Debug.Log("PROVA");

        if (State == PlayerState.Starting)
        {
            State = PlayerState.Charge;
        }
        else if (State == PlayerState.Charge && time > timing)
        {
            State = PlayerState.BulletPick;
            randomPick = Random.Range(0, 5);
        }
        else if (State == PlayerState.Shoot)
        {
        }

        provaLinker.StateUpdate();



    }


}
