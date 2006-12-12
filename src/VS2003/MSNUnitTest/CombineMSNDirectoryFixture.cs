using System;
using NUnit;
using NUnit.Core;
using NUnit.Framework;
using MSN.Core;
using MSN.Core.Message;
namespace MSN.UnitTest
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
			MSNFILESTRUCT path1=new MSNFILESTRUCT();
			path1.Format=MSNChatHistoryFormat.MSN;
			path1.Path=@"E:\Work\MSN\Test\msn1";
			path1.SourceType=MSNSourceType.Directory;

			MSNFILESTRUCT path2=new MSNFILESTRUCT();
			path2.Format=MSNChatHistoryFormat.MSN;
			path2.Path=@"E:\Work\MSN\Test\msn";
			path2.SourceType=MSNSourceType.Directory;

			MSNFILESTRUCT savePath=new MSNFILESTRUCT();
			savePath.Format=MSNChatHistoryFormat.MSN;
			savePath.Path=@"E:\Work\MSN\Test\msn-combine";
			savePath.SourceType=MSNSourceType.Directory;

												  
			MSN.Core.CombineMSNDirectory combine=
				new CombineMSNDirectory(path1,path2,savePath, @"E:\Work\MSN\Test\msn1\MessageLog.xsl");
        combine.OnSetProgressText=new MSN.Core.MSNDocumentCombine.SetProgressText(hello);
			combine.Process();
		}

		[Test]
		public void TestCombineBoth()
		{
			MSNFILESTRUCT path1=new MSNFILESTRUCT();
			path1.Format=MSNChatHistoryFormat.MSN;
			path1.Path=@"E:\Work\MSN\Test\msn1";
			path1.SourceType=MSNSourceType.Directory;

			MSNFILESTRUCT path2=new MSNFILESTRUCT();
			path2.Format=MSNChatHistoryFormat.MSN;
			path2.Path=@"E:\Work\MSN\Test\msn\abeen_82983864523236.xml";
			path2.SourceType=MSNSourceType.File;

			MSNFILESTRUCT savePath=new MSNFILESTRUCT();
			savePath.Format=MSNChatHistoryFormat.MSN;
			savePath.Path=@"E:\Work\MSN\Test\msn-combine";
			savePath.SourceType=MSNSourceType.Directory;

												  
			MSN.Core.CombineMSNDirectory combine=
				new CombineMSNDirectory(path1,path2,savePath, @"E:\Work\MSN\Test\msn1\MessageLog.xsl");

            combine.OnSetProgressText=new MSN.Core.MSNDocumentCombine.SetProgressText(hello);
			combine.Process();
		}

		[Test]
		public void TestCombineFile()
		{
			MSNFILESTRUCT path1=new MSNFILESTRUCT();
			path1.Format=MSNChatHistoryFormat.MSN;
			path1.Path=@"E:\Work\MSN\Test\msn1\abeen_82983864523236.xml";
			path1.SourceType=MSNSourceType.File;

			MSNFILESTRUCT path2=new MSNFILESTRUCT();
			path2.Format=MSNChatHistoryFormat.MSN;
			path2.Path=@"E:\Work\MSN\Test\msn\abeen_82983864523236.xml";
			path2.SourceType=MSNSourceType.File;

			MSNFILESTRUCT savePath=new MSNFILESTRUCT();
			savePath.Format=MSNChatHistoryFormat.MSN;
			savePath.Path=@"E:\Work\MSN\Test\msn-combine\abeen_82983864523236.xml";
			savePath.SourceType=MSNSourceType.File;

												  
			MSN.Core.CombineMSNDirectory combine=
				new CombineMSNDirectory(path1,path2,savePath, @"E:\Work\MSN\Test\msn1\MessageLog.xsl");

			combine.OnSetProgressText=new MSN.Core.MSNDocumentCombine.SetProgressText(hello);
			combine.Process();
		}
		public void hello(string s)
		{

		}
	}
}
