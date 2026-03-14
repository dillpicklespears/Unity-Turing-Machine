using UnityEngine;

public class TuringWriteVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem zeroEffect;
    [SerializeField] private ParticleSystem oneEffect;

    [SerializeField] private int burstCount = 10;

    public void OnWrite(int symbol)
    {
        Debug.Log($"OnWrite called with {symbol}");

        if (symbol == 0 && zeroEffect != null)
        {
            Debug.Log("Triggering zeroEffect");
            zeroEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            zeroEffect.Emit(burstCount);
            zeroEffect.Play();
        }
        else if (symbol == 1 && oneEffect != null)
        {
            Debug.Log("Triggering oneEffect");
            oneEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            oneEffect.Emit(burstCount);
            oneEffect.Play();
        }
        else
        {
            Debug.LogWarning($"No particle system assigned for symbol {symbol}");
        }
    }
}