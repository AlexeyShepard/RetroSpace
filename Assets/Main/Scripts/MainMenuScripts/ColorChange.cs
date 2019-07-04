using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    Image img;
    float speedR, speedG, speedB, speedMultiple = 0.7f;

    void Start()
    {
        img = gameObject.GetComponent<Image>();
        changeMaxValue();
    }

    void Update()
    {
        img.color = new Color(
            Mathf.PingPong(Time.time * speedR, 100) / 100,
            Mathf.PingPong(Time.time * speedG, 100) / 100,
            Mathf.PingPong(Time.time * speedB, 100) / 100);
    }

    void changeMaxValue()
    {
        speedR = Random.Range(20, 50) * speedMultiple;
        speedG = Random.Range(20, 50) * speedMultiple;
        speedB = Random.Range(20, 50) * speedMultiple;
    }
}
