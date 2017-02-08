using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState { InitPlayer, Starting, Charge, Shoot, AfterShoot }

public class PlayerControls : MonoBehaviour
{
    public GameObject[] bullets = new GameObject[6];
    public int currentBullet;
    public LogicCylinder logicLinker;
    public PlayerControls opponent;
    public int playerLife = 3;
    public int randomPick;
    public Button startButton;
    public PlayerState state = PlayerState.InitPlayer;
    public float time = 0;
    public float timing = 5;
    private GameController gcLinker;
    private Prova provaLinker;
    public int bullet
    {
        get { return currentBullet; }
        set { currentBullet = value; }
    }

    public void ImReady()
    {
        gcLinker.HasShoot = false;
        if (gcLinker.GamePhase == GameState.InitPhase)
        {
            state = PlayerState.Starting;
            gcLinker.GamePhase = GameState.WaitingPhase;
            StartCoroutine(WaitingForPlayerCO());
        }
        else if (gcLinker.GamePhase == GameState.WaitingPhase)
        {
            state = PlayerState.Charge;
            gcLinker.GamePhase = GameState.ChargingPhase;
            StartCoroutine(logicLinker.MovingCylinderCO());
        }

        startButton.gameObject.SetActive(false);
    }

    private void Awake()
    {
        provaLinker = FindObjectOfType<Prova>();
        gcLinker = FindObjectOfType<GameController>();
    }

    private void DamageHandler(int idBullet)
    {
        switch (idBullet)
        {
            case 1:
                opponent.playerLife -= 1;
                Debug.Log("opponent perde un punto vita");
                break;

            case 2:
                opponent.playerLife -= 2;
                Debug.Log("opponent perde due punti vita");
                break;

            case 3:
                Debug.Log("opponent viene curato");
                opponent.playerLife += 1;
                break;

            case 4:
                Debug.Log("Miss");
                break;

            case 5:
                playerLife -= 1;
                Debug.Log("explodi");
                break;

            case 6:
                Debug.Log("dodge");
                break;
        }
    }

    private void OnMouseDown()
    {
        if (state == PlayerState.Shoot)
        {
            state = PlayerState.AfterShoot;
            gcLinker.GamePhase = GameState.UpdateStatus;
            ShootWithBullet(currentBullet);
            StartCoroutine(WaitForAnotherMatchCO());
            if (gcLinker.HasShoot)
            {
                gcLinker.GamePhase = GameState.InitPhase;
            }
            gcLinker.HasShoot = true;
        }
        else if (state == PlayerState.AfterShoot)
        {
            state = PlayerState.InitPlayer;
            gcLinker.GamePhase = GameState.InitPhase;
        }
    }

    private void ShootWithBullet(int choosedBullet)
    {
        GameObject go;
        switch (choosedBullet)
        {
            case 0:
                DamageHandler(logicLinker.ammoBoxes[choosedBullet].GetComponent<ShootBrain>().TypeOfShoot());
                go = Instantiate(gcLinker.replacingBullets[Random.Range(0, 5)]);
                go.transform.parent = logicLinker.ammoBoxes[choosedBullet].transform.parent;
                Destroy(logicLinker.ammoBoxes[choosedBullet]);
                logicLinker.ammoBoxes.SetValue(go, choosedBullet);
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = new Vector3(0, 0, 240);
                go.AddComponent<ShootBrain>();
                break;

            case 1:
                DamageHandler(logicLinker.ammoBoxes[choosedBullet].GetComponent<ShootBrain>().TypeOfShoot());
                go = Instantiate(gcLinker.replacingBullets[Random.Range(0, 5)]);
                go.transform.parent = logicLinker.ammoBoxes[choosedBullet].transform.parent;
                Destroy(logicLinker.ammoBoxes[choosedBullet]);
                logicLinker.ammoBoxes.SetValue(go, choosedBullet);
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = new Vector3(0, 0, 300);
                go.AddComponent<ShootBrain>();
                break;

            case 2:
                DamageHandler(logicLinker.ammoBoxes[choosedBullet].GetComponent<ShootBrain>().TypeOfShoot());
                go = Instantiate(gcLinker.replacingBullets[Random.Range(0, 5)]);
                go.transform.parent = logicLinker.ammoBoxes[choosedBullet].transform.parent;
                Destroy(logicLinker.ammoBoxes[choosedBullet]);
                logicLinker.ammoBoxes.SetValue(go, choosedBullet);
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = new Vector3(0, 0, 0);
                go.AddComponent<ShootBrain>();
                break;

            case 3:
                DamageHandler(logicLinker.ammoBoxes[choosedBullet].GetComponent<ShootBrain>().TypeOfShoot());
                go = Instantiate(gcLinker.replacingBullets[Random.Range(0, 5)]);
                go.transform.parent = logicLinker.ammoBoxes[choosedBullet].transform.parent;
                Destroy(logicLinker.ammoBoxes[choosedBullet]);
                logicLinker.ammoBoxes.SetValue(go, choosedBullet);
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = new Vector3(0, 0, 90);
                go.AddComponent<ShootBrain>();
                break;

            case 4:
                DamageHandler(logicLinker.ammoBoxes[choosedBullet].GetComponent<ShootBrain>().TypeOfShoot());
                go = Instantiate(gcLinker.replacingBullets[Random.Range(0, 5)]);
                go.transform.parent = logicLinker.ammoBoxes[choosedBullet].transform.parent;
                Destroy(logicLinker.ammoBoxes[choosedBullet]);
                logicLinker.ammoBoxes.SetValue(go, choosedBullet);
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = new Vector3(0, 0, 135);
                go.AddComponent<ShootBrain>();
                break;

            case 5:
                DamageHandler(logicLinker.ammoBoxes[choosedBullet].GetComponent<ShootBrain>().TypeOfShoot());
                go = Instantiate(gcLinker.replacingBullets[Random.Range(0, 5)]);
                go.transform.parent = logicLinker.ammoBoxes[choosedBullet].transform.parent;
                Destroy(logicLinker.ammoBoxes[choosedBullet]);
                logicLinker.ammoBoxes.SetValue(go, choosedBullet);
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = new Vector3(0, 0, 177);
                go.AddComponent<ShootBrain>();
                break;
        }
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //provaLinker.StateUpdate();
    }
    private IEnumerator WaitForAnotherMatchCO()
    {
        while (gcLinker.GamePhase == GameState.UpdateStatus)
        {
            yield return null;
        }
        state = PlayerState.InitPlayer;
        gcLinker.GamePhase = GameState.InitPhase;
        startButton.gameObject.SetActive(true);
        opponent.startButton.gameObject.SetActive(true);
    }
    private IEnumerator WaitingForPlayerCO()
    {
        while (gcLinker.GamePhase == GameState.WaitingPhase)
        {
            yield return null;
        }
        state = PlayerState.Charge;
        StartCoroutine(logicLinker.MovingCylinderCO());
    }
}