using System;
using NUnit;
using NUnit.Core;
using NUnit.Framework;
using MSNChatCombinator;
using MSNMessageLibrary;
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
		public void TestCombineDirecotry()
		{
			MSNChatCombinator.CombineMSNDirectory combine=
				new CombineMSNDirectory( @"E:\Work\MSN\Test\msn1",MSNSourceType.Directory,
				                                                    @"E:\Work\MSN\Test\msn",MSNSourceType.Directory,
				                                                   @"E:\Work\MSN\Test\msn-combine",
				                                                    @"E:\Work\MSN\Test\msn1\MessageLog.xsl");
			combine.Process();
		}
	}
}
