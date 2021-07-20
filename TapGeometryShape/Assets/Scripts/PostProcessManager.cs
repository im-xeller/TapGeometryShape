using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessManager : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;

    [SerializeField] private PostProcessVolume volume;
    private LensDistortion _lensDistortion;

    private float _currentTime, _maxTime;

    private void Start()
    {
        volume.profile.TryGetSettings(out _lensDistortion);

        _maxTime = curve.keys[curve.keys.Length - 1].time;
    }

    private void Update()
    {
        _lensDistortion.intensity.value = curve.Evaluate(_currentTime);

        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxTime)
        {
            _currentTime = 0;
        }
    }
}
