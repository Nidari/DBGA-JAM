using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    public PlayerControls pl1;
    public PlayerControls pl2;
    private GameController gcLinker;
    public Animator gunMexican;
    public Animator gunPeruvian;
    public Animator pgMexican;
    public Animator pgPeruvian;
    public float execTimeAnim = 3;
    public AudioContainer soundRef;
    public AudioSource AudioRef;
    public SpriteRenderer rightRedFeedback;
    public SpriteRenderer leftRedFeedback;
    public SpriteRenderer rightGreenFeedback;
    public SpriteRenderer leftGreenFeedback;

    public Image[] lifesPL1;

    public Image[] lifesPL2;


    private void Awake()
    {
        gcLinker = FindObjectOfType<GameController>();
        //lifePanleLinker = GetComponentsInChildren<GameObject>();
        soundRef = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioContainer>();
       AudioRef= GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void AnimationUpdate()
    {
        pl1.state = PlayerState.AfterShoot;
        pl2.state = PlayerState.AfterShoot;
        StartCoroutine(AnimationCO());
    }

    private IEnumerator AnimationCO()
    {
        float timeLapse = 0;
        switch (pl1.whichBullet)
        {
            
            case BulletType.fire:

                AudioRef.PlayOneShot(soundRef.Sparo);
                gunPeruvian.SetBool("triggerFire", true);
                pgMexican.SetBool("triggerHit", true);
            if (!pl2.dodge)
            {
                StartCoroutine(firstPersonFeedback(rightRedFeedback));
            }
            

            break;
            case BulletType.doubleFire:

            AudioRef.PlayOneShot(soundRef.DoppioSparo);
                gunPeruvian.SetBool("triggerDoubleFire", true);
                pgMexican.SetBool("triggerHit", true);
            if (!pl2.dodge)
            {
                StartCoroutine(firstPersonFeedback(rightRedFeedback));
            }
            break;
            case BulletType.heal:

            AudioRef.PlayOneShot(soundRef.Heal);
                gunPeruvian.SetBool("triggerFire", true);
                pgMexican.SetBool("triggerHit", true);
            if (!pl2.dodge)
            {
                StartCoroutine(firstPersonFeedback(rightGreenFeedback));
            }
            break;
            case BulletType.explosion:
 
            AudioRef.PlayOneShot(soundRef.GunExplosion);
                gunPeruvian.SetBool("triggerExplosion", true);
                pgPeruvian.SetBool("triggerHit", true);
            
                StartCoroutine(firstPersonFeedback(leftRedFeedback));
            
            break;
            case BulletType.dodge:
                AudioRef.PlayOneShot(soundRef.ProjectileDodged);
                gunPeruvian.SetBool("triggerDodge", true);
                pgPeruvian.SetBool("triggerDodge", true);
            
            break;
            case BulletType.miss:

            // AudioRef.PlayOneShot(soundRef.Sparo);
            gunPeruvian.SetBool("triggerCilecca", true);
                pgPeruvian.SetBool("triggerCilecca", true);
            
            break;
            case BulletType.noShoot:
               // gunMexican.SetBool("trigger", true);

                //L'intero tamburo deve ricaricare
                break;
            default:
                
                break;
        }

        switch (pl2.whichBullet)
        {
            case BulletType.fire:
                AudioRef.PlayOneShot(soundRef.Sparo);
                gunMexican.SetBool("triggerFire", true);
                pgPeruvian.SetBool("triggerHit", true);
            if (!pl1.dodge)
            {
                StartCoroutine(firstPersonFeedback(leftRedFeedback));
            }
            
                break;
            case BulletType.doubleFire:
                AudioRef.PlayOneShot(soundRef.DoppioSparo);
                gunMexican.SetBool("triggerDoubleFire", true);
                pgPeruvian.SetBool("triggerHit", true);
            if (!pl1.dodge)
            {
                StartCoroutine(firstPersonFeedback(leftRedFeedback));
            }
            
            break;
            case BulletType.heal:
                AudioRef.PlayOneShot(soundRef.Heal);
                gunMexican.SetBool("triggerFire", true);
                pgPeruvian.SetBool("triggerHit", true);
            if (!pl1.dodge)
            {
                StartCoroutine(firstPersonFeedback(leftGreenFeedback));
            }
            break;
            case BulletType.explosion:
                AudioRef.PlayOneShot(soundRef.GunExplosion);
                gunMexican.SetBool("triggerExplosion", true);
                pgMexican.SetBool("triggerHit", true);
            
                StartCoroutine(firstPersonFeedback(rightRedFeedback));
            
            break;
            case BulletType.dodge:
                AudioRef.PlayOneShot(soundRef.ProjectileDodged);
                gunMexican.SetBool("triggerDodge", true);
                pgMexican.SetBool("triggerDodge", true);
            
            break;
            case BulletType.miss:
                gunMexican.SetBool("triggerCilecca", true);
                pgMexican.SetBool("triggerCilecca", true);
                break;
            case BulletType.noShoot:
                //gunPeruvian.SetBool("triggerFire", true);
                //L'intero tamburo deve ricaricare
                break;
            default:
                break;
        }
        
        LifeChangePL1();
        LifeChangePL2();
        pl1.whichBullet = BulletType.noShoot;
        pl2.whichBullet = BulletType.noShoot;


        /* while (timeLapse / execTimeAnim < 1)
         {
             Debug.Log("asd");
             timeLapse += Time.deltaTime;
             yield return null;
         }*/
        yield return new WaitForSeconds(execTimeAnim);
        //pl1.state = PlayerState.InitPlayer;
        //pl2.state = PlayerState.InitPlayer;
        //pl1.startButton.gameObject.SetActive(true);
        //pl2.startButton.gameObject.SetActive(true);
        gcLinker.CheckGameOver(pl1);
        gcLinker.CheckGameOver(pl2);
        //gcLinker.GamePhase = GameState.InitPhase;
        
    }

    IEnumerator firstPersonFeedback(SpriteRenderer feedback)
    {
        int timeLapse = 0;
        
        while (timeLapse < 4)
        {
            yield return new WaitForSeconds(0.2f);
            feedback.enabled = true;
            timeLapse += 1;
            yield return new WaitForSeconds(0.2f);
            feedback.enabled = false;
        }
    }


    private void LifeChangePL1()
    {
        foreach (var cuori in lifesPL1)
        {
            cuori.enabled = false;
        }
        for (int i = 0; i < pl1.playerLife; i++)
        {
            lifesPL1[i].enabled = true;
        }
    }

    private void LifeChangePL2()
    {
        foreach (var cuori in lifesPL2)
        {
            cuori.enabled = false;
        }
        for (int i = 0; i < pl2.playerLife; i++)
        {
            lifesPL2[i].enabled = true;
        }
    }
}