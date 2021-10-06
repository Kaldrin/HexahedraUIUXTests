using System.Collections;
using System.Collections.Generic;
using UnityEngine;






// Bastien BERNAND
// Reusable asset

/// <summary>
/// Script that makes a canvas group alpha flicker like a flickering light via a coroutine and a queue.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on Unity 2020.1.15f1
[RequireComponent(typeof(CanvasGroup))]
public class FlickerLightUIR : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroupToFlicker = null;
    [SerializeField] Vector2 flickerRange = new Vector2(0, 1);
    [SerializeField] Vector2 flickerDuractionRange = new Vector2(0.1f, 0.5f);
    [SerializeField] float pauseProbability = 0.2f;

    Queue<Flicker> _flickersQueue = new Queue<Flicker>();
    public struct Flicker
    {
        public float duration;
        public float objective;
    }
    bool flickering = false;







    void Start()                                                                                                                            // START
    {
        GetMissingComponents();
        StartCoroutine(DoFlicker());
    }

    private void OnEnable()                                                                                                                 // ON ENABLE
    {
        GetMissingComponents();
        StartCoroutine(DoFlicker());
    }


    public void AddRandomFlicker()                                                                                                         // ADD RANDOM FLICKER
    {
        bool pause = false;
        if (Random.Range(0f, 1f) < pauseProbability)
            pause = true;

        if (pause)
        {
            float newDuration = 0.05f;
            float newObjective = 0;
            Flicker newFlicker = new Flicker { duration = newDuration, objective = newObjective };
            _flickersQueue.Enqueue(newFlicker);

            newDuration = flickerDuractionRange.y;
            newObjective = 0;
            newFlicker = new Flicker { duration = newDuration, objective = newObjective };
            _flickersQueue.Enqueue(newFlicker);
        }
        else
        {
            float newDuration = Random.Range(flickerDuractionRange.x, flickerDuractionRange.y);
            float newObjective = Random.Range(flickerRange.x, flickerRange.y);
            Flicker newFlicker = new Flicker { duration = newDuration, objective = newObjective };
            _flickersQueue.Enqueue(newFlicker);
        }
    }


    IEnumerator DoFlicker()                                                                                                                 // DO FLICKER
    {
        if (flickering)
        {
            yield return null;
            AddRandomFlicker();
        }
        else
        {
            flickering = true;
            if (_flickersQueue.Count == 0)
                AddRandomFlicker();
            Flicker currentFlicker = _flickersQueue.Dequeue();


            float time = 0;


            if (currentFlicker.objective > canvasGroupToFlicker.alpha)
                while (canvasGroupToFlicker.alpha < currentFlicker.objective)
                {
                    time += Time.fixedDeltaTime;
                    float lerpAlpha = time / currentFlicker.duration;
                    canvasGroupToFlicker.alpha = Mathf.Lerp(canvasGroupToFlicker.alpha, currentFlicker.objective, lerpAlpha);
                    yield return null;
                }
            else
                while (canvasGroupToFlicker.alpha > currentFlicker.objective)
                {
                    time += Time.fixedDeltaTime;
                    float lerpAlpha = time / currentFlicker.duration;
                    canvasGroupToFlicker.alpha = Mathf.Lerp(canvasGroupToFlicker.alpha, currentFlicker.objective, lerpAlpha);
                    yield return null;
                }
            flickering = false;
            StartCoroutine(DoFlicker());
        }
    }







    // EDITOR
    void GetMissingComponents()                                                                                                     // GET MISSING COMPONENTS
    {
        if (!canvasGroupToFlicker && GetComponent<CanvasGroup>())
            canvasGroupToFlicker = GetComponent<CanvasGroup>();
    }

    private void OnValidate() => GetMissingComponents();                                                                                     // ON VALIDATE
}
