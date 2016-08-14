using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace VincentUnityTest
{
	[TestFixture]
	public class SampleTests {
		[Test]
		public void EqualTest() {
			Assert.AreEqual(1, 2);
		}
	}
}