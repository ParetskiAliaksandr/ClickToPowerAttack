using UnityEngine;

[RequireComponent (typeof(Animator))]
public class ScreenFader : MonoBehaviour
{
    private Animator _screenFaderAnimator;

    private void OnEnable()
    {
        SceneLoadManager.OnActivateBrightenScreenAnim += ActivateBrightenScreenAnim;

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

        SceneLoadManager.OnActivateBrightenScreenAnim -= ActivateBrightenScreenAnim;
    }
}
