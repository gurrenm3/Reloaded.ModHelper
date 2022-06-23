using System;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a Rectangle.
    /// </summary>
    public struct Rectangle : IShape2D
    {
        /// <summary>
        /// An empty rect with all values set to zero. Used for comparisson
        /// </summary>
        public static Rectangle Zero { get; set; } = new Rectangle(0, 0, 0, 0);

        /// <summary>
        /// Left coordinate.
        /// </summary>
        public int Left { get; private set; }

        /// <summary>
        /// Top coordinate.
        /// </summary>
        public int Top { get; private set; }

        /// <summary>
        /// Right coordinate.
        /// </summary>
        public int Right { get; private set; }

        /// <summary>
        /// Bottom coordinate.
        /// </summary>
        public int Bottom { get; private set; }

        /// <summary>
        /// Width of the Rectangle.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Height of the Rectangle.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// The Center point of this Rect.
        /// </summary>
        public Vector2 Center { get; private set; }


        /// <summary>
        /// Create a Rect based on the sides and top.
        /// </summary>
        /// <param name="left">Left coordinate.</param>
        /// <param name="top">Top coordinate.</param>
        /// <param name="right">Right coordinate.</param>
        /// <param name="bottom">Bottom coordinate.</param>
        public Rectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;

            var width = right - left;
            var height = bottom - top;

            Width = width;
            Height = height;
            Center = new Vector2(width / 2, height / 2);
        }

        /// <summary>
        /// Creates a <see cref="Rectangle"/> from a <see cref="System.Drawing.Rectangle"/>
        /// </summary>
        /// <param name="rectangle"></param>
        public Rectangle(System.Drawing.Rectangle rectangle)
        {
            Left = rectangle.Left;
            Top = rectangle.Top;
            Right = rectangle.Right;
            Bottom = rectangle.Bottom;

            var width = rectangle.Right - rectangle.Left;
            var height = rectangle.Bottom - rectangle.Top;

            Width = width;
            Height = height;
            Center = new Vector2(width / 2, height / 2);
        }

        /// <summary>
        /// Returns whether or not the provided <paramref name="vector2"/>
        /// is contained within this rect.
        /// </summary>
        /// <param name="vector2">Location to check.</param>
        /// <returns>True if the Vector2 is contained within the rect, otherwise false.</returns>
        public bool Contains(Vector2 vector2) => Contains(vector2.X, vector2.Y);

        /// <summary>
        /// Returns whether or not the provided <paramref name="point"/> 
        /// is contained within this rect.
        /// </summary>
        /// <param name="point">Point to check</param>
        /// <returns>True if the Point is contained within the rect, otherwise false.</returns>
        public bool Contains(Point point) => Contains(point.X, point.Y);

        /// <summary>
        /// Returns whether or not the provided X,Y points are contained within this rect.
        /// </summary>
        /// <param name="x">X Coord.</param>
        /// <param name="y">Y Coord.</param>
        /// <returns>True if the provided points are contained within the rect, otherwise false.</returns>
        public bool Contains(float x, float y)
        {
            bool containsX = x >= Left && x <= Right;
            bool containsY = y >= Bottom && y <= Top;
            return containsX && containsY;
        }

        /// <summary>
        /// Returns a random point from this Rectangle.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRandomPoint()
        {
            return Random.GetRandomPoint(this);
        }

        /// <summary>
        /// An override of the default ToString method
        /// </summary>
        /// <returns>A string of all the properties in order.
        /// <br/>Ex: "Rect: (0, 0, 1920, 1080) | Width: 1920, Height: 1080"</returns>
        public override string ToString()
        {
            return $"Rect: ({Left}, {Top}, {Right}, {Bottom}) | Width: {Width}, Height: {Height}";
        }

        /// <summary>
        /// Creates a <see cref="System.Drawing.Rectangle"/> from a <see cref="Rectangle"/>
        /// </summary>
        /// <param name="rect"></param>
        public static implicit operator System.Drawing.Rectangle(Rectangle rect)
        {
            return new System.Drawing.Rectangle(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        /// <summary>
        /// Creates a <see cref="Rectangle"/> from a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rect"></param>
        public static implicit operator Rectangle(System.Drawing.Rectangle rect)
        {
            return new System.Drawing.Rectangle(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }
    }
}
