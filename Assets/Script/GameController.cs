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
///     - Shoot = player input
/// 
/// </summary>
public enum GameState {InitPhase,WaitingPhase,ChargingPhase,ShootPhase,UpdateStatus}



public class GameController : MonoBehaviour {

    public GameState GamePhase = GameState.InitPhase; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
