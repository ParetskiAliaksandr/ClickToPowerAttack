using UnityEngine;

[RequireComponent (typeof(Animator))]
public class ScreenFader : MonoBehaviour
{
    private Animator _screenFaderAnimator;

    private void OnEnable()
    {
        SceneLoadManager.Instance.OnActivateBrightenScreenAnim += ActivateBrightenScreenAnim;

        _screenFaderAnimator = GetComponent<Animator>();
    }

    private void ActivateBrightenScreenAnim()
    {
        _screenFaderAnimator.SetTrigger("StartBrighten");
    }

    private void OnDisable()
    {
        if (SceneLoadManager.Instance == null || SceneLoadManager.IsShuttingDown)
        {
            return;
        }

        SceneLoadManager.Instance.OnActivateBrightenScreenAnim -= ActivateBrightenScreenAnim;
    }
}
