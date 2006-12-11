using System;

namespace MSNMessageLibrary
{
	/// <summary>
	/// Summary description for MSNChatDocumentGaimHTML.
	/// </summary>
	internal class MSNChatDocumentGaimHTML:MSNChatDocumentGaimPlainText
	{
		private string m_strGaimPath;

		public MSNChatDocumentGaimHTML(string gaimLogPath):base(gaimLogPath)
		{
			
		}

		protected override void ReadGaimFile(string path)
		{

		}
	}
}
