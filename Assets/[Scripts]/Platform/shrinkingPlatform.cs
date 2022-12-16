using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 
 Source file Name - shrinkingPlatform.cs
 Name - Vitaliy Karabanov
 ID - 101312885
 Date last Modified - 12/16/2022 
 Program description: Script for shrinking platform, when we start triggering we want to start shrink the platform, and when we exit trigger we want to grow it back;

 */
public class shrinkingPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SoundManager soundManager;
    public bool startShrink = false;
    public float shrinkTime;
    float shrinkValue;
    private void Start()
    {
        boxCollider= GetComponent<BoxCollider2D>();
        soundManager = FindObjectOfType<SoundManager>();
        shrinkValue = Mathf.Clamp(transform.localScale.x, 0.05f, 1);
    }
    private void FixedUpdate()
    {
        if(transform.localScale.x <= 0.05f)
        {
            boxCollider.enabled = false;
        }
        else if(transform.localScale.x >= 0.5f)
        {
            boxCollider.enabled = true;
        }
    }

    private IEnumerator Shrink()
    {
        yield return new WaitForSeconds((shrinkTime * 2) * Time.deltaTime);
        if (startShrink && transform.localScale.x > 0.05f)
        {
            transform.localScale -= (Vector3)(new Vector2(shrinkValue, shrinkValue) * Time.deltaTime);
            StartCoroutine(Shrink());
        }
    }
    private IEnumerator Grow()
    {
        yield return new WaitForSeconds((shrinkTime * 2) * Time.deltaTime);
        if (!startShrink && transform.localScale.x < 1.0f)
        {
            transform.localScale += (Vector3)(new Vector2(shrinkValue, shrinkValue) * Time.deltaTime);
            StartCoroutine(Grow());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !startShrink)
        {
            startShrink = true;
            soundManager.PlaySoundFX(Sound.SHRINK,Channel.PLAYER_SOUND_FX);
            StartCoroutine(Shrink());
            StopCoroutine(Grow());
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            startShrink = false;
            soundManager.PlaySoundFX(Sound.GROW, Channel.PLAYER_SOUND_FX);
            StartCoroutine(Grow());
            StopCoroutine(Shrink());
        }
    }

   

}
