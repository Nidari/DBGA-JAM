using System.Collections;
using UnityEngine;

public class LogicCylinder : MonoBehaviour
{
    private GameController gcLinker;
    public Transform positionInScene;
    private Vector3 myInitialPosition;
    public PlayerControls myPlayer;
    public GameObject[] ammoBoxes = new GameObject[6];
    public float waitingTime = 2;

    private bool rotating = false;

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

    private void Awake()
    {
        ammoBoxes[0].AddComponent<ShootBrain>();
        ammoBoxes[1].AddComponent<ShootBrain>();
        ammoBoxes[2].AddComponent<ShootBrain>();
        ammoBoxes[3].AddComponent<ShootBrain>();
        ammoBoxes[4].AddComponent<ShootBrain>();
        ammoBoxes[5].AddComponent<ShootBrain>();
    }

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
                Color nuovoColore = ammo.GetComponent<SpriteRenderer>().color;

                ammo.GetComponent<SpriteRenderer>().color = new Color(nuovoColore.r, nuovoColore.g, nuovoColore.b, Mathf.Lerp(1, 0, (hideTime / rotatingTime)));
            }
        }
    }

    public IEnumerator MovingCylinderCO()
    {
        speed = 0;
        hideTime = 0;
        foreach (var ammo in ammoBoxes)
        {
            ammo.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1); 
        }
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

    public IEnumerator MovingOutCylinderCO()
    {
        speed = 0;
        yield return new WaitForSeconds(1.5f);
        while (speed < timeToExec)
        {
            if (gcLinker.GamePhase == GameState.ChargingPhase)
            {
                speed += Time.deltaTime;
                this.transform.position = Vector3.Lerp(positionInScene.position, myInitialPosition, speed / timeToExec);
            }
            yield return null;
        }
        gcLinker.GamePhase = GameState.ShootingTimer;
        gcLinker.PrepareToShoot();
    }

    private IEnumerator RotateCylinderCO()
    {
        yield return new WaitForSeconds(waitingTime);
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
        int randomBullet = Random.Range(0, 6);
        myPlayer.bullet = randomBullet;
        Debug.Log(randomBullet);
        myPosition = this.transform.eulerAngles;
        Vector3 findBullet;

        while (myTime / tempTime < 1)
        {
            switch (randomBullet)
            {
                case 0:
                    myTime += Time.deltaTime;
                    findBullet = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 31 - 360, myTime / tempTime));
                    tamburo.transform.eulerAngles = findBullet;
                    break;

                case 1:
                    myTime += Time.deltaTime;
                    findBullet = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 330 - 360, myTime / tempTime));
                    tamburo.transform.eulerAngles = findBullet;
                    break;

                case 2:
                    myTime += Time.deltaTime;
                    findBullet = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 270 - 360, myTime / tempTime));
                    tamburo.transform.eulerAngles = findBullet;
                    break;

                case 3:
                    myTime += Time.deltaTime;
                    findBullet = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 210 - 360, myTime / tempTime));
                    tamburo.transform.eulerAngles = findBullet;
                    break;

                case 4:
                    myTime += Time.deltaTime;
                    findBullet = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 150 - 360, myTime / tempTime));
                    tamburo.transform.eulerAngles = findBullet;
                    break;

                case 5:
                    myTime += Time.deltaTime;
                    findBullet = new Vector3(0, 0, Mathf.Lerp(myPosition.z, 90 - 360, myTime / tempTime));
                    tamburo.transform.eulerAngles = findBullet;
                    break;

                default:
                    break;
            }
            yield return null;
        }
        StartCoroutine(MovingOutCylinderCO());
    }
}