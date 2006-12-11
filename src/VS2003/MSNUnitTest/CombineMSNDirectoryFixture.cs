using System;
using NUnit;
using NUnit.Core;
using NUnit.Framework;
using MSNChatCombinator;
namespace MSNUnitTest
{
	/// <summary>
	/// CombineMSNDirectoryFixture is to test <c>CombineMSNDirectoryFixture</c>.
	/// </summary>
	
	[TestFixture]
	public class CombineMSNDirectoryFixture
	{
		private string filePath="";
		private string dirPath1="";
		private string dirPath2="";

		public CombineMSNDirectoryFixture()
		{
		
		}

		/// <summary>
		/// To  test source type
		/// </summary>
		[Test]
		public void TestDigSourceType()
		{
			CombineMSNDirectory combineMSN=new CombineMSNDirectory(dirPath1,dirPath2);
			Assert.AreEqual( combineMSN.DigSourceType(@"C:"),MSNSourceType.Directory);
			Assert.AreEqual( combineMSN.DigSourceType(@"C\:"),MSNSourceType.Directory);
			Assert.AreEqual( combineMSN.DigSourceType(@"C\:12.txt"),MSNSourceType.File);
			Assert.AreEqual( combineMSN.DigSourceType(@"C\:12.txt.txt"),MSNSourceType.File);

		}
	}
}
