using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGameButton : MonoBehaviour
{
   
    public enum EButtonType
    {
        NotSet,
        DifficultyNumberBtn,
        CategoriesNumberBtn,
    };


    [SerializeField] public EButtonType ButtonType = EButtonType.NotSet;
    [HideInInspector] public GameSettings.EDifficultyNumber DifficultyNumber = GameSettings.EDifficultyNumber.NotSet;
    [HideInInspector] public GameSettings.ECategoriesNumber CategoriesNumber = GameSettings.ECategoriesNumber.NotSet;





    public void SetGameOption(string GameSceneName)
    {
        var comp = gameObject.GetComponent<SetGameButton>();

        switch(comp.ButtonType)
        {
            case SetGameButton.EButtonType.DifficultyNumberBtn:
                GameSettings.Instance.SetDifficultyNumber(comp.DifficultyNumber);
                break;

            case SetGameButton.EButtonType.CategoriesNumberBtn:
                GameSettings.Instance.SetECategories(comp.CategoriesNumber);
                break;
        }

        if(GameSettings.Instance.AllSettingsReady())
        {
            SceneManager.LoadScene(GameSceneName);
        }


    }




}

