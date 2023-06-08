using UnityEngine;
using UnityEngine.Video;

public class VideoTest : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    [SerializeField] private VideoClip clip;

    private void Start()
    {
        Application.runInBackground = true;

        //Ç’ÇÍÇ¢ÇﬁÅ[Ç—Å[
        PlayMovie();
    }

    private void Update()
    {
        Debug.LogWarning(player.isPlaying);
    }
    private void PlayMovie()
    {
        player.clip = clip;
        player.prepareCompleted += OnPrepared;

        player.Prepare();
    }
    void OnPrepared(VideoPlayer source)
    {
        Debug.Log("Prepared");
        player.frameReady += OnNewFrame;
        player.sendFrameReadyEvents = true;

        player.Play();
    }
    private void OnNewFrame(VideoPlayer source, long frameIdx)
    {
        Texture2D videoFrame = ToTexture2D(source.texture);
        // Do anything with the videoFrame Texture.
        var color = videoFrame.GetPixels();

        Debug.Log(string.Join(",", color));
    }

    public Texture2D ToTexture2D(Texture self)
    {
        var sw = self.width;
        var sh = self.height;
        var format = TextureFormat.RGBA32;
        var result = new Texture2D(sw, sh, format, false);
        var currentRT = RenderTexture.active;
        var rt = new RenderTexture(sw, sh, 32);
        Graphics.Blit(self, rt);
        RenderTexture.active = rt;
        var source = new Rect(0, 0, rt.width, rt.height);
        result.ReadPixels(source, 0, 0);
        result.Apply();
        RenderTexture.active = currentRT;
        return result;
    }
}
