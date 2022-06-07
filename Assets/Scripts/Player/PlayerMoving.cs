using UnityEngine;

public class PlayerMoving : BaseLogic
{
    [SerializeField] private float JumpForce;
    [SerializeField] private float WallJumpTime;

    private float Moveinput;

    private bool jump;
    private bool djump;
    private bool IsWallJump;
    private bool IsWallAfterJump;
    private bool IsGrounded;
    private bool IsWallL;
    private bool IsWallR;
    private bool falling;

    private Sensor_Prototype Groundsensor;
    private Sensor_Prototype RWallsensor;
    private Sensor_Prototype LWallsensor;

    private Damage dmg;

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Groundsensor = transform.Find("GroundSensor").GetComponent<Sensor_Prototype>();
        RWallsensor = transform.Find("RWallSensor").GetComponent<Sensor_Prototype>();
        LWallsensor = transform.Find("LWallSensor").GetComponent<Sensor_Prototype>();
        dmg = transform.Find("Hitbox").GetComponent<Damage>();
    }

    private void Update()
    {
        GetPlayerInput();
        Flip();
    }

    private void FixedUpdate()
    {
        CheckIsFalling();
        EnvironmentSens();
            Move();
            Jump();
        if (dmg.IsDamageTaken() == 1)
            TakeDamage();
    }

    protected void EnvironmentSens()
    {
        IsGrounded = Groundsensor.State();
        if (!RWallsensor.Ignoring())
            IsWallR = RWallsensor.State();
        if (!LWallsensor.Ignoring())
            IsWallL = LWallsensor.State();
    }

    private void Move()
    {
        if (IsGrounded && ((Moveinput > 0 && IsWallR) || (Moveinput < 0 && IsWallL)))
        {
            animator.SetBool("IsWallJump", false);
            animator.SetBool("IsMoving", false);
            if (!IsWallAfterJump)
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (!IsGrounded && ((Moveinput > 0 && IsWallR) || (Moveinput < 0 && IsWallL)))
        {
            animator.SetBool("IsWallJump", true);
            IsWallJump = true;
            rb.velocity = new Vector2(0, 0.17f);
        }
        else
        {
            animator.SetBool("IsWallJump", false);
            animator.SetBool("IsMoving", Moveinput != 0);
            if (!IsWallAfterJump)
                rb.velocity = new Vector2(Moveinput * Speed, rb.velocity.y);
        }
    }

    protected void GetPlayerInput()
    {
        Moveinput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && (IsGrounded || !djump || IsWallJump))
            jump = true;
    }

    protected void CheckIsFalling()
    {
        if (rb.velocity.y < 0 && !IsGrounded)
            falling = true;
        else if (rb.velocity.y >= 0 || IsGrounded || IsWallL || IsWallR)
            falling = false;
        animator.SetBool("IsFall", falling);
    }

    private void Flip()
    {
        if (Moveinput < 0)
            spriteRenderer.flipX = true;
        else if (Moveinput > 0)
            spriteRenderer.flipX = false;
    }

    private void Jump()
    {
        if (IsGrounded && IsWallJump)
            IsWallJump = false;
        if (IsGrounded && djump)
            djump = false;

        if (!jump)
            return;
        else
        {
            if (!IsGrounded)
                djump = true;
            if (IsWallJump)
            {
                rb.velocity = new Vector2(-Moveinput * JumpForce, JumpForce);
                IsWallAfterJump = true;
                Invoke(nameof(WallJumpTimer), WallJumpTime);
            }
            else
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);

            jump = false;
            IsWallJump = false;
            animator.SetTrigger("Jump");
        }
        animator.SetBool("IsDJump", djump);
    }

    private void WallJumpTimer()
    {
        IsWallAfterJump = false;
    }
}
