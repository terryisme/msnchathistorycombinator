using System;

namespace MSN.Core.Message
{
	/// <summary>
	///  MSNChatDocumentGaimHTML is a class  to process Gaim file with HTML format.
	/// </summary>
	internal class MSNChatDocumentGaimHTML:MSNChatDocumentGaimPlainText
	{
		private string m_strGaimPath;

		/// <summary>
		/// Class construction.
		/// </summary>
		/// <param name="gaimLogPath">Gaim chat history file path.</param>
		public MSNChatDocumentGaimHTML(string gaimLogPath):base(gaimLogPath)
		{
			
		}

		/// <summary>
		/// This methods is to read the gaim chat history file.
		/// </summary>
		/// <param name="path">Chat history file path.</param>
		protected override void ReadGaimFile(string path)
		{

		}
	}
}
