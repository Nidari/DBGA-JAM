﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState { InitPlayer, Starting, Charge, Shoot }

public class PlayerControls : MonoBehaviour
{
    private Prova provaLinker;
    private GameController gcLinker;
    public LogicCylinder logicLinker;
  

    public Button startButton;
    public PlayerState state = PlayerState.InitPlayer;
    public int randomPick;
    public float time = 0;
    public float timing = 5;


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
        if (state == PlayerState.Starting)
        {
            state = PlayerState.Charge;
        }
        //else if (state == PlayerState.Charge && provaLinker.time > timing)
        // {
        //State = PlayerState.BulletPick;

        //randomPick = Random.Range(0, 5);
        //}
        else if (state == PlayerState.Shoot)
        {
            Debug.Log("Fucking shoot");
        }
    }

    public void ImReady()
    {
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
        while (gcLinker.GamePhase == GameState.ChargingPhase)
        {
            yield return null;
        }
        state = PlayerState.Charge;
        StartCoroutine(logicLinker.MovingCylinderCO());
      
    }
}