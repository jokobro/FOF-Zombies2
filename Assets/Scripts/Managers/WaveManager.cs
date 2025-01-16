using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int CurrentWaveIndex { get; private set; } = 0;
    /*public List<Wave> waves;  // Lijst van waves*/
    public static WaveManager Instance;
    private int currentGroupIndex = 0;
    public float spawnInterval = 30f; // Tussen de groepen in seconden
    private bool waveActive = false;
    public float groupCompletionTime = 1f;

}
