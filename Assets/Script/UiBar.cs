using UnityEngine;
using UnityEngine.UI;

public class UiBar : MonoBehaviour
{
    public Image cooldDown;
    public bool coolingDown;
    public float waitTime = 30.0f;
    private GameController gcLinker;
    private AnimationHandler ahLinker;
    // Use this for initialization
    private void Start()
    {
        gcLinker = FindObjectOfType<GameController>();
        ahLinker = FindObjectOfType<AnimationHandler>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gcLinker.GamePhase == GameState.ShootPhase || gcLinker.GamePhase == GameState. UpdateStatus)
        {
            if (coolingDown == true)
            {
                cooldDown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
                if (cooldDown.fillAmount == 0f)
                {                    
                    coolingDown = false;
                    gcLinker.GamePhase = GameState.AnimationPhase;
                    ahLinker.AnimationUpdate();

                    /*
                    foreach (var player in FindObjectsOfType<PlayerControls>())
                    {
                        player.state = PlayerState.InitPlayer;
                        player.startButton.gameObject.SetActive(true);
                        // Fai animazioni qui
                    }*/
                    coolingDown = true;

                }
            }
        }
        else if (gcLinker.GamePhase == GameState.InitPhase)
        {
            cooldDown.fillAmount = 1;
        }
    }
}