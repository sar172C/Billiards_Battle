using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerMeter : MonoBehaviour
{

    public Image myImage;
    public float speed = 2.0f;
    public float waitTime = 5.0f;
    public bool repeat;

    IEnumerator Start()
    {
        while (repeat)
        {
            yield return ChangeFill(0f, 1f, waitTime);
            yield return ChangeFill(1f, 0f, waitTime);
        }
    }

    public IEnumerator ChangeFill(float start, float end, float time)
    {
        float i = 0f;
        float rate = (1f / time) * speed;
        
        while (i < 1f)
        {
            i += Time.deltaTime * rate;
             myImage.fillAmount = Mathf.Lerp(start, end, i);
            yield return null;
        }
    }
}
