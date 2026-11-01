using UnityEngine;

/// <summary>
/// Switches the classroom between day and night.
/// Day: bright sun through the windows, day sky.
/// Night: sun dimmed, night sky, ceiling lights switched on.
/// Called from the World Space UI button "Day / Night".
/// </summary>
public class EnvironmentController : MonoBehaviour
{
    [Header("Sun")]
    [SerializeField] private Light sunLight;
    [SerializeField] private float dayIntensity = 1.6f;
    [SerializeField] private float nightIntensity = 0.02f;
    [SerializeField] private Color dayColor = new Color(1f, 0.95f, 0.86f);
    [SerializeField] private Color nightColor = new Color(0.45f, 0.55f, 0.85f);

    [Header("Sky")]
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;
    [SerializeField] private float dayAmbientIntensity = 1f;
    [SerializeField] private float nightAmbientIntensity = 0.3f;

    [Header("Ceiling lights (switched on at night)")]
    [SerializeField] private Light[] ceilingLights;

    private bool isNight;

    private void Start()
    {
        ApplyLighting();
    }

    public void ToggleNightMode()
    {
        isNight = !isNight;
        ApplyLighting();
    }

    private void ApplyLighting()
    {
        if (sunLight != null)
        {
            sunLight.intensity = isNight ? nightIntensity : dayIntensity;
            sunLight.color = isNight ? nightColor : dayColor;
        }

        Material targetSkybox = isNight ? nightSkybox : daySkybox;
        if (targetSkybox != null)
        {
            RenderSettings.skybox = targetSkybox;
        }

        RenderSettings.ambientIntensity = isNight ? nightAmbientIntensity : dayAmbientIntensity;
        DynamicGI.UpdateEnvironment();

        foreach (Light ceilingLight in ceilingLights)
        {
            if (ceilingLight != null)
            {
                ceilingLight.enabled = isNight;
            }
        }
    }
}
