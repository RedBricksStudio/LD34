// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18408
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;


namespace AssemblyCSharp
{
	public static class TransformWrapper
	{
		public static void SetX(this Transform tr, float newX) {
			Vector3 newPosition = 
				new Vector3(newX, tr.position.y, tr.position.z);
			
			tr.position = newPosition;
		}

		public static void SetY(this Transform tr, float newY) {
			Vector3 newPosition = 
				new Vector3(tr.position.x, newY, tr.position.z);
			
			tr.position = newPosition;
		}

        public static void SetScale2D(this Transform tr, float newSize)
        {
            Vector3 newScale =
               new Vector3(newSize, newSize, tr.localScale.z);

            tr.localScale = newScale;
        }

        public static void SetScaleX(this Transform tr, float newX)
        {
            Vector3 newScale =
                new Vector3(newX, tr.localScale.y, tr.localScale.z);

            tr.localScale = newScale;
        }

        public static void SetScaleY(this Transform tr, float newY)
        {
            Vector3 newScale =
                new Vector3(tr.localScale.x, newY, tr.localScale.z);

            tr.localScale = newScale;
        }

        public static void Resize2D(this Transform tr, float delta)
        {
            Vector3 newScale =
                new Vector3(tr.localScale.x + delta, tr.localScale.y + delta, tr.localScale.z);

            tr.localScale = newScale;
        }

        public static void ResizeX(this Transform tr, float deltaX)
        {
            Vector3 newScale =
                new Vector3(tr.localScale.x + deltaX, tr.localScale.y, tr.localScale.z);

            tr.localScale = newScale;
        }

        public static void ResizeY(this Transform tr, float deltaY)
        {
            Vector3 newScale =
                new Vector3(tr.localScale.x, tr.localScale.y + deltaY, tr.localScale.z);

            tr.localScale = newScale;
        }
        
	}
}

