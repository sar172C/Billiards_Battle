using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarScript : MonoBehaviour
{
    public Slider bar;
    public float increment = 0.0f;
    public float rate = 5.0f;

    private bool pressed;
    private bool increase;
    private bool decrease;
    private int finalVal;

    // Start is called before the first frame update
    void Start()
    {
        bar.value = 0.0f;
        pressed = false;
        increase = true;
        decrease = false;
    }

    
    
    // Update is called once per frame
    public void movement()
    {
        pressed = false;
        
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space pressed");
            pressed = true;
            finalVal = (int)Mathf.Floor(bar.value);
            //bar.value = 0;
            Debug.Log("Final Power Value: " + finalVal);
            
        }
        if(!pressed && increase){
            //Debug.Log("Increase Before: "+bar.value);
            bar.value+=Time.deltaTime * rate; 
            //Debug.Log("Increase After: "+bar.value);
            if(bar.value>=10){
                increase = false;
                decrease = true;
            //   Debug.Log("Increase-->Decrease");
            }
        }
        else if(!pressed && decrease)
        {
            //Debug.Log("Decrease Before: "+bar.value);
            bar.value-=Time.deltaTime * rate;
            //Debug.Log("Decrease After: "+bar.value);
            if(bar.value<=0){
                increase = true;
                decrease = false;
            //    Debug.Log("Decrease-->Increase");
            }
        }
    }
}