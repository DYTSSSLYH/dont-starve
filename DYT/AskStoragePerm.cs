using UnityEngine;
using UnityEngine.Android;

namespace DYT
{
    public class AskStoragePerm : MonoBehaviour
    {
        void Awake()
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            }
        }
    }
}