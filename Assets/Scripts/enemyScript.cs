using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Rigidbody2D enemyrigid;
    public int health;
    public GameObject enemyBullet;
    public Transform bulletPos;
    // Start is called before the first frame update
    void Start()
    {
        enemyrigid = GetComponent<Rigidbody2D>();
        health = 5;
        InvokeRepeating("createShooting",3f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        enemyrigid.velocity = new Vector2(0,-0.5f);

        if (health < 1) {
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag == "bullet1") {
            health--;
            Destroy(col.gameObject);
        }
    }
    private void createShooting() {
        Instantiate(enemyBullet,new Vector3(bulletPos.transform.position.x,bulletPos.transform.position.y,0),Quaternion.identity);
    }
}
