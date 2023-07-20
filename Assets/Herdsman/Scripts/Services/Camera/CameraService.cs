using UnityEngine;

namespace Services.Camera
{
    public class CameraService : MonoBehaviour
    {
        [field: SerializeField] private UnityEngine.Camera MainCamera { get; set; }
    }
}

