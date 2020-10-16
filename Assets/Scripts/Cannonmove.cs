using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonmove : MonoBehaviour
{
    private Transform endBarrel;
    private Transform aimTrans;
    public Transform basket;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        aimTrans = this.transform;
        endBarrel = aimTrans.Find("endBarrel");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg; 
        aimTrans.eulerAngles = new Vector3(0,0,angle);
        this.transform.position = basket.transform.position;
        if (Input.GetMouseButtonDown(0))
        
        {
            //Instantiate(projectile,  endBarrel.position, Quaternion.Euler(0, 0, angle));
        }
    }
}
