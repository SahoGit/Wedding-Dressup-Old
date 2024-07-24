using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintTexture2D : MonoBehaviour
{
    #region Variables, Constants & Initializers
    
    public Camera mainCamera;
    public float brushSize;
    public List<Image> patterns;
    public List<Image> targets;
    public GameObject applicatorTip;
    public List<Vector2> brushOffsets;
    public bool showBrushPointer;


    private Image pattern;
    private Image target;
    private List<Collider2D> targetColliders;
    private float offsetX = 0;
    private float offsetY = 0;

    #endregion

    #region Lifecycle Methods

    void Start()
    {
        this.targetColliders = new List<Collider2D>();

        for (int i = 0; i < this.targets.Count; i++)
        {
            this.targetColliders.Add(this.targets[i].GetComponent<Collider2D>());
        }

        // set defaults
        this.target = this.targets[0];
        this.pattern = this.patterns[0];
        this.offsetX = brushOffsets[0].x;
        this.offsetY = brushOffsets[0].y;
    }

    #endregion

    #region Callback Methods

    public void ChangeTargetImage(Collider2D collider)
    {
        for (int i = 0; i < this.targetColliders.Count; i++)
        {
            if (collider.IsTouching(this.targetColliders[i]))
            {
                this.target = this.targets[i];
				this.pattern = this.patterns[i];
                this.offsetX = brushOffsets[i].x;
                this.offsetY = brushOffsets[i].y;
                break;
            }
        }
    }
    int temp = 0;
    public void PaintTargetByTipPosition()
    {
        float brushPositionX = applicatorTip.transform.position.x + offsetX;
        float brushPositionY = applicatorTip.transform.position.y + offsetY;
        temp++;
        if (temp % 3 == 0)
        {
            if (this.showBrushPointer)
            {
                Debug.Log("TargetRotation : " + this.target.rectTransform.transform.rotation);
            }
            if (this.target.rectTransform.transform.rotation.y != 0)
            {
                brushPositionX = 1 - brushPositionX;
            }
            if (this.target.rectTransform.transform.rotation.x != 0)
            {
                brushPositionY = 1 - brushPositionY;
            }

            Vector2 brushPosition = new Vector2(brushPositionX, brushPositionY);
            if (this.showBrushPointer)
            {
                Debug.Log("BrushPosition : " + brushPosition);
            }

            Texture2D newTexture2D = FillCircle(target.sprite.texture, brushPosition);

            target.sprite = Sprite.Create(newTexture2D, target.sprite.rect, new Vector2(0.5f, 0.5f)); //Create a new sprite
        }

       
    }

    private Texture2D FillCircle(Texture2D targetTexture, Vector2 brushPosition)
    {
        Texture2D texture = new Texture2D(targetTexture.width, targetTexture.height); //Create a new Texture2D, which will be the copy
        texture.filterMode = FilterMode.Bilinear; //Choose your filtermode and wrapmode
        texture.wrapMode = TextureWrapMode.Clamp;

        float m1 = brushPosition.x * texture.width;
        float m2 = brushPosition.y * texture.height;

        float differenceX, differenceY;

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                differenceX = x - m1;
                differenceY = y - m2;
                //INSERT YOUR LOGIC HERE
                if (((differenceX * differenceX) + (differenceY * differenceY)) <= (brushSize * brushSize))
                {
                    texture.SetPixel(x, y, pattern.sprite.texture.GetPixel(x, y)); //InitialColor.a = 255; //This line of code and if statement, turn all texture pixels within radius to zero alpha
                }
                else
                {
                    if (!this.showBrushPointer)
                    {
                        texture.SetPixel(x, y, targetTexture.GetPixel(x, y)); //This line of code is REQUIRED. Do NOT delete it. This is what copies the image as it was, without any change
                    }
                }
            }
        }
        texture.Apply(); //This finalizes it. If you want to edit it still, do it before you finish with Apply(). Do NOT expect to edit the image after you have applied.
        return texture;
    }

    #endregion
}
