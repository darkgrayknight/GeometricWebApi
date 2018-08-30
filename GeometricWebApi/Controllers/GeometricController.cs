using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GeometricWebApi.Models;

namespace GeometricWebApi.Controllers
{
    public class GeometricController : ApiController
    {
	    public Triangle Get(string row, string column)
	    {
			return new Triangle(row, column);
	    }

	    public RowColumn Get(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
	    {
		    return Get(new Point(v2x, v2y), new Point(v1x, v1y), new Point(v3x, v3y));
	    }

	    private RowColumn Get(Point v2, Point v1, Point v3)
	    {
		    var triangles = Triangle.GetAllTriangles();
		    foreach (var tri in triangles) {
			    if (tri.Value.A.Equals(v2) && tri.Value.B.Equals(v1) && tri.Value.C.Equals(v3))
				    return new RowColumn() {Column = tri.Key.Value, Row = tri.Key.Key};
		    }
			return new RowColumn() {Column = "does not exist", Row = "Error:"};
	    }
	}
}
