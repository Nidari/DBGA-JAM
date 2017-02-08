using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState { InitPlayer, Starting, Charge, Shoot, AfterShoot}

public class PlayerControls : MonoBehaviour
{
    private Prova provaLinker;
    private GameController gcLinker;
    public LogicCylinder logicLinker;
    public PlayerControls opponent;

    

    public Button startButton;
    public PlayerState state = PlayerState.InitPlayer;
    public int randomPick;
    public float time = 0;
    public float timing = 5;
    public int currentBullet;
    public GameObject[] bullets = new GameObject[6];
    public int playerLife = 3;

    private void Awake()
    {
        provaLinker = FindObjectOfType<Prova>();
        gcLinker = FindObjectOfType<GameController>();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //provaLinker.StateUpdate();
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
    IEnumerator WaitForAnotherMatchCO()
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

    private IEnumerator WaitingForPlayerCO()
    {
        while (gcLinker.GamePhase == GameState.WaitingPhase)
        {
            yield return null;
        }
        state = PlayerState.Charge;
        StartCoroutine(logicLinker.MovingCylinderCO());
    }

    public int bullet
    {
        get { return currentBullet; }
        set { currentBullet = value; }
    }

    private void ShootWithBullet(int choosedBullet)
    {        
        switch (choosedBullet)
        {
            case 0:
                DamageHandler(logicLinker.ammoBoxes[0].GetComponent<ShootBrain>().TypeOfShoot());
                break;

            case 1:
                DamageHandler(logicLinker.ammoBoxes[1].GetComponent<ShootBrain>().TypeOfShoot());
                break;

            case 2:
                DamageHandler(logicLinker.ammoBoxes[2].GetComponent<ShootBrain>().TypeOfShoot());
                break;

            case 3:
                DamageHandler(logicLinker.ammoBoxes[3].GetComponent<ShootBrain>().TypeOfShoot());
                break;

            case 4:
                DamageHandler(logicLinker.ammoBoxes[4].GetComponent<ShootBrain>().TypeOfShoot());
                break;

            case 5:
                DamageHandler(logicLinker.ammoBoxes[5].GetComponent<ShootBrain>().TypeOfShoot());
                break;
        }
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
}