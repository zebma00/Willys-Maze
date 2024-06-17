using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public event Action<Button> ButtonPressed;

    private Image image;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public AudioSource audioSource;

    public float buttonSpeed = 0.1f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    Coroutine coroutine;
    public void Activate()
    {
        if (isAnimating) return;

        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(ChangeKeySprite());

        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.Play();
        Invoke("AudioStop", 0.25f);

        if (ButtonPressed != null) ButtonPressed(this);
    }

    private void AudioStop()
    {
        audioSource.Stop();
    }

    bool isAnimating = false;

    /*
    private IEnumerator ChangeObjColor(Material material)
    {
        isAnimating = true;
        LeanTween.cancel(gameObject);
        // Tween our color change
        LeanTween.moveLocalZ(gameObject, 0.2f, buttonSpeed);

        yield return new WaitForSeconds(buttonSpeed);
        // Tween our color change
        LeanTween.moveLocalZ(gameObject, 0, buttonSpeed);

        isAnimating = false;
    }
    */

    private IEnumerator ChangeKeySprite()
    {
        isAnimating = true;
        // Change image sprite to pressed
        image.sprite = pressedImage;

        yield return new WaitForSeconds(buttonSpeed);
        // Change image sprite to default
        image.sprite = defaultImage;

        isAnimating = false;
    }
}
