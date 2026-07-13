using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskScript : MonoBehaviour
{
    [Header("Objects and texts")]
    public TMP_Text _taskText;
    public GameObject _completeObject;

    [Header("Buttons")]
    public Button _removeButton;
    public Button _completeButton;

    [Header("Data")]
    public int _taskNumber;
    public bool _completedTask = false;

    private ManagerScript manager;

    private void Start()
    {
        _completeObject.SetActive(false);
    }

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

    public void CompleteTaskInit(ManagerScript manager, int number)
    {
        this.manager = manager;

        _completeButton.onClick.RemoveAllListeners();
        _completeButton.onClick.AddListener(() => manager.CompleteTask(_taskNumber));
    }

}
