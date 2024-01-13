using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{

    public TMP_Text text;

    public int startTime = 0;
    public int endTime = 6;

    public float levelDuration = 5.0f;

    public float timeMultiplier = 5;

    [SerializeField]
    float actualTime = 0.0f;

    [SerializeField]
    float gameTime = 0.0f;

    public int minTransition = 4;
    public int maxTransition = 8;

    [SerializeField]
    float[] transitionTimes;

    int transitions = 0;
    private int currentTransition = 0;

    // Start is called before the first frame update
    void Start()
    {
        transitions =  (int)Random.Range(minTransition, maxTransition);
        transitionTimes = new float[transitions];

        float delta = (endTime - startTime) / (transitions + 1.0f);
        for(int i = 0; i < transitions; i++)
        {
            transitionTimes[i] = delta * (i + 1) + Random.Range(-0.375f * delta, 0.375f * delta);
        }
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime * timeMultiplier;

        gameTime = (actualTime / (levelDuration  * 60.0f)) * (endTime - startTime);

        int truncatedTimeValue = (int)gameTime;

        if(truncatedTimeValue == 0)
            text.text = "12:00 AM";
        else
        {
            text.text = "0" + truncatedTimeValue.ToString() + ":00 AM";
        }

        if(currentTransition < transitionTimes.Length && gameTime >= transitionTimes[currentTransition])
        {
            currentTransition++;
            AIManager.Instance.TransitionOccured();
        }
    }
}
