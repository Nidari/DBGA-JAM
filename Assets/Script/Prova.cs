using UnityEngine;
using UnityEngine.SceneManagement;

//public enum PlayerState { Starting, Charge, BulletPick, Shoot }



public class Prova : MonoBehaviour
{
    public GameObject tamburo;
    public int ciccio;
    public GameObject[] ammoBoxes = new GameObject[6];
    public PlayerState State;
    public float time = 0;
    public float timing = 5;
    public int randomPick;
    private Vector3 myPosition;
    private int tempTime;
    private float myTime = 0;

    [Range(0, 10)]
    public float hideTime = 0;

    public float timeForFade = 1;

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
        State = FindObjectOfType<PlayerControls>().state;
        ////Mathf.Lerp()
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    if (State == PlayerState.Starting)
        //    {
        //        State = PlayerState.Charge;
        //    }
        //    else if (State == PlayerState.Charge && time > timing)
        //    {
        //        State = PlayerState.BulletPick;
        //        randomPick = Random.Range(0, 5);
        //        tempTime = Random.Range(1, 3);
        //    }
        //    else if (State == PlayerState.Shoot)
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
            
            tamburo.transform.eulerAngles -= new Vector3(0, 0, ciccio * Time.deltaTime);
            time += Time.deltaTime;
            myPosition = this.transform.eulerAngles;

            foreach (var ammo in ammoBoxes)
            {
                ammo.GetComponent<MeshRenderer>().material.color -= new Color(0, 0, 0, hideTime * Time.deltaTime);
            }
        }
        
        else if (State == PlayerState.Shoot)

        {
        }
    }

    private void GetBulletPosition()
    {
        /*if (myTime < tempTime)
        {
            switch ()
            {
                case 0:
                    myTime += Time.deltaTime;
                    tamburo.transform.eulerAngles = Vector3.Lerp(myPosition, new Vector3(0, 0, 0), myTime / tempTime);
                    break;

                case 1:
                    myTime += Time.deltaTime;
                    tamburo.transform.eulerAngles = Vector3.Lerp(myPosition, new Vector3(0, 0, 56), myTime / tempTime);
                    break;

                case 2:
                    myTime += Time.deltaTime;
                    tamburo.transform.eulerAngles = Vector3.Lerp(myPosition, new Vector3(0, 0, 121), myTime / tempTime);
                    break;

                case 3:
                    myTime += Time.deltaTime;
                    tamburo.transform.eulerAngles = Vector3.Lerp(myPosition, new Vector3(0, 0, 180), myTime / tempTime);
                    break;

                case 4:
                    myTime += Time.deltaTime;
                    tamburo.transform.eulerAngles = Vector3.Lerp(myPosition, new Vector3(0, 0, 238), myTime / tempTime);
                    break;

                case 5:
                    myTime += Time.deltaTime;
                    tamburo.transform.eulerAngles = Vector3.Lerp(myPosition, new Vector3(0, 0, 301), myTime / tempTime);
                    break;

                default:
                    break;
            }
        }*/
    }
}