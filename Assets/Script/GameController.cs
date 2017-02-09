using System.Collections;
using UnityEngine;

/// <summary>
/// GC PHASE:
///     - Init = button waiting from both players
///     - WaitingPlayer = one of the player is waiting
///     - Charging = cylinder rotation & bullet picking
///     - Shoot = waiting for players input
///     - UpdateStatus = refresh all gameplay variables
///     - AnimationPhase = wait for all animation then return to init
///
/// PLAYER PHASE:
///     - InitPlayer = UI button click
///     - Starting = Wait the other player to start
///     - Charge = cylinder rotation logic & bullet picking
///     - ShootingTimer = wait until
///     - Shoot = player input
///     - AfterShoot = wait until all players shoot
///
/// </summary>
public enum GameState { InitPhase, WaitingPhase, ChargingPhase, ShootingTimer, ShootPhase, UpdateStatus,AnimationPhase }

public class GameController : MonoBehaviour
{
    public GameState GamePhase = GameState.InitPhase;
    private bool steadyPhase = false;
    private bool hasShoot = false;
    public float timeToShoot = 3;
    private PlayerControls[] players;
    public GameObject[] replacingBullets = new GameObject[6];
    GameObject paneGameOver;
    bool gameOver = false;
    void Awake()
    {
        paneGameOver = FindObjectOfType<GOPanel>().gameObject;
        paneGameOver.SetActive(false);
    }

    // Use this for initialization
    private void Start()
    {
        players = FindObjectsOfType<PlayerControls>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PrepareToShoot()
    {
        if (!steadyPhase)
        {
            steadyPhase = true;
            StartCoroutine(WaitingTimeCO());
        }
    }

    private IEnumerator WaitingTimeCO()
    {
        float timeLapse = 0;
        while (timeLapse / timeToShoot < 1)
        {
            timeLapse += Time.deltaTime;
            yield return null;
        }
        GamePhase = GameState.ShootPhase;
        foreach (var player in players)
        {
            player.state = PlayerState.Shoot;
        }
        steadyPhase = false;
    }

    public bool HasShoot
    {
        get
        {
            return hasShoot;
        }

        set
        {
            hasShoot = value;
        }
    }
    
    public void DamageResoulution()
    {
        foreach (var player in players)
        {
            if (player.iShoot)
            {
                switch (player.whichBullet)
                {
                    case BulletType.fire:
                    if (!player.opponent.dodge)
                    {
                        player.opponent.playerLife -= 1;
                    }
                    
                    break;
                    case BulletType.doubleFire:
                    if (!player.opponent.dodge)
                    {
                        player.opponent.playerLife -= 2;
                    }
                    break;
                    case BulletType.heal:
                    if (!player.opponent.dodge)
                    {
                        if (player.opponent.playerLife < 3)
                        {
                            player.opponent.playerLife += 1;
                        }
                    }
                    break;
                    case BulletType.explosion:
                    player.playerLife -= 1;
                    break;
                    
                    
                    
                    
                }
            }
            else
            {
                Reload(player);
            }
            //player.whichBullet = BulletType.noShoot;
            
            player.iShoot = false;
        }
    }

    public void CheckGameOver(PlayerControls player)
    {
        GamePhase = GameState.InitPhase;
        player.state = PlayerState.InitPlayer;
        player.opponent.dodge = false;
        if (player.playerLife > 0 && !gameOver)
        {
            
            player.startButton.gameObject.SetActive(true);
            player.opponent.startButton.gameObject.SetActive(true);
        }
        else
        {
            gameOver = true;
            paneGameOver.SetActive(true);
            if (player.logicLinker.player == WhichPlayer.player1)
            {
                paneGameOver.GetComponent<GOPanel>().P1Win();
            }
            else
            {
                paneGameOver.GetComponent<GOPanel>().P2Win();
            }
            player.startButton.gameObject.SetActive(false);
            player.opponent.startButton.gameObject.SetActive(false);
        }

        if (players[0].playerLife <= 0 && players[0].playerLife <= 0)
        {
            paneGameOver.GetComponent<GOPanel>().Draw();
        }
        
    }

    void Reload(PlayerControls player)
    {

        GameObject go;
        for (int i = 0; i < player.logicLinker.ammoBoxes.Length; i++)
        {
            go = Instantiate(replacingBullets[Random.Range(0, 5)]);
            go.transform.parent = player.logicLinker.ammoBoxes[i].transform.parent;
            Destroy(player.logicLinker.ammoBoxes[i]);
            player.logicLinker.ammoBoxes.SetValue(go, i);
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = new Vector3(0, 0, 240);
            go.AddComponent<ShootBrain>();
            
        }
        
    }
}