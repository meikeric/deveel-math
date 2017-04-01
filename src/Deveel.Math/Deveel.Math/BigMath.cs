﻿using System;

namespace Deveel.Math {
	public static class BigMath {
		/// <summary>
		/// Computes an addition between two big integer numbers
		/// </summary>
		/// <param name="a">The first term of the addition</param>
		/// <param name="b">The second term of the addition</param>
		/// <returns>Returns a new <see cref="BigInteger"/> that
		/// is the result of the addition of the two integers specified</returns>
		public static BigInteger Add(BigInteger a, BigInteger b) {
			return Elementary.add(a, b);
		}
	}
}