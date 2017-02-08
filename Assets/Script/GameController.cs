using UnityEngine;
using System.Collections;

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
/// 
/// </summary>
public enum GameState {InitPhase,WaitingPhase,ChargingPhase,ShootingTimer,ShootPhase,UpdateStatus}



public class GameController : MonoBehaviour {

    public GameState GamePhase = GameState.InitPhase;
    bool steadyPhase = false;
    public float timeToShoot = 3;
    PlayerControls[] players;
	// Use this for initialization
	void Start () {
        players = FindObjectsOfType<PlayerControls>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    
    public void PrepareToShoot()
    {
        if (!steadyPhase)
        {
            steadyPhase = true;
            StartCoroutine(WaitingTimeCO());
        }
    }

    IEnumerator WaitingTimeCO()
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
    }
}
