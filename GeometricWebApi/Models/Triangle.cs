using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GeometricWebApi.Models
{
	public class Triangle
	{
		private static Dictionary<KeyValuePair<string, string>, Triangle> _allTriangles;
		private const int Width = 10;
		private const int Height = 10;
		private static readonly int[] XValues = Enumerable.Range(1, 12).Select(i => (((i % 2 == 0) ? (i / 2) - 1 : (i - 1) / 2)) * Width).ToArray();
		private static readonly Dictionary<string, int> YValues = new Dictionary<string, int>
		{
			{"A", 0 * Height},
			{"B", 1 * Height},
			{"C", 2 * Height},
			{"D", 3 * Height},
			{"E", 4 * Height},
			{"F", 5 * Height}
		};
		public string Row { get; set; }
		public int Column { get; set; }
		public bool IsTop => ((Column % 2) == 0);

		public Point A => new Point(XValues[Column - 1], YValues[Row]);

		public Point B => (IsTop) ? new Point(C.X, A.Y) : new Point(A.X, C.Y);

		public Point C => new Point(A.X + Width, A.Y + Height);

		public string ErrorMessage { get; set; }

		public Triangle(string row, string column)
		{
			Row = row.ToUpper();
			if (YValues.ContainsKey(Row)) {
				var isParsed = int.TryParse(column, out var col);
				if (!isParsed)
					throw new ArgumentOutOfRangeException(nameof(column), "Invalid numeric value.");
				Column = col;
				if (Column > 12 || Column < 1) {
					throw new ArgumentOutOfRangeException(nameof(column), "Invalid numeric value. Out of range.");
				}
			} else {
				throw new ArgumentOutOfRangeException(nameof(row), "Invalid row value.");
			}
		}

		public Triangle(string errorMessage)
		{
			Row = "E";
			Column = 1;
			ErrorMessage = $"Error: {errorMessage}";
		}

		public static Dictionary<KeyValuePair<string, string>, Triangle> GetAllTriangles()
		{
			return _allTriangles ?? (_allTriangles = GetTriangles());
		}

		private static Dictionary<KeyValuePair<string, string>, Triangle> GetTriangles()
		{
			var triangles = new Dictionary<KeyValuePair<string, string>, Triangle>();
			foreach (var yValue in YValues) {
				var row = yValue.Key;
				for (var i = 1; (i <= XValues.Length); i++) {
					var column = i.ToString();
					triangles.Add(new KeyValuePair<string, string>(row, column), new Triangle(row, column));
				}
			}
			return triangles;
		}
	}
}