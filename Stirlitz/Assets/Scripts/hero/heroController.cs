using UnityEngine;
using System.Collections;

public class heroController : MonoBehaviour
{
    public float moveSpeed = 10f, jumpForce;
    public static int score;
    public static bool isFasingRight = true;
    public static bool lie;
    public static bool grounded, die;
    public LayerMask whatIsGround, whatIsWater, whatIsLift, whatIsUnderPlat;
    public Transform groundCheck;
    public Animator bazookAnim;
    public Rigidbody2D liftRigid;
    Animator animate;
    public static string Gun = "pistols";
    Rigidbody2D rigidbod;
    float move, jump_height, ground_height, coordinate = 0.37f, flip_cord = 0.7f, time, ground_fix = 0.2f, fallTime, whatGunX, groundCheckX;
    BoxCollider2D boxCollider2D;
    public static int health = 100;
    bool isJump, upDown = true, jump_die, watered, isLift, isUnderPlat;
    public GUIText heal;
    public int documents;

    void Start()
    {
        animate = GetComponent<Animator>();
        rigidbod = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        heal.text = "" + health;
        docsCollect.howMuch = documents;
    }

    void chose()
    {
        switch (Gun)
        {
            case "pistols":
                whatGunX = -0.075f;
                groundCheckX = 0;
                break;
            case "bazooka":
                whatGunX = -0.005f;
                groundCheckX = 0.35f;
                break;
        }
    }

    void replacePosition(float sizeY, float offsetX, float offsetY, float positionY, float groundPosX, float groundPosY, string setBool_1)
    {
        animate.SetBool(setBool_1, false);
        boxCollider2D.size = new Vector2(0.06f, sizeY);
        boxCollider2D.offset = new Vector2(offsetX, offsetY);
        transform.position = new Vector3(transform.position.x, transform.position.y + positionY, -2f);
        groundCheck.position = new Vector2(transform.position.x + groundPosX, transform.position.y + groundPosY);
    }

    void Animation()
    {
        chose();
        if (boxCollider2D.isTrigger)
            fallTime += Time.deltaTime;
        if (fallTime >= 0.3f)
        {
            boxCollider2D.isTrigger = false;
            fallTime = 0;
        }
        if (grounded && rigidbod.velocity.y <= 0.1f || isLift && rigidbod.velocity.y >= 1.49f)
        {
            animate.SetBool("jump", false);
            ground_height = transform.position.y;
            if (Input.GetKeyDown(KeyCode.DownArrow) && !lie && rigidbod.velocity.y <= 0.1f)
            {                        // lie on the ground
                if (animate.GetBool("shout") || animate.GetBool("shout_up") || animate.GetBool("bazookaFire"))
                {
                }
                else
                {
                    lie = true;
                    animate.SetFloat("jump_height", 0);
                    replacePosition(0.1f, 0, -0.04f, -0.35f, 0, -0.495f, "go");  
                    animate.SetBool("lie", lie);
                }
            }
            else if (lie && Input.GetKeyDown(KeyCode.UpArrow) && !isUnderPlat)
            {                      // up from the lie   
                lie = false;
                replacePosition(0.33f, whatGunX, 0, 0.32f, -coordinate - groundCheckX, -0.76f, "lie");
                animate.SetBool("lie_go", false);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && !isUnderPlat)
            {                               //  jump
                if (animate.GetBool("shout") || animate.GetBool("shout_up") || animate.GetBool("bazookaFire"))
                {
                }
                else
                {
                    rigidbod.AddForce(new Vector2(0f, jumpForce));
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) && !lie || Input.GetKey(KeyCode.LeftArrow) && !lie)
            {
                if (animate.GetBool("shout") || animate.GetBool("shout_up") || animate.GetBool("bazookaFire"))
                {
                }
                else
                {
                    animate.SetFloat("jump_height", jump_height);								// go animation
                    animate.SetBool("shout", false);
                    animate.SetBool("shout_up", false);
                    animate.SetBool("go", true);
                }
            }
            else if (lie && Input.GetKeyDown(KeyCode.F) && !isUnderPlat)
            {                      //  shout from the lie
                lie = false;
                replacePosition(0.33f, whatGunX, 0, 0.32f, -coordinate, -0.76f, "lie");
            }
            else if (Input.GetKey(KeyCode.F) && !lie)
            {                                        // shout animation
                animate.SetBool("go", false);
                if (Gun == "bazooka" && !bazookAnim.GetBool("fire") && !bazookAnim.GetBool("exploi"))
                    animate.SetBool("bazookaFire", true);
                else if (Gun != "bazooka")
                {
                    if (upDown)
                        animate.SetBool("shout", true);
                    else
                        animate.SetBool("shout_up", true);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) && lie && Input.GetKey(KeyCode.F) && !isUnderPlat || Input.GetKey(KeyCode.LeftArrow) && lie && Input.GetKey(KeyCode.F) && !isUnderPlat)
            { // shout from the lie_go
                lie = false;
                replacePosition(0.33f, whatGunX, 0, 0.32f, -coordinate, -0.76f, "lie");
            }
            else if (Input.GetKey(KeyCode.RightArrow) && lie || Input.GetKey(KeyCode.LeftArrow) && lie)
            {     // lie_go animation
                animate.SetBool("lie_go", true);
            }
            else if (lie)
            {                                                               // end of lie_go
                animate.SetBool("lie_go", false);
            }
            else
            {                                                                       // end of all animation
                animate.SetBool("go", false);
                animate.SetBool("jump", false);
                animate.SetFloat("jump_height", jump_height);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.F))
            {
                animate.SetBool("jump", false);
                if (upDown)
                    animate.SetBool("shout", true);
                else
                    animate.SetBool("shout_up", true);
            }
            else
            {
                animate.SetBool("jump", true);
                animate.SetBool("lie_go", false);
                if (lie && transform.position.y - ground_height < 0)   // lie && ...
                {
                    boxCollider2D.isTrigger = true;
                    lie = false;
                    replacePosition(0.33f, whatGunX, 0, 0.22f, -coordinate, -0.76f, "lie");
                    animate.SetFloat("jump_height", 1.9f);
                }
                if (transform.position.y < ground_height && !lie)
                {
                    animate.SetFloat("jump_height", 1.9f);
                    animate.SetBool("go", false);
                    animate.SetBool("shout", false);
                    animate.SetBool("shout_up", false);
                }
                else
                {
                    if (rigidbod.velocity.y < 0)
                        jump_height = 1.9f;
                    animate.SetFloat("jump_height", jump_height);
                    animate.SetBool("go", false);
                    animate.SetBool("shout", false);
                    animate.SetBool("shout_up", false);
                }
            }
        }
    }

    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        grounded = Physics2D.OverlapCircle(groundCheck.position, ground_fix, whatIsGround);
        watered = Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsWater);
        jump_height = transform.position.y - ground_height;
        isLift = Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsLift);
        isUnderPlat = Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsUnderPlat);
    }

    void Update()
    {
        dieCheck();
        if (!die)
        {
            rigidbod.velocity = new Vector2(moveSpeed * move, rigidbod.velocity.y);
            if (move > 0 && !isFasingRight)
                Flip();
            else if (move < 0 && isFasingRight)
                Flip();
            Animation();
            Oxygen();
        }
        else if (!grounded)
        {
            animate.SetBool("jump_die", true);
            jump_die = true;
        }
        else if (jump_die)
        {
            animate.SetBool("jump_die", false);
        }
        else if (grounded)
        {
            animate.SetFloat("jump_height", 0);
        }
    }

    void Flip()
    {
        isFasingRight = !isFasingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        coordinate *= -1;
        flip_cord *= -1;
        transform.position = new Vector3(transform.position.x + flip_cord, transform.position.y, -2f);
        transform.localScale = Scale;
    }

    void Oxygen()
    {
        if (watered)
        {
            time += Time.deltaTime;
            if (time >= 0.5f)
            {
                if (health <= 1)
                    health = 0;
                else
                    health--;
                time = 0;
            }
        }
        else
            time = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "heal")
        {
            if (health >= 70)
                health = 100;
            else
                health += 30;
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "bazooka")
        {
            animate.SetBool("isBaz", true);
            Gun = "bazooka";
            if (lie)
            {
                lie = false;
                replacePosition(0.33f, whatGunX, 0, 0.32f, -coordinate - groundCheckX, -0.76f, "lie");
                animate.SetBool("lie_go", false);
            }
            else
            {
                boxCollider2D.offset = new Vector2(-0.005f, boxCollider2D.offset.y);
                groundCheck.position = new Vector2(groundCheck.position.x + 0.35f, groundCheck.position.y);
                Destroy(col.gameObject);
            }
        }
        if (col.name == "fireMet")
        {
            animate.SetBool("isFireGun", true);
        }
    }

    void dieCheck()
    {
        if (!die)
        {
            heal.text = "" + health;
            if (health == 0)
            {
                die = true;
                heal.text = "" + health;
                rigidbod.velocity = Vector2.zero;
                boxCollider2D.size = new Vector2(0.06f, 0.3f);
                if (lie)
                {
                    lie = false;
                    replacePosition(0.3f, whatGunX, 0, 0.32f, -coordinate, -0.7f, "lie");
                }
                animate.SetBool("die", true);
            }
        }
    }

    void ender()
    {
        replacePosition(0.1f, -0.1f, 0, -0.55f, 0, -0.3f, "die");
        boxCollider2D.size = new Vector2(0.29f, boxCollider2D.size.y);
    }

    void shoutAnim()
    {
        if (upDown)
            animate.SetBool("shout", false);
        else
            animate.SetBool("shout_up", false);
        upDown = !upDown;
    }

    void bazookaShout()
    {
        animate.SetBool("bazookaFire", false);
    }
}