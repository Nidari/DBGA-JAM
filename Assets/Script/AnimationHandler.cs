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

    public Image[] lifesPL1;

    public Image[] lifesPL2;


    private void Awake()
    {
        gcLinker = FindObjectOfType<GameController>();
        //lifePanleLinker = GetComponentsInChildren<GameObject>();


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
                gunPeruvian.SetBool("triggerFire", true);
                pgMexican.SetBool("triggerHit", true);
                
                break;
            case BulletType.doubleFire:
                gunPeruvian.SetBool("triggerDoubleFire", true);
                pgMexican.SetBool("triggerHit", true);
                break;
            case BulletType.heal:
                gunPeruvian.SetBool("triggerFire", true);
                pgMexican.SetBool("triggerHit", true);
                break;
            case BulletType.explosion:
                gunPeruvian.SetBool("triggerExplosion", true);
                pgMexican.SetBool("triggerHit", true);

                break;
            case BulletType.dodge:
                gunPeruvian.SetBool("triggerDodge", true);
                pgMexican.SetBool("triggerDodge", true);
                break;
            case BulletType.miss:
                gunPeruvian.SetBool("triggerCilecca", true);
                pgMexican.SetBool("triggerCilecca", true);
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
                gunMexican.SetBool("triggerFire", true);
                pgPeruvian.SetBool("triggerHit", true);
                break;
            case BulletType.doubleFire:
                gunMexican.SetBool("triggerDoubleFire", true);
                pgPeruvian.SetBool("triggerHit", true);
                break;
            case BulletType.heal:
                gunMexican.SetBool("triggerFire", true);
                pgPeruvian.SetBool("triggerHit", true);
                break;
            case BulletType.explosion:
                gunMexican.SetBool("triggerExplosion", true);
                pgPeruvian.SetBool("triggerHit", true);
                break;
            case BulletType.dodge:
                gunMexican.SetBool("triggerDodge", true);
                pgPeruvian.SetBool("triggerDodge", true);
                break;
            case BulletType.miss:
                gunMexican.SetBool("triggerCilecca", true);
                pgPeruvian.SetBool("triggerCilecca", true);
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
        pl1.state = PlayerState.InitPlayer;
        pl2.state = PlayerState.InitPlayer;
        pl1.startButton.gameObject.SetActive(true);
        pl2.startButton.gameObject.SetActive(true);
        gcLinker.GamePhase = GameState.InitPhase;
        
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