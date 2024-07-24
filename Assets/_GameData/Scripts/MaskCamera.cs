using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaskCamera : MonoBehaviour
{
    [HideInInspector]
    public bool shouldClearRender;
    public GameObject mask;
    private float baseWidth;
    private float baseHeight;
    private Rect screenRect;
    private RenderTexture rt;
    public Material brushMaterial;
    private bool firstFrame;
    private Vector2? newBrushHolePosition;

    private void ApplyBrushHole(Vector2 imageSize, Vector2 imageLocalPosition)
    {
        Rect textureRect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        Rect positionRect = new Rect(
            (imageLocalPosition.x - 0.5f * this.brushMaterial.mainTexture.width) / imageSize.x,
            (imageLocalPosition.y - 0.5f * this.brushMaterial.mainTexture.height) / imageSize.y,
            this.brushMaterial.mainTexture.width / imageSize.x,
            this.brushMaterial.mainTexture.height / imageSize.y);

        GL.PushMatrix();
        GL.LoadOrtho();
        for (int i = 0; i < this.brushMaterial.passCount; i++)
        {
            this.brushMaterial.SetPass(i);
            GL.Begin(GL.QUADS);
            GL.Color(Color.white);
            GL.TexCoord2(textureRect.xMin, textureRect.yMax);
            GL.Vertex3(positionRect.xMin, positionRect.yMax, 0.0f);
            GL.TexCoord2(textureRect.xMax, textureRect.yMax);
            GL.Vertex3(positionRect.xMax, positionRect.yMax, 0.0f);
            GL.TexCoord2(textureRect.xMax, textureRect.yMin);
            GL.Vertex3(positionRect.xMax, positionRect.yMin, 0.0f);
            GL.TexCoord2(textureRect.xMin, textureRect.yMin);
            GL.Vertex3(positionRect.xMin, positionRect.yMin, 0.0f);
            GL.End();
        }
        GL.PopMatrix();
    }

    public IEnumerator Start()
    {
        firstFrame = true;

        RawImage rawImage = this.mask.GetComponent<RawImage>();
        Image image = this.mask.GetComponentInChildren<Image>();

        this.baseHeight = image.sprite.texture.height;
        this.baseWidth = image.sprite.texture.width;

        // for testing
        /*Debug.Log(-(float)image.sprite.texture.width / 200);
        Debug.Log(-(float)image.sprite.texture.height / 200);
        Debug.Log((float)image.sprite.texture.width / 100);
        Debug.Log((float)image.sprite.texture.height / 100);*/
        //Get brush effect boundary area
        this.screenRect.x = -(float)image.sprite.texture.width / 200;
        this.screenRect.y = -(float)image.sprite.texture.height / 200;
        this.screenRect.width = (float)image.sprite.texture.width / 100;
        this.screenRect.height = (float)image.sprite.texture.height / 100;

        //Create new render texture for camera target texture
        rt = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.Default);

        yield return rt.Create();
        
        GetComponent<Camera>().targetTexture = rt;

        //Set Mask Texture to brush material to Generate paint or erase effect
        rawImage.texture = rt;

        image.SetNativeSize();
    }

    public void Update()
    {
        this.newBrushHolePosition = null;
		if (Input.GetMouseButton(0) && GameManager.instance.canDrawMask )
        {
            Vector2 v = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            Rect worldRect = this.screenRect;
            if (worldRect.Contains(v))
                this.newBrushHolePosition = new Vector2(this.baseWidth * (v.x - worldRect.xMin) / worldRect.width, this.baseHeight * (v.y - worldRect.yMin) / worldRect.height);
        }
    }

    public void OnPostRender()
    {
        if (firstFrame || this.shouldClearRender)
        {
            firstFrame = false;
            shouldClearRender = false;
            GL.Clear(false, true, new Color(0.0f, 0.0f, 0.0f, 0.0f));
        }
        if (this.newBrushHolePosition != null)
            ApplyBrushHole(new Vector2(this.baseWidth, this.baseHeight), this.newBrushHolePosition.Value);
    }
}