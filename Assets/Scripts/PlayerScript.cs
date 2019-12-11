using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject[] enemys;
    public Rigidbody2D rigid;
    public GameObject bullet1;
    public Transform LeftPos, RightPos;
    public int playerLife;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createEnemy",1f,3f);
        rigid = GetComponent<Rigidbody2D>();
        playerLife = 5;
    }

    // Update is called once per frame
    void Update()
    {

        float H = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(H*2, 0);

        if (Input.GetMouseButtonDown(0)) {
            shooting();
        }

        rigid.position = new Vector2(Mathf.Clamp(rigid.position.x, -1.3f, 1.3f), -2.78f);
        if (playerLife < 1)
        {
            Destroy(gameObject);

        }
    }

    private void createEnemy() {

        float randomX = Random.Range(-1.22f, 1.23f);
        int randomIndex = Random.Range(0, 3);
        Instantiate(enemys[randomIndex], new Vector3(randomX, 6.28f,0), Quaternion.identity);
    }
    private void shooting() {
        Instantiate(bullet1, new Vector3(LeftPos.transform.position.x, LeftPos.transform.position.y, 0), Quaternion.identity);
        Instantiate(bullet1, new Vector3(RightPos.transform.position.x, RightPos.transform.position.y, 0), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "enemyBullet")
        {
            playerLife--;
            Destroy(col.gameObject);
        }
    }

}
