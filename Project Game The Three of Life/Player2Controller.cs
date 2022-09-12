using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public static Player2Controller instance;
    public string areaTransitionName;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public Animator myAnim;

    public Transform theGun;
    public GameObject crosshair;

    private Camera theCam;

    public GameObject bulletToFire;
    public Transform firePoint;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public bool canMove;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theCam = Camera.main;
        if (canMove)
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        }else
        {
            theRB.velocity = Vector2.zero;
        }
        myAnim.SetFloat("moveX", theRB.velocity.x);
        

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            if (canMove)
            {
                myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            }
            
        }

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);

        if(mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            theGun.localScale = new Vector3(-1f, -1f, 1f);
            
        }
        else
        {
            transform.localScale = Vector3.one;
            theGun.localScale = Vector3.one;
        }

        //rotate pistol
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        theGun.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            if(GameMenu.instance == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                AudioMap.instance.Playsfx(0);
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            }
            
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), (Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y)), transform.position.z);

    }

    public void setBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(.5f,.5f,0f);
        topRightLimit = topRight + new Vector3(-.5f, -.5f, 0f);
    }

}
