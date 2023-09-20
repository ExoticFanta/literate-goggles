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
        public EDifficultyNumber DifficultyNumber;
        public ECategoriesNumber CategoriesNumber;
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

    public void SetDifficultyNumber(EDifficultyNumber Number)
    {
        if (_gameSettings.DifficultyNumber == EDifficultyNumber.NotSet)
            _settings++;

        _gameSettings.DifficultyNumber = Number;
    }

    public void SetECategories(ECategoriesNumber cat)
    {
        if (_gameSettings.DifficultyNumber == EDifficultyNumber.NotSet)
            _settings++;

        _gameSettings.CategoriesNumber = cat;
    }

    public EDifficultyNumber GetEDifficultyNumber()
    {
        return _gameSettings.DifficultyNumber;
    }

    public ECategoriesNumber GetECategoriesNumber()
    {
        return _gameSettings.CategoriesNumber;
    }

    public void ResetGameSettings ()
    {
        _settings = 0;
        _gameSettings.DifficultyNumber = EDifficultyNumber.NotSet;
        _gameSettings.CategoriesNumber = ECategoriesNumber.NotSet;
    }

    public bool AllSettingsReady()
    {
        return _settings == SettingNumber;
    }


}