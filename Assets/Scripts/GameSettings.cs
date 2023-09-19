using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    //Δημιουργούμε τα Settings, ορίζοντας τον αριθμό που μπορούν να επιλεγούν
    private int _settings;
    private const int SettingNumber = 2;

    //Ορίζουμε τα δεδομένα σε σχέση με τις 
    public enum EDifficultyNumber
    {
        NotSet = 0,
        First = 1,
        Second = 1,
        Third = 1,
    };
    //Ορίζουμε τις επιλογές που έχει ο χρήστης
    public enum ECategoriesNumber
    {
        NotSet,
        Glossa,
        Agglika,
        Agogi,
        Meleti,
        Math,
        IT,
        History,
        Religion
    };

    public struct Settings
    {
        public EDifficultyNumber EDifficultyNumber;
        public ECategoriesNumber ECategoriesNumber;
    };
    private Settings _gameSettings;

    public static GameSettings Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(target: this);
            Instance = this;
        }
        else
        {
            Destroy(obj: this);
        }
    }

    private void Start()
    {
        _gameSettings = new Settings();

    }

    public void SetEDifficultyNumber(EDifficultyNumber Number)
    {
        if (_gameSettings.EDifficultyNumber == EDifficultyNumber.NotSet)
            _settings++;

        _gameSettings.EDifficultyNumber = Number;
    }

    public void SetECategories(ECategoriesNumber cat)
    {
        if (_gameSettings.EDifficultyNumber == EDifficultyNumber.NotSet)
            _settings++;

        _gameSettings.ECategoriesNumber = cat;
    }

    public EDifficultyNumber GetEDifficultyNumber()
    {
        return _gameSettings.EDifficultyNumber;
    }

    public ECategoriesNumber GetECategoriesNumber()
    {
        return _gameSettings.ECategoriesNumber;
    }

    public void ResetGameSettings ()
    {
        _settings = 0;
        _gameSettings.EDifficultyNumber = EDifficultyNumber.NotSet;
        _gameSettings.ECategoriesNumber = ECategoriesNumber.NotSet;
    }




}