using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public enum Gamestate { Starting, Charge, BulletPick, Shoot }

public class PlayerControls : MonoBehaviour
{

    Prova provaLinker;

    public Gamestate State = Gamestate.Starting;
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

        if (State == Gamestate.Starting)
        {
            State = Gamestate.Charge;
        }
        else if (State == Gamestate.Charge && time > timing)
        {
            State = Gamestate.BulletPick;
            randomPick = Random.Range(0, 5);
        }
        else if (State == Gamestate.Shoot)
        {
        }

    }


}
