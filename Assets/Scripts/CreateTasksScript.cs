using UnityEngine;

public class CreateTasksScript : MonoBehaviour
{
    public ManagerScript MS;

    public void ButtonClicked()
    {
        MS.AddTask();
        Destroy(gameObject);
    }
}
