using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayUI : MonoBehaviour
{
    public TextMeshProUGUI waveCountDisplay;
    public TextMeshProUGUI nextWaveCountdownDisplay;
    public TextMeshProUGUI scoreDisplay;
    static public int score;
    void Start()
    {
        waveCountDisplay.text = "null";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        waveCountDisplay.text = "Wave " + WaveSpawner.currentWave;
        scoreDisplay.text = "Score: " + score;
        nextWaveCountdownDisplay.text =  "Next wave in: "+ WaveSpawner.WaveCountdown.ToString("F2");

        nextWaveCountdownDisplay.alpha = WaveSpawner.WaveCountdown;
    }
}
