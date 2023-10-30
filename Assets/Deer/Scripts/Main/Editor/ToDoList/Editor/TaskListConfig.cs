using UnityEngine;

namespace Deer.Editor.TaskList
{
    [CreateAssetMenu(fileName = "TodoList", menuName = "Deer/Todo List", order = 300)]
    public class TaskListConfig : ScriptableObject
    {
#pragma warning disable 0414
        [SerializeField]
        int TaskCount = 0;
#pragma warning disable 0414
        [SerializeField]
        bool[] Mark = new bool[] { };
        [SerializeField]
        bool[] Enabled = new bool[] { };
        [SerializeField]
        int[] Progress = new int[] { };
        [SerializeField]
        string[] Title = new string[] { };
        [SerializeField]
        string[] Description = new string[] { };
    }
}
