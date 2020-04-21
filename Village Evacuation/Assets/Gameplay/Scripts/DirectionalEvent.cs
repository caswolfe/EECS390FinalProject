using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalEvent : MonoBehaviour
{
    private GameObject hitObj;
    private float Distance  = 0f;

    // Sprite mapping: { 0 : normal, 1 : attacking, 2 : attack sprite (projectile substitute) } 
    public Sprite[] sprites;

    public SpriteRenderer playerSpriteRenderer;

    public SpriteRenderer firePtRenderer;


    void Start()
    {
        playerSpriteRenderer.sprite = sprites[0];
        firePtRenderer.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerSpriteRenderer.sprite = sprites[1];
            firePtRenderer.sprite = sprites[2];
            StartCoroutine(delayResetSprite());

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * 10);
            hitObj = hit.transform.gameObject;
            Distance = Mathf.Abs(hit.point.y - transform.position.y);
            Vector3 mouseVector = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            Debug.DrawLine(transform.position, mouseVector * 10, Color.green);

            if (hitObj.tag == "Friendly") {
                playerSpriteRenderer.sprite = sprites[0];
                firePtRenderer.sprite = null;
                Debug.Log("Student was sent home");
                hitObj.GetComponent<FriendlyController>().saveFriendly();
            } else if (hitObj.tag == "Enemy") {
                Debug.Log("Covid-19 was killed");
                Destroy(hitObj);
            } else if (hitObj.tag == "Boss") {
                /* this is how we should deal with enemies and entities getting hit.
                Enemies and NPCs should have a script that has a function that 
                says how to react to a hit and then here all we do is call that function */
                hitObj.GetComponent<BossController>().takeDamage(10); 
            }
        }
    }

    // Reset the sprite after a delay of 1 second
    IEnumerator delayResetSprite()
    {
        yield return new WaitForSeconds(0.7f);
        playerSpriteRenderer.sprite = sprites[0];
        firePtRenderer.sprite = null;
    }
}
