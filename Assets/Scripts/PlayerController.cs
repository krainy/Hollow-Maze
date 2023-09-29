using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;
    [SerializeField] PlayerPowerupController playerPowerup;
    [SerializeField] GameObject checkGround;
    [SerializeField] LayerMask layerGround;
    [SerializeField] bool inGround;
    public bool InGround
    {
        get { return inGround; }
    }
    [SerializeField] Animator playerAnim;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] bool gambiarra = true;
    [SerializeField]
    public bool CanJump
    {
        set { gambiarra = value; }
    }
    [SerializeField] bool ableToRotate = false;
    public bool AbleToRotate
    {
        get { return ableToRotate; }
        set { ableToRotate = value; }
    }

    [SerializeField] bool jumped = false;
    public bool Jumped
    {
        get { return jumped; }
    }
    [SerializeField] bool canFall = true;
    public bool CanFall
    {
        set { canFall = value; }
    }
    [SerializeField] float jumpForce = 1f;

    void AfterJump()
    {

        if (!gambiarra && playerRB.velocity.y < 0 && playerRB.gravityScale != 0)
        {
            //anim
            playerRB.gravityScale = 0;
            Debug.Log("Gravidade zerada");
            playerRB.constraints = RigidbodyConstraints2D.FreezePosition;
            Debug.Log("Velocidade zerada");
        }
        else
        {
            AfterJump();
        }
    }

    IEnumerator Falling()
    {
        anim.SetBool("isJumping", false);
        playerRB.gravityScale = 1;
        canFall = false;
        jumped = false;
        //anim

        playerRB.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        yield return null;
    }

    void Start()
    {

    }

    void Update()
    {
        switch (playerPowerup.Element)
        {
            case 0:
                anim.SetBool("onFire", false);
                anim.SetBool("onWind", false);
                anim.SetBool("onWater", false);
                anim.SetBool("onEarth", false);
                break;
            case 1:
                anim.SetBool("onFire", true);
                anim.SetBool("onWind", false);
                anim.SetBool("onWater", false);
                anim.SetBool("onEarth", false);
                break;
            case 2:
                anim.SetBool("onFire", false);
                anim.SetBool("onWind", true);
                anim.SetBool("onWater", false);
                anim.SetBool("onEarth", false);
                break;
            case 3:
                anim.SetBool("onFire", false);
                anim.SetBool("onWind", false);
                anim.SetBool("onWater", true);
                anim.SetBool("onEarth", false);
                break;
            case 4:
                anim.SetBool("onFire", false);
                anim.SetBool("onWind", false);
                anim.SetBool("onWater", false);
                anim.SetBool("onEarth", true);
                break;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gambiarra && !jumped && inGround)
        {
            anim.SetBool("isJumping", true);
            gambiarra = false;
            Jump();

            Debug.Log("Pulando");
        }

        if (jumped && playerRB.velocity.y < 0 && playerRB.gravityScale != 0)
        {
            //anim
            playerRB.gravityScale = 0;
            Debug.Log("Gravidade zerada");
            playerRB.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            Debug.Log("Velocidade zerada");
            playerRB.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            ableToRotate = true;
            Debug.Log("Liberado para rodar!");
        }

        if (canFall)
        {
            StartCoroutine(Falling());
        }

        toCheckGround();

    }

    void Jump()
    {

        playerRB.AddForce(transform.up * jumpForce);
        jumped = true;

    }

    void toCheckGround()
    {
        if (Physics2D.OverlapCircle(checkGround.transform.position, 0.1f, layerGround))
        {
            //anim.SetBool("isJumping", false);
            inGround = true;
        }
        else
        {
            //anim.SetBool("isJumping", true);
            inGround = false;
        }
    }
}
