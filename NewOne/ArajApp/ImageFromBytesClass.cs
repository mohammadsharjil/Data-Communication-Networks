﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ArajApp
{
    class ImageFromBytesClass
    {
        public void imagefrombytes(ref byte[] bytez, ref Bitmap piccolor)
        {
            Rectangle rect = new Rectangle(0, 0, piccolor.Width, piccolor.Height);
            System.Drawing.Imaging.BitmapData bmpData = piccolor.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * piccolor.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int secondcounter = 0;
            int tempred = 0;
            int tempblue = 0;
            int tempgreen = 0;
            int tempalpha = 0;
            secondcounter = 0;

            while (secondcounter < rgbValues.Length)
            {
                tempblue = rgbValues[secondcounter];
                tempgreen = rgbValues[secondcounter + 1];
                tempred = rgbValues[secondcounter + 2];
                tempalpha = rgbValues[secondcounter + 3];
                tempalpha = 255;

                tempred = bytez[(int)((secondcounter * 0.25) * 3) + 0];
                tempgreen = bytez[(int)((secondcounter * 0.25) * 3) + 1];
                tempblue = bytez[(int)((secondcounter * 0.25) * 3) + 2];

                rgbValues[secondcounter] = (byte)tempblue;
                rgbValues[secondcounter + 1] = (byte)tempgreen;
                rgbValues[secondcounter + 2] = (byte)tempred;
                rgbValues[secondcounter + 3] = (byte)tempalpha;

                secondcounter = secondcounter + 4;
            }


            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            piccolor.UnlockBits(bmpData);

        }
    }
}
