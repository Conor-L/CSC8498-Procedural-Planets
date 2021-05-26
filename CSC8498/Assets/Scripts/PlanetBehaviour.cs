using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetBehaviour : MonoBehaviour
{

    public GameObject planet;
    public PlanetSettings pSettings;
    public PlanetColourSettings pColourSettings;
    private int originalHashS;
    private int originalHashC;
    public PlanetTester test;

    //UI
    public Slider radiusSlider;
    public Slider subdivisionSlider;
    public Slider noiseScaleSlider;
    public TMP_InputField noiseOffsetX;
    public TMP_InputField noiseOffsetY;
    public TMP_InputField noiseOffsetZ;
    public Slider noiseContrastSlider;
    public Slider noiseAmplitudeSlider;
    public Slider mountainHeightSlider;
    public Slider hueSlider;
    public Slider triplanarScaleSlider;
    public Slider triplanarSharpSlider;
    public Button randomizeOffsetBtn;
    public Button randomizePlanetBtn;

    //FPS
    private bool showFPS = false;
    private float deltaTime;
    public TMP_Text FPSCounter;
    public Button showFPSBtn;

    // Performance
    public TMP_Text previousTimeText;
    public TMP_Text smallTimeText;
    public TMP_Text bigTimeText;
    public TMP_Text differenceText;
    public Button measurePerformanceBtn;
    private float totalSmallTime = 0.0f;
    private float totalBigTime = 0.0f;
    private float previousTime = 0.0f;

    [Header("Rotation Controls")]
    [Range(0, 1)]
    public float rotationSpeed = 0.1f;

    void Start()
    {
        originalHashS = pSettings.GetHashCode();
        originalHashC = pColourSettings.GetHashCode();
        test.CreatePlanet();
        showFPSBtn.onClick.AddListener(ChangeShowFPS);
        randomizeOffsetBtn.onClick.AddListener(GenerateRandomOffset);
        randomizePlanetBtn.onClick.AddListener(GenerateRandomPlanet);
        measurePerformanceBtn.onClick.AddListener(MeasurePerformance);
    }

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (showFPS)
        {
            FPSCounter.enabled = true;
        }

        else
        {
            FPSCounter.enabled = false;
        }

        FPSCounter.text = (1.0f / deltaTime).ToString("F2") + " FPS";
        previousTimeText.text = "The last planet took " + previousTime + " seconds to generate.";
        smallTimeText.text = "Time to generate small planets: " + totalSmallTime + " seconds.";
        bigTimeText.text = "Time to generate big planets: " + totalBigTime + " seconds.";
        differenceText.text = "Difference in time: " + Mathf.Abs(totalBigTime - totalSmallTime) + " seconds.";
    }

    void FixedUpdate()
    {
        planet.transform.Rotate(rotationSpeed, rotationSpeed, rotationSpeed / 10);

        //UI
        pSettings.planetRadius = radiusSlider.value;
        pSettings.planetSubdivisions = (int)subdivisionSlider.value;
        pSettings.noiseScale = noiseScaleSlider.value;
        pSettings.noiseOffset = new Vector3(float.Parse(noiseOffsetX.text, System.Globalization.NumberStyles.Any), float.Parse(noiseOffsetY.text, System.Globalization.NumberStyles.Any), float.Parse(noiseOffsetZ.text, System.Globalization.NumberStyles.Any));
        pSettings.noiseContrast = noiseContrastSlider.value;
        pSettings.displacementAmplitude = noiseAmplitudeSlider.value;
        pSettings.mountainHeight = mountainHeightSlider.value;

        // UI - Graphics
        pColourSettings.hueOffset = hueSlider.value;
        pColourSettings.triplanarScale = triplanarScaleSlider.value;
        pColourSettings.triplanarSharpness = triplanarSharpSlider.value;

        // If the planet settings have changed, re-generate the planet
        if (originalHashS != pSettings.GetHashCode())
        {
            float timeBefore = Time.realtimeSinceStartup;
            test.CreatePlanet();
            float timeAfter = Time.realtimeSinceStartup;
            previousTime = timeAfter - timeBefore;
            Debug.Log("Original: " + originalHashS + " New: " + pSettings.GetHashCode());
            originalHashS = pSettings.GetHashCode();
        }

        // If the colour/graphics settings have changed, re-generate the planet
        if (originalHashC != pColourSettings.GetHashCode())
        {
            float timeBefore = Time.realtimeSinceStartup;
            test.CreatePlanet();
            float timeAfter = Time.realtimeSinceStartup;
            previousTime = timeAfter - timeBefore;
            Debug.Log("Original: " + originalHashC + " New: " + pColourSettings.GetHashCode());
            originalHashC = pColourSettings.GetHashCode();
        }

    }

    void ChangeShowFPS()
    {
        showFPS = !showFPS;
    }

    void GenerateRandomOffset()
    {
        float randX, randY, randZ;
        randX = Random.Range(-1000.0f, 1000.0f);
        randY = Random.Range(-1000.0f, 1000.0f);
        randZ = Random.Range(-1000.0f, 1000.0f);

        // Vector3 randomOffset = new Vector3(randX, randY, randZ);
        noiseOffsetX.text = randX.ToString();
        noiseOffsetY.text = randY.ToString();
        noiseOffsetZ.text = randZ.ToString();
    }

    void GenerateRandomPlanet()
    {
        float timeBefore = Time.realtimeSinceStartup;

        float randRadius = Random.Range(radiusSlider.minValue, radiusSlider.maxValue);
        radiusSlider.value = randRadius;

        float randNoiseScale = Random.Range(noiseScaleSlider.minValue + 0.3f, -(radiusSlider.value / (radiusSlider.maxValue * 2)) + 1.0f);
        noiseScaleSlider.value = randNoiseScale;

        GenerateRandomOffset();

        float randContrast = Random.Range(noiseContrastSlider.minValue + 0.5f, noiseContrastSlider.maxValue);
        noiseContrastSlider.value = randContrast;

        float randAmplitude = Random.Range(noiseAmplitudeSlider.minValue + 150, noiseAmplitudeSlider.maxValue - 300);
        noiseAmplitudeSlider.value = randAmplitude;

        float randMountainHeight = Random.Range(mountainHeightSlider.minValue + 150, mountainHeightSlider.maxValue - 200);
        mountainHeightSlider.value = randMountainHeight;

        float timeAfter = Time.realtimeSinceStartup;
        previousTime = timeAfter - timeBefore;
    }

    void MeasurePerformance()
    {
        totalSmallTime = 0.0f;
        totalBigTime = 0.0f;

        pSettings.planetRadius = 1000;
        for (int i = 0; i < 100; i++)
        {            
            float timeBefore = Time.realtimeSinceStartup;
            pSettings.noiseOffset = new Vector3(Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f));
            test.CreatePlanet();
            float timeAfter = Time.realtimeSinceStartup;
            totalSmallTime += (timeAfter - timeBefore);
        }

        pSettings.planetRadius = 5000;
        for (int i = 0; i < 100; i++)
        {            
            float timeBefore = Time.realtimeSinceStartup;
            pSettings.noiseOffset = new Vector3(Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f));
            test.CreatePlanet();
            float timeAfter = Time.realtimeSinceStartup;
            totalBigTime += (timeAfter - timeBefore);
        }

    }
}
