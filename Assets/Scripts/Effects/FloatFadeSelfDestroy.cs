using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatFadeSelfDestroy : MonoBehaviour
{
    private TextMeshProUGUI mytext;
    private float moveSpeed = 1.0f;
    private float fadeSpeed = 2.0f;

    private float alpha = 1;

    private void Awake()
    {
        mytext = GetComponent<TextMeshProUGUI>();
    }
    void FixedUpdate()
    {
        alpha = Mathf.Lerp(alpha, 0, fadeSpeed * Time.deltaTime);
        mytext.color = new Color(mytext.color.r, mytext.color.g, mytext.color.b, alpha);
        transform.Translate(new Vector2(0, moveSpeed));

        if (alpha < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
