//
// Equations.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using CoreGraphics;

namespace ProjectX
{
	public static class Equations
	{
		public static CGPoint PointOnCircle(nfloat radius, nfloat angleInDegrees, CGPoint origin)
		{
			if (angleInDegrees < 0.0f) {
				angleInDegrees = 360 - angleInDegrees;
			}

			// Convert from degrees to radians via multiplication by PI/180        
			float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + (float)origin.X;
			float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + (float)origin.Y;

			return new CGPoint(x, y);
		}
	}
}

