using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class MatrixBlender : MonoBehaviour
{
    Camera _camera;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    public static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
    {
        Matrix4x4 ret = new Matrix4x4();
        for (int i = 0; i < 16; i++)
            ret[i] = Mathf.Lerp(from[i], to[i], time);
        return ret;
    }

    private IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration)
    {
        var controller = GetComponent<CameraController>();
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            _camera.projectionMatrix = MatrixLerp(src, dest, (Time.time - startTime) / duration);
            controller.CanSwitch(false);
            controller.CanRotate(false);
            yield return 1;
        }
        _camera.projectionMatrix = dest;
        
        controller.CanSwitch(true);
        _camera.orthographic = !_camera.orthographic;
        if(!_camera.orthographic) controller.CanRotate(true);
    }

    public Coroutine BlendToMatrix(Matrix4x4 targetMatrix, float duration)
    {
        StopAllCoroutines();
        return StartCoroutine(LerpFromTo(_camera.projectionMatrix, targetMatrix, duration));
    }
}
