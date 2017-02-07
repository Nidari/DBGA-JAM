using UnityEngine;
using UnityEngine.SceneManagement;

//public enum Gamestate { Starting, Charge, BulletPick, Shoot }

public class Prova : MonoBehaviour
{
    public GameObject tamburo;
    public int ciccio;
    public GameObject[] ammoBoxes = new GameObject[6];
    public PlayerState State = PlayerState.Starting;
    public float time = 0;
    public float timing = 5;
    public int randomPick;
    private Vector3 myPosition;

    [Range(0, 1)]
    public float prrr = 0;

    // Use this for initialization
    private void Start()
    {
        //ammoBoxes = GetComponentsInChildren<GameObject>();
    }

    /// <summary>
    /// quando clicco c'è un tempo random in cui si blocca su uno dei 6 elementi
    ///
    /// tamburo fermo = vedo lettere e/o numeri casuali
    /// parte il tamburo e i proiettili si coprono (valore esposto del tempo dopo cui vanno in fade)
    /// dopo un tempo X (randomico) il tamburo si ferma
    /// aggiungere un tasto per scoprire le lettere dopo che si è fermato
    ///
    ///
    ///
    /// </summary>
    // Update is called once per frame
    private void Update()
    {
        //Mathf.Lerp()
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    if (State == Gamestate.Starting)
        //    {
        //        State = Gamestate.Charge;
        //    }
        //    else if (State == Gamestate.Charge && time > timing)
        //    {
        //        State = Gamestate.BulletPick;
        //        randomPick = Random.Range(0, 5);
        //    }
        //    else if (State == Gamestate.Shoot)
        //    {
        //    }
        //}

        //StateUpdate();

        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void StateUpdate()
    {
        if (State == PlayerState.Charge)
        {
            tamburo.transform.eulerAngles += new Vector3(0, 0, ciccio * Time.deltaTime);
            time += Time.deltaTime;
            myPosition = this.transform.eulerAngles;
        }
        else if (State == PlayerState.BulletPick && time > timing)
        {
            GetBulletPosition();
        }
        else if (State == PlayerState.Shoot)
        {
        }
    }

    private void GetBulletPosition()
    {
        int tempTime = Random.Range(1, 6);
        float myTime = 0;
        switch (randomPick)
        {
            case 0:
                myTime += Time.deltaTime;
                tamburo.transform.eulerAngles = Vector3.Lerp(myPosition, new Vector3(0, 0, 56), myTime / tempTime);
                
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            default:
                break;
        }
    }
}