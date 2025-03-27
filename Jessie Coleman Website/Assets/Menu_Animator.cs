using UnityEngine;
using System.Collections;

public class Menu_Animator : MonoBehaviour
{
    [SerializeField] private float openDuration = 0.5f;  // How long the open animation should take
    [SerializeField] private AnimationCurve animationCurve;
    // Optional: assign a curve in the Inspector, 
    // for example, a smooth in-out curve

    private Vector3 targetScale;

    private void Awake()
    {
        // Record the "fully open" scale as your starting scale
        targetScale = transform.localScale;
    }

    public void PlayOpenAnimation()
    {
        // Start from a closed/zero scale
        transform.localScale = Vector3.zero;
        // Begin the opening animation
        StartCoroutine(OpenAnimationCoroutine());
    }

    private IEnumerator OpenAnimationCoroutine()
    {
        float timeElapsed = 0f;

        while (timeElapsed < openDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / openDuration;

            // If you’ve assigned a curve in the inspector, 
            // use curve.Evaluate(t) to control easing
            float curveValue = animationCurve != null ? animationCurve.Evaluate(t) : t;

            // Lerp from scale zero to targetScale
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, curveValue);

            yield return null;
        }

        // Ensure final scale is set
        transform.localScale = targetScale;
    }
}
