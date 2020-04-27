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

    private GameObject playerObject;

    private PlayableCharacter playerScript;

    public AudioClip[] enemySoundEffects;
    public AudioClip[] friendlySoundEffects;
    private AudioSource audio;

    void Start()
    {
        playerSpriteRenderer.sprite = sprites[0];
        firePtRenderer.sprite = null;
        playerObject = GameObject.Find("Player");
        playerScript = playerObject.GetComponent<PlayableCharacter>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playerScript.paused)
        {
            StartCoroutine(delayResetSprite());

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * 10);
            hitObj = hit.transform.gameObject;
            Distance = Mathf.Abs(hit.point.y - transform.position.y);
            Vector3 mouseVector = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            Debug.DrawLine(transform.position, mouseVector * 10, Color.green);

            if (hitObj.tag == "Friendly" && Vector3.Distance(hit.transform.position, transform.position) < 2) {
                playerSpriteRenderer.sprite = sprites[0];
                firePtRenderer.sprite = null;
                Debug.Log("Student was sent home");
                hitObj.GetComponent<FriendlyController>().saveFriendly();
                int randomIndex = Random.Range(0,friendlySoundEffects.Length);
                audio.clip = friendlySoundEffects[randomIndex];
                audio.Play();
            } else if (hitObj.tag == "Enemy" && Vector3.Distance(hit.transform.position, transform.position) < 4) {
                playerSpriteRenderer.sprite = sprites[1];
                firePtRenderer.sprite = sprites[2];
                Debug.Log("Covid-19 was killed");
                Destroy(hitObj);
                int randomIndex = Random.Range(0,enemySoundEffects.Length);
                audio.clip = enemySoundEffects[randomIndex];
                audio.Play();
            } else if (hitObj.tag == "Boss") {
                playerSpriteRenderer.sprite = sprites[1];
                firePtRenderer.sprite = sprites[2];
                /* this is how we should deal with enemies and entities getting hit.
                Enemies and NPCs should have a script that has a function that 
                says how to react to a hit and then here all we do is call that function */
                hitObj.GetComponent<BossController>().takeDamage(10); 
                int randomIndex = Random.Range(0,enemySoundEffects.Length);
                audio.clip = enemySoundEffects[randomIndex];
                audio.Play();
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
