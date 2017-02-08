using System.Collections;
using UnityEngine;

/// <summary>
/// GC PHASE:
///     - Init = button waiting from both players
///     - WaitingPlayer = one of the player is waiting
///     - Charging = cylinder rotation & bullet picking
///     - Shoot = waiting for players input
///     - UpdateStatus = refresh all gameplay variables
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
public enum GameState { InitPhase, WaitingPhase, ChargingPhase, ShootingTimer, ShootPhase, UpdateStatus }

public class GameController : MonoBehaviour
{
    public GameState GamePhase = GameState.InitPhase;
    private bool steadyPhase = false;
    private bool hasShoot = false;
    public float timeToShoot = 3;
    private PlayerControls[] players;
    public GameObject[] replacingBullets = new GameObject[6];

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
}