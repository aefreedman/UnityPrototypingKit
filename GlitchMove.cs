// GlitchMove.cs
// Last edited 9:53 PM 04/21/2015 by Aaron Freedman

using System.Collections;
using UnityEngine;

namespace Assets.PrototypingKit
{
    [RequireComponent(typeof (AudioSource))]
    public class GlitchMove : MonoBehaviour
    {
        public Vector3 magnitude;
        public Vector3 magnitudeMin;
        private Vector3 originalPos;
        public float delayMin;
        public float delayMax;
        public int glitchIterationsMin;
        public int glitchIterationsMax;
        private int glitchAmount;
        private float lastGlitch;
        private float nextGlitch;
        public float iterationGapMin;
        public float iterationGapMax;
        public bool useAudio;
        public AudioClip[] glitchClip;

        private void Start()
        {
            originalPos = transform.localPosition;
            lastGlitch = Time.time;
            CalculateNextGlitch();
            if (GetComponent<AudioSource>() == null)
            {
                gameObject.AddComponent<AudioSource>();
            }
        }

        private void Update()
        {
            if (Time.time > nextGlitch)
            {
                StartCoroutine(Glitch());
            }
        }

        private IEnumerator Glitch()
        {
            for (var i = 0; i < glitchAmount; i++)
            {
                if (useAudio)
                {
                    GetComponent<AudioSource>().PlayOneShot(glitchClip[Random.Range(0, glitchClip.Length)]);
                }
                transform.Translate(Random.Range(-magnitude.x - magnitudeMin.x, magnitude.x + magnitudeMin.x),
                                    Random.Range(-magnitude.y - magnitudeMin.y, magnitude.y + magnitudeMin.y),
                                    Random.Range(-magnitude.z - magnitudeMin.z, magnitude.z + magnitudeMin.z));
                yield return new WaitForSeconds(Random.Range(iterationGapMin, iterationGapMax));
                transform.localPosition = originalPos;
            }
            lastGlitch = Time.time;
            transform.localPosition = originalPos;
            CalculateNextGlitch();
        }

        private void CalculateNextGlitch()
        {
            glitchAmount = Random.Range(glitchIterationsMin, glitchIterationsMax);
            nextGlitch = lastGlitch + Random.Range(delayMin, delayMax);
        }
    }
}