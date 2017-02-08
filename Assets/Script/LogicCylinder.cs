﻿using System.Collections;
using UnityEngine;

public class LogicCylinder : MonoBehaviour
{
    private GameController gcLinker;
    public Transform positionInScene;
    private Vector3 myInitialPosition;

    public GameObject[] ammoBoxes = new GameObject[6];

    bool rotating = false;

    // [Range(0, 10)]
    public float hideTime = 1f;

    public float rotatingTime;
    public float rotateSpeed;

    [Range(0, 1)]
    private float speed = 0;

    [Range(0, 1)]
    public float ciccio = 0;

    public float timeToExec = 0f;

    // Use this for initialization
    private void Start()
    {
        gcLinker = FindObjectOfType<GameController>();
        myInitialPosition = this.transform.position;
    }

    private void Update()
    {

        if (gcLinker.GamePhase == GameState.ChargingPhase && rotating)
        {
            hideTime += Time.deltaTime;
            foreach (var ammo in ammoBoxes)
            {
                Color nuovoColore = ammo.GetComponent<MeshRenderer>().material.color;
               
                ammo.GetComponent<MeshRenderer>().material.color = new Color(nuovoColore.r, nuovoColore.g, nuovoColore.b, Mathf.Lerp(1,0,(hideTime/rotatingTime)));
                
            }
        }
    }

    public IEnumerator MovingCylinderCO()
    {
        while (speed < timeToExec)
        {
            if (gcLinker.GamePhase == GameState.ChargingPhase)
            {
                speed += Time.deltaTime;               
                this.transform.position = Vector3.Lerp(myInitialPosition, positionInScene.position, speed / timeToExec);
            }
            yield return null;
        }
        StartCoroutine(RotateCylinderCO());
    }

    private IEnumerator RotateCylinderCO()
    {
        GameObject tamburo = this.gameObject;
        Vector3 myPosition = this.transform.eulerAngles;
        float speedTime = 0;
        rotating = true;
        while (speedTime < rotatingTime)
        {
            tamburo.transform.eulerAngles -= new Vector3(0, 0, rotateSpeed * 2);
            speedTime += Time.deltaTime;

            yield return null;
        }
        rotating = false;
        float myTime = 0;
        float tempTime = 1;
        int cazzo = Random.Range(0, 6);

        myPosition = this.transform.eulerAngles;
        Vector3 asd;
        while (true)
        {
            switch (cazzo)
            {
                case 0:
                    myTime += Time.deltaTime;
                    asd = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 0, myTime / tempTime));
                    tamburo.transform.eulerAngles = asd;

                    break;

                case 1:
                    myTime += Time.deltaTime;
                    asd = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 56, myTime / tempTime));
                    tamburo.transform.eulerAngles = asd;
                    break;

                case 2:
                    myTime += Time.deltaTime;
                    asd = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 121, myTime / tempTime));
                    tamburo.transform.eulerAngles = asd;
                    break;

                case 3:
                    myTime += Time.deltaTime;
                    asd = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 180, myTime / tempTime));
                    tamburo.transform.eulerAngles = asd;
                    break;

                case 4:
                    myTime += Time.deltaTime;
                    asd = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 238, myTime / tempTime));
                    tamburo.transform.eulerAngles = asd;
                    break;

                case 5:
                    myTime += Time.deltaTime;
                    asd = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 301, myTime / tempTime));
                    tamburo.transform.eulerAngles = asd;
                    break;

                default:
                    break;
            }
            yield return null;
        }
    }
}