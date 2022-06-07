using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float vertinput;
    private bool isplayer;
    Collider2D coll1;
    Collider2D coll2;

    private void Start()
    {
        coll1 = GetComponent<Collider2D>();
        coll2 = GameObject.Find("Player(Clone)").GetComponent<Collider2D>();
    }

    private void Update()
    {
        vertinput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (isplayer && vertinput < 0)
            Jumpoff();
    }

    private void Jumpoff()
    {
        Physics2D.IgnoreCollision(coll1, coll2, true);
        StartCoroutine(DisableJumpoff());
    }
   
    private IEnumerator DisableJumpoff()
    {
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(coll1, coll2, false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            isplayer = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            isplayer = false;
    }
}
