using UnityEngine;

[RequireComponent (typeof(Animator))]
public class ScreenFader : MonoBehaviour
{
    private Animator _screenFaderAnimator;

    private void OnEnable()
    {
        if(SceneLoadManager.Instance != null)
        {
            SceneLoadManager.Instance.OnActivateBrightenScreenAnim += ActivateBrightenScreenAnim;
        }
        
        _screenFaderAnimator = GetComponent<Animator>();
    }

    private void ActivateBrightenScreenAnim(bool isOn)
    {
        _screenFaderAnimator.SetBool("StartBrighten", isOn);
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
