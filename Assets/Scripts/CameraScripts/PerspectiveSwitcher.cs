using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

[RequireComponent(typeof(MatrixBlender))]
public class PerspectiveSwitcher : MonoBehaviour
{
    private Matrix4x4 ortho,
                        perspective;
    public float fov = 60f,
                        near = .3f,
                        far = 1000f,
                        orthographicSize = 50f;
    private float aspect;
    private MatrixBlender blender;
    private bool orthoOn;



    [SerializeField] float _switchDuration = 0.6f;

    void Start()
    {
        aspect = (float)Screen.width / (float)Screen.height;
        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);
        Camera.main.projectionMatrix = ortho;
        orthoOn = true;
        blender = (MatrixBlender)GetComponent(typeof(MatrixBlender));
    }

    public void SwitchPerspective()
    {
        GetComponent<CameraController>().CanRotate(false);
        GetComponent<CameraController>().CanSwitch(false);

        orthoOn = !orthoOn;
        if (orthoOn)
            blender.BlendToMatrix(ortho, _switchDuration);
        else
            blender.BlendToMatrix(perspective, _switchDuration);
    }
}