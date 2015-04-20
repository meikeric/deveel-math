﻿using System;
using System.Globalization;

using NUnit.Framework;

namespace Deveel.Math {
	[TestFixture(Description = "Testing operations on BigDecimal class")]
	public class BigDecimalArithmeticTest {
		#region Add

		[TestCase("1231212478987482988429808779810457634781384756794987", 10,
			"747233429293018787918347987234564568", 10,
			"123121247898748373566323807282924555312937.1991359555", 10,
			Description = "Add two numbers of equal positive scales")]
		[TestCase("1231212478987482988429808779810457634781384756794987", -10,
			"747233429293018787918347987234564568", -10,
			"1.231212478987483735663238072829245553129371991359555E+61", -10,
			Description = "Add two numbers of equal negative scales")]
		[TestCase("1231212478987482988429808779810457634781384756794987", 15,
			"747233429293018787918347987234564568", -10,
			"7472334294161400358170962860775454459810457634.781384756794987", 15,
			Description = "Add two numbers of different scales; the first is positive")]
		[TestCase("1231212478987482988429808779810457634781384756794987", -15,
			"747233429293018787918347987234564568", 10,
			"1231212478987482988429808779810457634781459480137916301878791834798.7234564568", 10,
			Description = "Add two numbers of different scales; the first is negative")]
		[TestCase("0", -15, "0", 10, "0E-10", 10, Description = "Add two zeroes of different scales; the first is negative")]
		public void Add(string a, int aScale, string b, int bScale, string c, int cScale) {
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Add(bNumber);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(cScale, result.Scale, "incorrect scale");
		}

		[TestCase("1231212478987482988429808779810457634781384756794987", 10,
			"747233429293018787918347987234564568", 10,
			"1.2313E+41", -37,
			5, RoundingMode.Up,
			Description = "Add two numbers of equal positive scales using MathContext")]
		[TestCase("1231212478987482988429808779810457634781384756794987", -10,
			"747233429293018787918347987234564568", -10,
			"1.2312E+61", -57,
			5, RoundingMode.Floor,
			Description = "Add two numbers of equal negative scales using MathContext")]
		[TestCase("1231212478987482988429808779810457634781384756794987", 15,
			"747233429293018787918347987234564568", -10,
			"7.47233429416141E+45", -31,
			15, RoundingMode.Ceiling,
			Description = "Add two numbers of different scales using MathContext; the first is positive")]
		public void AddWithContext(string a, int aScale, string b, int bScale, string c, int cScale, int precision, RoundingMode mode) {
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			MathContext mc = new MathContext(precision, mode);
			BigDecimal result = aNumber.Add(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(cScale, result.Scale, "incorrect scale");
		}

		#endregion

		#region Subtract

		[TestCase("1231212478987482988429808779810457634781384756794987", 10,
			"747233429293018787918347987234564568", 10,
			"123121247898748224119637948679166971643339.7522230419", 10,
			Description = "Subtract two numbers of equal positive scales")]
		[TestCase("1231212478987482988429808779810457634781384756794987", -10,
			"747233429293018787918347987234564568", -10,
			"1.231212478987482241196379486791669716433397522230419E+61", -10,
			Description = "Subtract two numbers of equal negative scales")]
		[TestCase("1231212478987482988429808779810457634781384756794987", 15,
			"747233429293018787918347987234564568", -10,
			"-7472334291698975400195996883915836900189542365.218615243205013", 15,
			Description = "Subtract two numbers of different scales; the first is positive")]
		[TestCase("1231212478987482988429808779810457634781384756794987", -15,
			"747233429293018787918347987234564568", 10,
			"1231212478987482988429808779810457634781310033452057698121208165201.2765435432", 10,
			Description = "Subtract two numbers of different scales; the first is negative")]
		public void Subtract(string a, int aScale, string b, int bScale, string c, int cScale) {
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Subtract(bNumber);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(cScale, result.Scale, "incorrect scale");			
		}

		[TestCase("1231212478987482988429808779810457634781384756794987", 10,
			"747233429293018787918347987234564568", 10,
			"1.23121247898749E+41", -27,
			15, RoundingMode.Ceiling,
			Description = "Subtract two numbers of equal positive scales using MathContext")]
		[TestCase("1231212478987482988429808779810457634781384756794987", 15,
			"747233429293018787918347987234564568", -10,
			"-7.4723342916989754E+45", -29,
			17, RoundingMode.Down,
			Description = "Subtract two numbers of different scales using MathContext; the first is positive")]
		[TestCase("986798656676789766678767876078779810457634781384756794987", -15,
			"747233429293018787918347987234564568", 40,
			"9.867986566767897666787678760787798104576347813847567949870000000000000E+71", -2,
			70, RoundingMode.HalfDown,
			Description = "Subtract two numbers of different scales using MathContext; the first is negative")]
		public void SubtractWithContext(string a, int aScale, string b, int bScale, string c, int cScale, int precision, RoundingMode mode) {
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			MathContext mc = new MathContext(precision, RoundingMode.Ceiling);
			BigDecimal result = aNumber.Subtract(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(cScale, result.Scale, "incorrect scale");			
		}

		#endregion


		#region Multiply

		[TestCase("1231212478987482988429808779810457634781384756794987", 15,
			"747233429293018787918347987234564568", 10,
			"92000312286217574978643009574114545567010139156902666284589309.1880727173060570190220616", 25)]
		[TestCase("1231212478987482988429808779810457634781384756794987", -15,
			"747233429293018787918347987234564568", -10,
			"9.20003122862175749786430095741145455670101391569026662845893091880727173060570190220616E+111", -25,
			Description = "Multiply two numbers of negative scales")]
		[TestCase("1231212478987482988429808779810457634781384756794987", 10,
			"747233429293018787918347987234564568", -10,
			"920003122862175749786430095741145455670101391569026662845893091880727173060570190220616", 0,
			Description = "Multiply two numbers of different scales")]
		[TestCase("1231212478987482988429808779810457634781384756794987",-15,
			"747233429293018787918347987234564568", 10,
			"9.20003122862175749786430095741145455670101391569026662845893091880727173060570190220616E+91", -5,
			Description = "Multiply two numbers of different scales")]
		public void Multiply(string a, int aScale, string b, int bScale, string c, int cScale) {
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Multiply(bNumber);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(cScale, result.Scale, "incorrect scale");			
		}

		[TestCase("97665696756578755423325476545428779810457634781384756794987", -25,
			"87656965586786097685674786576598865", 10,
			"8.561078619600910561431314228543672720908E+108", -69,
			40, RoundingMode.HalfDown,
			Description = "Multiply two numbers of positive scales using MathContext")]
		[TestCase("987667796597975765768768767866756808779810457634781384756794987", 100,
			"747233429293018787918347987234564568", -70,
			"7.3801839465418518653942222612429081498248509257207477E+68", -16,
			53, RoundingMode.HalfUp,
			Description = "Multiply two numbers of different scales using MathContext")]
		[TestCase("488757458676796558668876576576579097029810457634781384756794987", -63,
			"747233429293018787918347987234564568", 63,
			"3.6521591193960361339707130098174381429788164316E+98", -52,
			47, RoundingMode.HalfUp,
			Description = "Multiply two numbers of different scales using MathContext")]
		public void MultiplyWithContext(string a, int aScale, string b, int bScale, string c, int cScale, int precision, RoundingMode roundingMode) {
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			MathContext mc = new MathContext(precision, roundingMode);
			BigDecimal result = aNumber.Multiply(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(cScale, result.Scale, "incorrect scale");			
		}

		#endregion

		#region Divide

		/**
		 * Divide by zero
		 */
		[Test]
		public void DivideByZero() {
			String a = "1231212478987482988429808779810457634781384756794987";
			int aScale = 15;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = BigDecimal.ValueOf(0L);
			Assert.Throws<ArithmeticException>(() => aNumber.Divide(bNumber), "ArithmeticException has not been caught");
		}

		/**
		 * Divide with ROUND_UNNECESSARY
		 */
		[Test]
		public void DivideExceptionRM() {
			String a = "1231212478987482988429808779810457634781384756794987";
			int aScale = 15;
			String b = "747233429293018787918347987234564568";
			int bScale = 10;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			try {
				aNumber.Divide(bNumber, RoundingMode.Unnecessary);
				Assert.Fail("ArithmeticException has not been caught");
			} catch (ArithmeticException e) {
				Assert.AreEqual("Rounding necessary", e.Message, "Improper exception message");
			}
		}

		/**
		 * Divide with invalid rounding mode
		 */
		[Test]
		public void DivideExceptionInvalidRM() {
			String a = "1231212478987482988429808779810457634781384756794987";
			int aScale = 15;
			String b = "747233429293018787918347987234564568";
			int bScale = 10;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			Assert.Throws<ArgumentException>(() => aNumber.Divide(bNumber, 100));
		}

		/**
		 * Divide: local variable exponent is less than zero
		 */
		[Test]
		public void DivideExpLessZero() {
			String a = "1231212478987482988429808779810457634781384756794987";
			int aScale = 15;
			String b = "747233429293018787918347987234564568";
			int bScale = 10;
			String c = "1.64770E+10";
			int resScale = -5;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Ceiling);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: local variable exponent is equal to zero
		 */
		[Test]
		public void DivideExpEqualsZero() {
			String a = "1231212478987482988429808779810457634781384756794987";
			int aScale = -15;
			String b = "747233429293018787918347987234564568";
			int bScale = 10;
			String c = "1.64769459009933764189139568605273529E+40";
			int resScale = -5;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Ceiling);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: local variable exponent is greater than zero
		 */
		[Test]
		public void DivideExpGreaterZero() {
			String a = "1231212478987482988429808779810457634781384756794987";
			int aScale = -15;
			String b = "747233429293018787918347987234564568";
			int bScale = 20;
			String c = "1.647694590099337641891395686052735285121058381E+50";
			int resScale = -5;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Ceiling);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: remainder is zero
		 */
		[Test]
		public void DivideRemainderIsZero() {
			String a = "8311389578904553209874735431110";
			int aScale = -15;
			String b = "237468273682987234567849583746";
			int bScale = 20;
			String c = "3.5000000000000000000000000000000E+36";
			int resScale = -5;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Ceiling);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_UP, result is negative
		 */
		[Test]
		public void DivideRoundUpNeg() {
			String a = "-92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "-1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Up);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_UP, result is positive
		 */
		[Test]
		public void DivideRoundUpPos() {
			String a = "92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Up);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_DOWN, result is negative
		 */
		[Test]
		public void DivideRoundDownNeg() {
			String a = "-92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "-1.24390557635720517122423359799283E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Down);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_DOWN, result is positive
		 */
		[Test]
		public void DivideRoundDownPos() {
			String a = "92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "1.24390557635720517122423359799283E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Down);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_FLOOR, result is positive
		 */
		[Test]
		public void DivideRoundFloorPos() {
			String a = "92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "1.24390557635720517122423359799283E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Floor);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_FLOOR, result is negative
		 */
		[Test]
		public void DivideRoundFloorNeg() {
			String a = "-92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "-1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Floor);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_CEILING, result is positive
		 */
		[Test]
		public void DivideRoundCeilingPos() {
			String a = "92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Ceiling);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_CEILING, result is negative
		 */
		[Test]
		public void DivideRoundCeilingNeg() {
			String a = "-92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "-1.24390557635720517122423359799283E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.Ceiling);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_UP, result is positive; distance = -1
		 */
		[Test]
		public void DivideRoundHalfUpPos() {
			String a = "92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfUp);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_UP, result is negative; distance = -1
		 */
		[Test]
		public void DivideRoundHalfUpNeg() {
			String a = "-92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "-1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfUp);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_UP, result is positive; distance = 1
		 */
		[Test]
		public void DivideRoundHalfUpPos1() {
			String a = "92948782094488478231212478987482988798104576347813847567949855464535634534563456";
			int aScale = -24;
			String b = "74723342238476237823754692930187879183479";
			int bScale = 13;
			String c = "1.2439055763572051712242335979928354832010167729111113605E+76";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfUp);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_UP, result is negative; distance = 1
		 */
		[Test]
		public void DivideRoundHalfUpNeg1() {
			String a = "-92948782094488478231212478987482988798104576347813847567949855464535634534563456";
			int aScale = -24;
			String b = "74723342238476237823754692930187879183479";
			int bScale = 13;
			String c = "-1.2439055763572051712242335979928354832010167729111113605E+76";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfUp);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_UP, result is negative; equidistant
		 */
		[Test]
		public void DivideRoundHalfUpNeg2() {
			String a = "-37361671119238118911893939591735";
			int aScale = 10;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			String c = "-1E+5";
			int resScale = -5;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfUp);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_DOWN, result is positive; distance = -1
		 */
		[Test]
		public void DivideRoundHalfDownPos() {
			String a = "92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfDown);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_DOWN, result is negative; distance = -1
		 */
		[Test]
		public void DivideRoundHalfDownNeg() {
			String a = "-92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "-1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfDown);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_DOWN, result is positive; distance = 1
		 */
		[Test]
		public void DivideRoundHalfDownPos1() {
			String a = "92948782094488478231212478987482988798104576347813847567949855464535634534563456";
			int aScale = -24;
			String b = "74723342238476237823754692930187879183479";
			int bScale = 13;
			String c = "1.2439055763572051712242335979928354832010167729111113605E+76";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfDown);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_DOWN, result is negative; distance = 1
		 */
		[Test]
		public void DivideRoundHalfDownNeg1() {
			String a = "-92948782094488478231212478987482988798104576347813847567949855464535634534563456";
			int aScale = -24;
			String b = "74723342238476237823754692930187879183479";
			int bScale = 13;
			String c = "-1.2439055763572051712242335979928354832010167729111113605E+76";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfDown);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_UP, result is negative; equidistant
		 */
		[Test]
		public void DivideRoundHalfDownNeg2() {
			String a = "-37361671119238118911893939591735";
			int aScale = 10;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			String c = "0E+5";
			int resScale = -5;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfDown);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_EVEN, result is positive; distance = -1
		 */
		[Test]
		public void DivideRoundHalfEvenPos() {
			String a = "92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfEven);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_EVEN, result is negative; distance = -1
		 */
		[Test]
		public void DivideRoundHalfEvenNeg() {
			String a = "-92948782094488478231212478987482988429808779810457634781384756794987";
			int aScale = -24;
			String b = "7472334223847623782375469293018787918347987234564568";
			int bScale = 13;
			String c = "-1.24390557635720517122423359799284E+53";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfEven);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_EVEN, result is positive; distance = 1
		 */
		[Test]
		public void DivideRoundHalfEvenPos1() {
			String a = "92948782094488478231212478987482988798104576347813847567949855464535634534563456";
			int aScale = -24;
			String b = "74723342238476237823754692930187879183479";
			int bScale = 13;
			String c = "1.2439055763572051712242335979928354832010167729111113605E+76";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfEven);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_EVEN, result is negative; distance = 1
		 */
		[Test]
		public void DivideRoundHalfEvenNeg1() {
			String a = "-92948782094488478231212478987482988798104576347813847567949855464535634534563456";
			int aScale = -24;
			String b = "74723342238476237823754692930187879183479";
			int bScale = 13;
			String c = "-1.2439055763572051712242335979928354832010167729111113605E+76";
			int resScale = -21;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfEven);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide: rounding mode is ROUND_HALF_EVEN, result is negative; equidistant
		 */
		[Test]
		public void DivideRoundHalfEvenNeg2() {
			String a = "-37361671119238118911893939591735";
			int aScale = 10;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			String c = "0E+5";
			int resScale = -5;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, resScale, RoundingMode.HalfEven);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide to BigDecimal
		 */
		[Test]
		public void DivideBigDecimal1() {
			String a = "-37361671119238118911893939591735";
			int aScale = 10;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			String c = "-5E+4";
			int resScale = -4;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * Divide to BigDecimal
		 */
		[Test]
		public void DivideBigDecimal2() {
			String a = "-37361671119238118911893939591735";
			int aScale = 10;
			String b = "74723342238476237823787879183470";
			int bScale = -15;
			String c = "-5E-26";
			int resScale = 26;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, scale, RoundingMode)
		 */
		[Test]
		public void DivideBigDecimalScaleRoundingModeUP() {
			String a = "-37361671119238118911893939591735";
			int aScale = 10;
			String b = "74723342238476237823787879183470";
			int bScale = -15;
			int newScale = 31;
			RoundingMode rm = RoundingMode.Up;
			String c = "-5.00000E-26";
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, newScale, rm);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(newScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, scale, RoundingMode)
		 */
		[Test]
		public void DivideBigDecimalScaleRoundingModeDOWN() {
			String a = "-37361671119238118911893939591735";
			int aScale = 10;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			int newScale = 31;
			RoundingMode rm = RoundingMode.Down;
			String c = "-50000.0000000000000000000000000000000";
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, newScale, rm);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(newScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, scale, RoundingMode)
		 */
		[Test]
		public void DivideBigDecimalScaleRoundingModeCEILING() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 100;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			int newScale = 45;
			RoundingMode rm = RoundingMode.Ceiling;
			String c = "1E-45";
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, newScale, rm);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(newScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, scale, RoundingMode)
		 */
		[Test]
		public void DivideBigDecimalScaleRoundingModeFLOOR() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 100;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			int newScale = 45;
			RoundingMode rm = RoundingMode.Floor;
			String c = "0E-45";
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, newScale, rm);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(newScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, scale, RoundingMode)
		 */
		[Test]
		public void DivideBigDecimalScaleRoundingModeHALF_UP() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = -51;
			String b = "74723342238476237823787879183470";
			int bScale = 45;
			int newScale = 3;
			RoundingMode rm = RoundingMode.HalfUp;
			String c = "50000260373164286401361913262100972218038099522752460421" +
					   "05959924024355721031761947728703598332749334086415670525" +
					   "3761096961.670";
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, newScale, rm);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(newScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, scale, RoundingMode)
		 */
		[Test]
		public void DivideBigDecimalScaleRoundingModeHALF_DOWN() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 5;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			int newScale = 7;
			RoundingMode rm = RoundingMode.HalfDown;
			String c = "500002603731642864013619132621009722.1803810";
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, newScale, rm);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(newScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, scale, RoundingMode)
		 */
		[Test]
		public void DivideBigDecimalScaleRoundingModeHALF_EVEN() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 5;
			String b = "74723342238476237823787879183470";
			int bScale = 15;
			int newScale = 7;
			RoundingMode rm = RoundingMode.HalfEven;
			String c = "500002603731642864013619132621009722.1803810";
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, newScale, rm);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(newScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideBigDecimalScaleMathContextUP() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 15;
			String b = "748766876876723342238476237823787879183470";
			int bScale = 10;
			int precision = 21;
			RoundingMode rm = RoundingMode.Up;
			MathContext mc = new MathContext(precision, rm);
			String c = "49897861180.2562512996";
			int resScale = 10;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideBigDecimalScaleMathContextDOWN() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 15;
			String b = "748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 21;
			RoundingMode rm = RoundingMode.Down;
			MathContext mc = new MathContext(precision, rm);
			String c = "4.98978611802562512995E+70";
			int resScale = -50;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideBigDecimalScaleMathContextCEILING() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 15;
			String b = "748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 21;
			RoundingMode rm = RoundingMode.Ceiling;
			MathContext mc = new MathContext(precision, rm);
			String c = "4.98978611802562512996E+70";
			int resScale = -50;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideBigDecimalScaleMathContextFLOOR() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 15;
			String b = "748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 21;
			RoundingMode rm = RoundingMode.Floor;
			MathContext mc = new MathContext(precision, rm);
			String c = "4.98978611802562512995E+70";
			int resScale = -50;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideBigDecimalScaleMathContextHALF_UP() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 21;
			RoundingMode rm = RoundingMode.HalfUp;
			MathContext mc = new MathContext(precision, rm);
			String c = "2.77923185514690367475E+26";
			int resScale = -6;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideBigDecimalScaleMathContextHALF_DOWN() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 21;
			RoundingMode rm = RoundingMode.HalfDown;
			MathContext mc = new MathContext(precision, rm);
			String c = "2.77923185514690367475E+26";
			int resScale = -6;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divide(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideBigDecimalScaleMathContextHALF_EVEN() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 21;
			RoundingMode rm = RoundingMode.HalfEven;
			MathContext mc = new MathContext(precision, rm);
			String c = "2.77923185514690367475E+26";
			int resScale = -6;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Divide(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}


		/**
		 * BigDecimal.divide with a scale that's too large
		 * 
		 * Regression  for HARMONY-6271
		 */
		[Test]
		public void DivideLargeScale() {
			BigDecimal arg1 = BigDecimal.Parse("320.0E+2147483647");
			BigDecimal arg2 = BigDecimal.Parse("6E-2147483647");
			try {
				BigDecimal result = arg1.Divide(arg2, Int32.MaxValue, RoundingMode.Ceiling);
				Assert.Fail("Expected ArithmeticException when dividing with a scale that's too large");
			} catch (ArithmeticException e) {
				// expected behaviour
			}
		}

		/**
		 * divideToIntegralValue(BigDecimal)
		 */
		[Test]
		public void DivideToIntegralValue() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			String c = "277923185514690367474770683";
			int resScale = 0;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.DivideToIntegralValue(bNumber);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divideToIntegralValue(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideToIntegralValueMathContextUP() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 32;
			RoundingMode rm = RoundingMode.Up;
			MathContext mc = new MathContext(precision, rm);
			String c = "277923185514690367474770683";
			int resScale = 0;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.DivideToIntegralValue(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divideToIntegralValue(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideToIntegralValueMathContextDOWN() {
			String a = "3736186567876876578956958769675785435673453453653543654354365435675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 75;
			RoundingMode rm = RoundingMode.Down;
			MathContext mc = new MathContext(precision, rm);
			String c = "2.7792318551469036747477068339450205874992634417590178670822889E+62";
			int resScale = -1;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.DivideToIntegralValue(bNumber, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * divideAndRemainder(BigDecimal)
		 */
		[Test]
		public void DivideAndRemainder1() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			String res = "277923185514690367474770683";
			int resScale = 0;
			String rem = "1.3032693871288309587558885943391070087960319452465789990E-15";
			int remScale = 70;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal remainder;
			BigDecimal quotient = aNumber.DivideAndRemainder(bNumber, out remainder);
			Assert.AreEqual(res, quotient.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, quotient.Scale, "incorrect quotient scale");
			Assert.AreEqual(rem, remainder.ToString(), "incorrect remainder value");
			Assert.AreEqual(remScale, remainder.Scale, "incorrect remainder scale");
		}

		/**
		 * divideAndRemainder(BigDecimal)
		 */
		[Test]
		public void DivideAndRemainder2() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = -45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			String res = "2779231855146903674747706830969461168692256919247547952" +
						 "2608549363170374005512836303475980101168105698072946555" +
						 "6862849";
			int resScale = 0;
			String rem = "3.4935796954060524114470681810486417234751682675102093970E-15";
			int remScale = 70;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal remainder;
			BigDecimal quotient = aNumber.DivideAndRemainder(bNumber, out remainder);
			Assert.AreEqual(res, quotient.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, quotient.Scale, "incorrect quotient scale");
			Assert.AreEqual(rem, remainder.ToString(), "incorrect remainder value");
			Assert.AreEqual(remScale, remainder.Scale, "incorrect remainder scale");
		}

		/**
		 * divideAndRemainder(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideAndRemainderMathContextUP() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 70;
			int precision = 75;
			RoundingMode rm = RoundingMode.Up;
			MathContext mc = new MathContext(precision, rm);
			String res = "277923185514690367474770683";
			int resScale = 0;
			String rem = "1.3032693871288309587558885943391070087960319452465789990E-15";
			int remScale = 70;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal remainder;
			BigDecimal quotient = aNumber.DivideAndRemainder(bNumber, mc, out remainder);
			Assert.AreEqual(res, quotient.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, quotient.Scale, "incorrect quotient scale");
			Assert.AreEqual(rem, remainder.ToString(), "incorrect remainder value");
			Assert.AreEqual(remScale, remainder.Scale, "incorrect remainder scale");
		}

		/**
		 * divideAndRemainder(BigDecimal, MathContext)
		 */
		[Test]
		public void DivideAndRemainderMathContextDOWN() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 20;
			int precision = 15;
			RoundingMode rm = RoundingMode.Down;
			MathContext mc = new MathContext(precision, rm);
			String res = "0E-25";
			int resScale = 25;
			String rem = "3736186567876.876578956958765675671119238118911893939591735";
			int remScale = 45;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal remainder;
			BigDecimal quotient = aNumber.DivideAndRemainder(bNumber, mc, out remainder);
			Assert.AreEqual(res, quotient.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, quotient.Scale, "incorrect quotient scale");
			Assert.AreEqual(rem, remainder.ToString(), "incorrect remainder value");
			Assert.AreEqual(remScale, remainder.Scale, "incorrect remainder scale");
		}

		#endregion

		#region Pow

		[TestCase("123121247898748298842980", 10, 10, "8004424019039195734129783677098845174704975003788210729597" +
					   "4875206425711159855030832837132149513512555214958035390490" +
					   "798520842025826.594316163502809818340013610490541783276343" +
					   "6514490899700151256484355936102754469438371850240000000000", 100,
					   Description = "Pow(n) operation")]
		[TestCase("123121247898748298842980", 10, 0, "1", 0, Description = "Pow(0)")]
		[TestCase("0", 0, 0, "1", 0, Description = "Zero.Pow(0)")]
		public void Pow(string a, int aScale, int exp, string c, int cScale) {
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal result = aNumber.Pow(exp);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(cScale, result.Scale, "incorrect scale");			
		}

		[TestCase("123121247898748298842980", 10, 10, "8.0044E+130", -126, 5, RoundingMode.HalfUp)]
		public void PowWithContext(string a, int aScale, int exp, string c, int cScale, int precision, RoundingMode roundingMode) {
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			MathContext mc = new MathContext(precision, roundingMode);
			BigDecimal result = aNumber.Pow(exp, mc);
			Assert.AreEqual(c, result.ToString(), "incorrect value");
			Assert.AreEqual(cScale, result.Scale, "incorrect scale");
		}

		#endregion

		/**
		 * remainder(BigDecimal)
		 */
		[Test]
		public void Remainder1() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 10;
			String res = "3736186567876.876578956958765675671119238118911893939591735";
			int resScale = 45;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Remainder(bNumber);
			Assert.AreEqual(res, result.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, result.Scale, "incorrect quotient scale");
		}

		/**
		 * remainder(BigDecimal)
		 */
		[Test]
		public void Remainder2() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = -45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 10;
			String res = "1149310942946292909508821656680979993738625937.2065885780";
			int resScale = 10;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Remainder(bNumber);
			Assert.AreEqual(res, result.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, result.Scale, "incorrect quotient scale");
		}

		/**
		 * remainder(BigDecimal, MathContext)
		 */
		[Test]
		public void RemainderMathContextHALF_UP() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 10;
			int precision = 15;
			RoundingMode rm = RoundingMode.HalfUp;
			MathContext mc = new MathContext(precision, rm);
			String res = "3736186567876.876578956958765675671119238118911893939591735";
			int resScale = 45;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Remainder(bNumber, mc);
			Assert.AreEqual(res, result.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, result.Scale, "incorrect quotient scale");
		}

		/**
		 * remainder(BigDecimal, MathContext)
		 */
		[Test]
		public void RemainderMathContextHALF_DOWN() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = -45;
			String b = "134432345432345748766876876723342238476237823787879183470";
			int bScale = 10;
			int precision = 75;
			RoundingMode rm = RoundingMode.HalfDown;
			MathContext mc = new MathContext(precision, rm);
			String res = "1149310942946292909508821656680979993738625937.2065885780";
			int resScale = 10;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal bNumber = new BigDecimal(BigInteger.Parse(b), bScale);
			BigDecimal result = aNumber.Remainder(bNumber, mc);
			Assert.AreEqual(res, result.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, result.Scale, "incorrect quotient scale");
		}

		/**
		 * round(BigDecimal, MathContext)
		 */
		[Test]
		public void RoundMathContextHALF_DOWN() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = -45;
			int precision = 75;
			RoundingMode rm = RoundingMode.HalfDown;
			MathContext mc = new MathContext(precision, rm);
			String res = "3.736186567876876578956958765675671119238118911893939591735E+102";
			int resScale = -45;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal result = aNumber.Round(mc);
			Assert.AreEqual(res, result.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, result.Scale, "incorrect quotient scale");
		}

		/**
		 * round(BigDecimal, MathContext)
		 */
		[Test]
		public void RoundMathContextHALF_UP() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			int precision = 15;
			RoundingMode rm = RoundingMode.HalfUp;
			MathContext mc = new MathContext(precision, rm);
			String res = "3736186567876.88";
			int resScale = 2;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal result = aNumber.Round(mc);
			Assert.AreEqual(res, result.ToString(), "incorrect quotient value");
			Assert.AreEqual(resScale, result.Scale, "incorrect quotient scale");
		}

		/**
		 * round(BigDecimal, MathContext) when precision = 0
		 */
		[Test]
		public void RoundMathContextPrecision0() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			int precision = 0;
			RoundingMode rm = RoundingMode.HalfUp;
			MathContext mc = new MathContext(precision, rm);
			String res = "3736186567876.876578956958765675671119238118911893939591735";
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal result = aNumber.Round(mc);
			Assert.AreEqual(res, result.ToString(), "incorrect quotient value");
			Assert.AreEqual(aScale, result.Scale, "incorrect quotient scale");
		}


		/**
		 * ulp() of a positive BigDecimal
		 */
		[Test]
		public void UlpPos() {
			String a = "3736186567876876578956958765675671119238118911893939591735";
			int aScale = -45;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal result = aNumber.Ulp();
			String res = "1E+45";
			int resScale = -45;
			Assert.AreEqual(res, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * ulp() of a negative BigDecimal
		 */
		[Test]
		public void UlpNeg() {
			String a = "-3736186567876876578956958765675671119238118911893939591735";
			int aScale = 45;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal result = aNumber.Ulp();
			String res = "1E-45";
			int resScale = 45;
			Assert.AreEqual(res, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}

		/**
		 * ulp() of a negative BigDecimal
		 */
		[Test]
		public void UlpZero() {
			String a = "0";
			int aScale = 2;
			BigDecimal aNumber = new BigDecimal(BigInteger.Parse(a), aScale);
			BigDecimal result = aNumber.Ulp();
			String res = "0.01";
			int resScale = 2;
			Assert.AreEqual(res, result.ToString(), "incorrect value");
			Assert.AreEqual(resScale, result.Scale, "incorrect scale");
		}
	}
}