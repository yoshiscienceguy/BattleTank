using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnOutLight : MonoBehaviour
{
    public float timeOut = 5;
    public float fadeSpeed = 5;
    private float currentTime;
    private Light plight;
    // Start is called before the first frame update
    void Start()
    {
        plight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < timeOut)
        {
            currentTime += Time.deltaTime;
        }
        else {
            plight.intensity = Mathf.Lerp(plight.intensity, 0, fadeSpeed * Time.deltaTime);
            
        }
    }
}
