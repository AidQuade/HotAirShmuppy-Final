using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerScript : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite oldSprite;

    private float     xPos;
    private float     yPos;
    public float      speed = .05f;
    public float      leftWall, rightWall;
    public float      bottomWall;
    public float topWall;
    public float health = 0.5f;
    private Transform aimTrans;
    private Transform endBarrel;
    public GameObject projectile;
    public KeyCode fireKey;
    private Animator cannonAnim;
    private Animator balloonDef;
    private bool damagedState = false;
    public event EventHandler<onShootArgs> OnShoot;

    public class onShootArgs : EventArgs
    {
        public Vector3 muzzlePos;
        public Vector3 shootPos;
    }

    private void Awake()
    {
        balloonDef = this.GetComponent<Animator>();
        aimTrans = transform.Find("Aim");
        cannonAnim = aimTrans.GetComponent<Animator>();
        endBarrel = aimTrans.Find("endBarrel");
    }
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg; 
        aimTrans.eulerAngles = new Vector3(0,0,angle);
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (xPos > leftWall) {
                xPos -= speed;
                
            }
        }

        if (yPos < bottomWall)
        {
            
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall) {
                xPos += speed;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (yPos > bottomWall)
            {
                balloonDef.SetTrigger("DownPress");
                balloonDef.SetBool("Holding", true);
                transform.localPosition = new Vector3(xPos, transform.position.y - speed*2, 0);
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            balloonDef.SetBool("Holding", false);
        }
        if (Input.GetMouseButtonDown(0))
        
        {
            cannonAnim.SetTrigger("Shoot");
            Instantiate(projectile,  endBarrel.position, Quaternion.Euler(0, 0, angle));
        }

        if (Input.GetKey(KeyCode.X) && damagedState == true)
        {
            spriteRenderer.sprite = oldSprite;
            damagedState = false;

        }

        transform.localPosition = new Vector3(xPos, transform.position.y + speed, 0);
        if (health <= 0)
        {
            damagedState = true;
            spriteRenderer.sprite = newSprite;
           while (damagedState == true)
           { 
               transform.localPosition= new Vector3(xPos, transform.position.y - speed, 0);
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
            health -= .1f;
            
        }
        
    }

}








