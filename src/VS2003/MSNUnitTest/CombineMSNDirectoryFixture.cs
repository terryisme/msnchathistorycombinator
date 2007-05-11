/*
  Copyright (C) 2006, 2007 Confach Zhang

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

  You should have received a copy of the GNU Lesser General Public
  License along with this library; if not, write to the Free Software
  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

/*
 * Authors: Confach Zhang <confach@gmail.com>
 *                 URL:http://confach.cnblogs.com Or http://www.36sign.com
*/
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
