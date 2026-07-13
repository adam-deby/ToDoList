using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskScript : MonoBehaviour
{
    [Header("Objects and texts")]
    public TMP_Text _taskText;
    [SerializeField] private GameObject _completeObject;

    [Header("Buttons")]
    [SerializeField] private Button _removeButton;
    [SerializeField] private Button _completeButton;
    [SerializeField] private Button _renameButton;

    [Header("Data")]
    [SerializeField] private int _taskNumber;
    [SerializeField] private bool _completedTask = false;

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
        _completeButton.onClick.AddListener(() => manager.CompleteTask(_taskNumber));
        _renameButton.onClick.AddListener(() => manager.RenameTask(_taskNumber));
    }

    public void CompleteObjectSwap()
    {
        _completedTask = !_completedTask;

        if (_completedTask) _completeObject.SetActive(true);
        else _completeObject.SetActive(false);
    }
}
