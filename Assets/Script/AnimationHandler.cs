using System.Collections;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public PlayerControls pl1;
    public PlayerControls pl2;
    private GameController gcLinker;
    public Animator gunMexican;
    public Animator gunPeruvian;
    public float execTimeAnim = 3;

    private void Awake()
    {
        gcLinker = FindObjectOfType<GameController>();
       
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

                break;
            case BulletType.doubleFire:
                gunPeruvian.SetBool("triggerDoubleFire", true);
                break;
            case BulletType.heal:
                //gunMexican.SetBool("triggerFire", true);
                break;
            case BulletType.explosion:
                gunPeruvian.SetBool("triggerExplosion", true);
                break;
            case BulletType.dodge:
                gunPeruvian.SetBool("triggerDodge", true);
                break;
            case BulletType.miss:
                gunPeruvian.SetBool("triggerCilecca", true);
                break;
            case BulletType.noShoot:
               // gunMexican.SetBool("trigger", true);
                break;
            default:
                break;
        }

        switch (pl2.whichBullet)
        {
            case BulletType.fire:
                gunMexican.SetBool("triggerFire", true);
                break;
            case BulletType.doubleFire:
                gunMexican.SetBool("triggerDoubleFire", true);
                break;
            case BulletType.heal:
              //  gunPeruvian.SetBool("triggerFire", true);
                break;
            case BulletType.explosion:
                gunMexican.SetBool("triggerExplosion", true);
                break;
            case BulletType.dodge:
                gunMexican.SetBool("triggerDodge", true);
                break;
            case BulletType.miss:
                gunMexican.SetBool("triggerCilecca", true);
                break;
            case BulletType.noShoot:
                //gunPeruvian.SetBool("triggerFire", true);
                break;
            default:
                break;
        }

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
}