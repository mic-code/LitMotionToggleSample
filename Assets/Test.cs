using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

public class Test : MonoBehaviour
{
    MotionHandle handle;
    public float Start = -1, End = 1;
    public float duration = 1;

    public void Toggle(bool isOn)
    {
        if (isOn)
            Play();
        else
            PlayReverse();
    }

    public void Play()
    {
        var builder = LMotion.Create(Start, End, duration).WithEase(Ease.InOutCubic);
        if (handle.IsActive())
        {
            handle.Cancel();
            builder.WithStartTime(duration - handle.Time);
        }

        handle = builder.BindToPositionX(transform);
    }

    public void PlayReverse()
    {
        var builder = LMotion.Create(End, Start, duration).WithEase(Ease.InOutCubic);

        if (handle.IsActive())
        {
            handle.Cancel();
            builder.WithStartTime(duration - handle.Time);
        }
        handle = builder.BindToPositionX(transform);
    }
}