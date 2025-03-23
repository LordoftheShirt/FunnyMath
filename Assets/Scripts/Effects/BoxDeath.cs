using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxDeath : MonoBehaviour
{
    private Image background;
    private float alpha = 1;
    private float fadeSpeed = 2f;

    private void Awake()
    {
        background = gameObject.transform.GetChild(0).GetComponent<Image>();

        // Disables stroke.
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        // disables text
        gameObject.transform.GetChild(3).gameObject.SetActive(false);

    }

    void FixedUpdate()
    {
        alpha = Mathf.Lerp(alpha, 0, fadeSpeed * Time.deltaTime);
        background.color = new Color(background.color.r, background.color.g, background.color.b, alpha);

        if (alpha < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
