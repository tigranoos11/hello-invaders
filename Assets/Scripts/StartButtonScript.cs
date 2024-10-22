using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class StartButtonScript : MonoBehaviour
{
    public List<Sprite> buttonSprites;  // List to hold button sprites (assign them in the Inspector)
    public float animationSpeed = 0.5f;  // Time between sprite changes
    public string sceneName;  // Name of the scene to load

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component
        timer = animationSpeed;

        // Add the button listener for scene loading
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }

    void Update()
    {
        // Animate the button by cycling through the sprites
        AnimateButton();
    }

    void AnimateButton()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // Update the sprite
            currentSpriteIndex = (currentSpriteIndex + 1) % buttonSprites.Count;
            spriteRenderer.sprite = buttonSprites[currentSpriteIndex];

            // Reset the timer
            timer = animationSpeed;
        }
    }

    void OnButtonClick()
    {
        // Load the next scene when the button is clicked
        SceneManager.LoadScene(1);
    }
}