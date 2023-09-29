using System;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        int width = 7680;  
        int height = 4320; 

        // Create a bitmap to draw on
        using (Bitmap bitmap = new Bitmap(width, height))
        {
            Color black = Color.Black;
            Color white = Color.White;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bitmap.SetPixel(i, j, black);

                }

            }

            int ax, ay;
            int bx, by;
            int cx, cy;
            int triangle_height = height - 200;
            int triangle_base = Math.Abs((int)(triangle_height / (Math.Sin(60))));

            ax = width / 2;
            ay = 100;

            bx = Math.Abs(ax - triangle_height / 2);
            by = Math.Abs(ay + triangle_height);

            cx = Math.Abs(ax + triangle_height / 2);
            cy = Math.Abs(ay + triangle_height);

            Console.WriteLine(ax + "," + ay + "," + cx + "," + cy + "," + triangle_base);



            Pen whitepen = new Pen(white);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawLine(whitepen, ax, ay, bx, by);
                graphics.DrawLine(whitepen, bx, by, cx, cy);
                graphics.DrawLine(whitepen, cx, cy, ax, ay);

            }


            int startX, startY;
            startX = ax;
            startY = Math.Abs((ay - by) / 2);

            int iterations = 10000000;

            Random random = new Random();

            int corner = 0;

            int selectedX = 0, selectedY = 0;
            int midX, midY;

            corner = random.Next(1, 4);

            switch (corner)
            {
                case 1:
                    selectedX = ax;
                    selectedY = ay;
                    break;

                case 2:
                    selectedX = bx;
                    selectedY = by;
                    break;

                case 3:
                    selectedX = cx;
                    selectedY = cy;
                    break;
            }

            midX = Math.Abs((startX + selectedX) / 2);
            midY = Math.Abs((startY + selectedY) / 2);


            bitmap.SetPixel(midX, midY, white);




            while (iterations != 0)
            {

                corner = random.Next(1, 4);


                switch (corner)
                {
                    case 1:
                        selectedX = ax;
                        selectedY = ay;
                        break;

                    case 2:
                        selectedX = bx;
                        selectedY = by;
                        break;

                    case 3:
                        selectedX = cx;
                        selectedY = cy;
                        break;
                }

                midX = Math.Abs((midX + selectedX) / 2);
                midY = Math.Abs((midY + selectedY) / 2);


                bitmap.SetPixel(midX, midY, white);




                iterations--;
            }



            bitmap.Save("triangle.png", ImageFormat.Png);
        }
    }


}

