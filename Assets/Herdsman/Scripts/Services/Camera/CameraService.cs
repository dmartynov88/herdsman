using UnityEngine;

namespace Services.Camera
{
    public class CameraService : MonoBehaviour
    {
        [field: SerializeField] public UnityEngine.Camera MainCamera { get; set; }
    }
}

