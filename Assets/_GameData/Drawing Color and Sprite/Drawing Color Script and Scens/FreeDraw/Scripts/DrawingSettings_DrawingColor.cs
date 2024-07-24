using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FreeDraw
{
    // Helper methods used to set drawing settings
    public class DrawingSettings_DrawingColor : MonoBehaviour
    {
        public static bool isCursorOverUI = false;
        public float Transparency = 1f;
        [Header("List of Drawables on with you want to change patterns")]
        public Drawable_DrawingColor[] drawables;
        
        // Changing pen settings is easy as changing the static properties Drawable.Pen_Colour and Drawable.Pen_Width
        public void SetMarkerColour(Color new_color)
        {
            Drawable_DrawingColor.isColor = true;
            Drawable_DrawingColor.Pen_Colour = new_color;
            
        }

        public void SetPattern(int patternIndex)
        {
            if (drawables.Length >0)
            {
                for (int i = 0; i < drawables.Length; i++)
                {
                    Drawable_DrawingColor.isColor = false;
                    drawables[i].ChangePenPattern(patternIndex);
                }
            }


        }

        public void IsColor(bool colorVal)
        {
            Drawable_DrawingColor.isColor = colorVal;

        }

        // new_width is radius in pixels
        public void SetMarkerWidth(int new_width)
        {
            Drawable_DrawingColor.Pen_Width = new_width;
        }
        public void SetMarkerWidth(float new_width)
        {
            SetMarkerWidth((int)new_width);
        }

        public void SetTransparency(float amount)
        {
            Transparency = amount;
            Color c = Drawable_DrawingColor.Pen_Colour;
            c.a = amount;
            Drawable_DrawingColor.Pen_Colour = c;
        }


        // Call these these to change the pen settings
        public void SetMarkerRed()
        {
            Color c = Color.red;
            c.a = Transparency;
            SetMarkerColour(c);
        }
        public void SetMarkerGreen()
        {
            Color c = Color.green;
            c.a = Transparency;
            SetMarkerColour(c);
        }
        public void SetMarkerBlue()
        {
            Color c = Color.blue;
            c.a = Transparency;
            SetMarkerColour(c);
        }
        public void SetEraser()
        {
            SetMarkerColour(Color.white);
        }

        public void PartialSetEraser()
        {
            SetMarkerColour(Color.white);
        }
    }
}