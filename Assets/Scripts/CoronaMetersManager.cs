using UnityEngine;
using System.Collections;

public class CoronaMetersManager : MonoBehaviour
{
    public float globalCoronaMeter = 0;
    public float globalCoronaMeterMax = 100;
    public float selfCoronaMeter = 0;
    public float selfCoronaMaterMax = 100;

    // Update is called once per frame
    void Update()
    {
        if (globalCoronaMeter < 0)
            globalCoronaMeter = 0;

        if (selfCoronaMeter < 0)
            selfCoronaMeter = 0;

        globalCoronaMeter += Time.deltaTime;
    }

    public void updateGlobalMeter (float value)
    {
        globalCoronaMeter += value;
    }

    public void updateSelfMeter(float value)
    {
        selfCoronaMeter += value;
    }
}
