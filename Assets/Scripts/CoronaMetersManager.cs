using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CoronaMetersManager : MonoBehaviour
{
    public GameManager gm;
    public float globalCoronaMeter = 0;
    public float globalCoronaMeterMax = 100;
    public float selfCoronaMeter = 0;
    public float selfCoronaMaterMax = 100;
    public float globalIncrementPerSec;

    public Slider globalMeter;
    public Image globalMeterImg;
    public Slider selfMeter;
    public Image selfMeterImg;
    public Gradient metersGradient;

    // Update is called once per frame
    void Update()
    {
        if (globalCoronaMeter < 0)
            globalCoronaMeter = 0;

        if (selfCoronaMeter < 0)
            selfCoronaMeter = 0;

        globalMeter.value = globalCoronaMeter;
        selfMeter.value = selfCoronaMeter;
        globalMeterImg.color = metersGradient.Evaluate(globalCoronaMeter / 100);
        selfMeterImg.color = metersGradient.Evaluate(selfCoronaMeter / 100);

        globalCoronaMeter += globalIncrementPerSec * Time.deltaTime;
    }

    public void updateGlobalMeter (float value)
    {
        globalCoronaMeter += value;

        if (value < 0)
            gm.UpdateScore(-1 * value);
    }

    public void updateSelfMeter(float value)
    {
        selfCoronaMeter += value;
    }
}
