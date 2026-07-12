using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskScript : MonoBehaviour
{
    public TMP_Text _taskText;
    public Button _removeButton;

    private ManagerScript manager;

    public int _taskNumber;

    public void TaskNumberSet(int number)
    {
        _taskNumber = number;
    }

    public void Initialize(ManagerScript manager, int number)
    {
        this.manager = manager;
        _taskNumber = number;

        _removeButton.onClick.RemoveAllListeners();
        _removeButton.onClick.AddListener(() => manager.RemoveTask(_taskNumber));
    }
}
