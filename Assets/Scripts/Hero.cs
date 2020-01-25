using UnityEngine;

public class Hero : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public StateEnum state;
    public IState current;

    #region State

    public void SetState(StateEnum s, string input = null)
    {
        switch (s)
        {
            case StateEnum.IDLE:
                current = gameObject.GetComponent<Idle>();
                current.UpdateState(this, spriteRenderer, animator, input);
                break;

            case StateEnum.RUNNING:
                current = gameObject.GetComponent<Running>();
                current.UpdateState(this, spriteRenderer, animator, input);
                break;

            case StateEnum.JUMPING:
                current = gameObject.GetComponent<Jumping>();
                current.UpdateState(this, spriteRenderer, animator, input);
                break;

            case StateEnum.ATTACKING:
                current = gameObject.GetComponent<Attacking>();
                current.UpdateState(this, spriteRenderer, animator, input);
                break;
        }
    }

    public void TryGetTransition()
    {
        // Store this long list of cases where state should change to IDLE
        bool returnToIdle = Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.D)
            || Input.GetKeyUp(KeyCode.LeftArrow)
            || Input.GetKeyUp(KeyCode.A);

        // Run left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            SetState(StateEnum.RUNNING, "Left");
        }
        // Run right
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            SetState(StateEnum.RUNNING, "Right");
        }
        // Jump
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            SetState(StateEnum.JUMPING);
        }
        //Attack
        else if (Input.GetMouseButtonDown(0))
        {
            SetState(StateEnum.ATTACKING);
        }
        // Idle
        else if (returnToIdle)
        {
            SetState(StateEnum.IDLE);
        }
    }

    #endregion

    #region Methods



    #endregion

    #region Game Loop

    // Start is called before the first frame update
    void Start()
    {
        current = gameObject.GetComponent<Idle>();
        current.Enter(this, spriteRenderer, animator);
    }

    // Update is called once per frame
    void Update()
    {
        TryGetTransition();
    }

    #endregion
}
