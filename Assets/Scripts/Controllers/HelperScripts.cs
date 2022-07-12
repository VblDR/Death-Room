using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScripts : MonoBehaviour
{
    public delegate void AwaitableCallback();

    public static IEnumerator WaitFor(float seconds, AwaitableCallback callback)
    {
        yield return new WaitForSeconds(seconds);
        callback();
    }
}

public interface IDamageable
{
    public void TakeDamage();
}