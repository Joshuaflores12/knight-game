using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class MovementAnimation : MonoBehaviour
{
    //Speed (how fast the player will navigate on our game)
    public int moveSpeed;
    // Rigid body (handles physics)
    public new Rigidbody2D rigidbody;
    //where the player is moving
    private Vector2 movementInput;
    //Acces to our Animator to Play animations
    public Animator anim;
    public int coinscount;
    public int healthpoints;
    public TextMeshProUGUI hpVal, coinVal;
    // Start is called before the first frame update
    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();
      anim  = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))

        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Forward");
        //}



        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Backward");
        //}




        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Left");
        //}




        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Right");
        //}


        //if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||Input.GetKeyUp(KeyCode.D))
        //{
        //    anim.enabled = false;
        //}
        anim.SetFloat("Horizontal",movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
       hpVal.text = healthpoints.ToString();
        coinVal.text = coinscount.ToString();
        if (healthpoints <= 0) 
        {
            SceneManager.LoadScene("LoseScreen");
        }


    }
    private void FixedUpdate()
    {
        rigidbody.velocity = movementInput * moveSpeed;
    }

    private void LateUpdate()
    {
        
    }
    //To get input system clicks
    private void OnMove(InputValue inputValue)
    {
    movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coins"))
        { 
        coinscount++;
        Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Speed"))
        {
            
            
            Transform col = collision.transform;
            col.transform.position = new Vector2(999, 999);
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            
        }

    }

}
