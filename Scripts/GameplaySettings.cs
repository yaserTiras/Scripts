using UnityEngine;

public class GameplaySettings : MonoBehaviour
{
    public static GameplaySettings instance;

    [Header("Player")]
    [SerializeField] private float _runSpeed = 1f;

    [Header("GamePlay")]

    [SerializeField] private float _bridgeWidth = 1f;
    [SerializeField] private float _bridgeCreationCost = 1f;
    [SerializeField] private float _bridgeCreationRate = 1f;
    [SerializeField] private float _railsSlidingSpeed = 1f;
    [SerializeField] private float _stickIncreaseValue = 1f;
    [SerializeField] private float _platformWidth = 1f;
    [SerializeField] private float _gemRotationSpeed = 1f;

    [Header("Input")]
    [SerializeField] private float _sensitivity = 1f;

    public float runSpeed { get { return _runSpeed; } private set { _runSpeed = value; } }
    public float bridgeWidth { get { return _bridgeWidth; } private set { _bridgeWidth = value; } }
    public float bridgeCreationCost { get { return _bridgeCreationCost; } private set { _bridgeCreationCost = value; } }
    public float bridgeCreationRate { get { return _bridgeCreationRate; } private set { _bridgeCreationRate = value; } }
    public float railsSlidingSpeed { get { return _railsSlidingSpeed; } private set { _railsSlidingSpeed = value; } }
    public float stickIncreaseValue { get { return _stickIncreaseValue; } private set { _stickIncreaseValue = value; } }
    public float platformWidth { get { return _platformWidth; } private set { _platformWidth = value; } }
    public float gemRotationSpeed { get { return _gemRotationSpeed; } private set { _gemRotationSpeed = value; } }
    public float sensitivity { get { return _sensitivity; } private set { _sensitivity = value; } }



    private void Awake()
    {
        instance = this;
    }

}
