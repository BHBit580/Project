using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/VoidEventChannelSO")]
public class VoidEventChannelSO : ScriptableObject
{
    private event System.Action LoadingRequestEventHandler;
  
    public void RaiseEvent()
    {
        LoadingRequestEventHandler?.Invoke();
    }
    public void RegisterListener(System.Action listener)
    {
        LoadingRequestEventHandler += listener;
    }
    public void UnregisterListener(System.Action listener)
    {
        LoadingRequestEventHandler -= listener;
    }

}