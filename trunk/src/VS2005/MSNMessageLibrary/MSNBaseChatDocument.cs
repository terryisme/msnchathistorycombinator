using System;
using System.Collections;
namespace MSNMessageLibrary
{
	/// <summary>
	/// MSNBaseChatDocument, is a base MSN chat document class.
	/// </summary>
	internal abstract class MSNBaseChatDocument
	{
		private SortedList  m_listMessages=new SortedList() ;
		private string m_strPath=string.Empty;
		private MSNChatHistoryFormat m_format=MSNChatHistoryFormat.MSN;
		/// <summary>
		/// MSN chat history file path.
		/// </summary>
		public string Path
		{
			get
			{
				return m_strPath;
			}
			set
			{
				m_strPath=value;
			}
		}


		/// <summary>
		/// MSNBaseChatDocument construction
		/// </summary>
		public MSNBaseChatDocument()
		{
			
		}
      
		/// <summary>
		/// Load the history document file.
		/// </summary>
		public abstract void Load();

		/// <summary>
		/// All MSN messages.
		/// </summary>
		public SortedList MSNMessages
		{
			get
			{
				return m_listMessages;
			}
			set
			{
				m_listMessages=value;
			}
		}

		/// <summary>
		/// MSN chat history format.
		/// </summary>
		public MSNChatHistoryFormat Format
		{
			get
			{

				return m_format;
			}
			set
			{

				m_format=value;
			}
		}

		/// <summary>
		/// Do instance
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public static MSNBaseChatDocument DoInstance(MSNFILESTRUCT file)
		{
			switch (file.Format)
			{
				case MSNChatHistoryFormat.MSN:
					 return new MSNChatDocumentMicrosoft(file.Path);	
				case MSNChatHistoryFormat.GaimHTML:
				case MSNChatHistoryFormat.GaimPlainText:
					return new MSNChatDocumentGaimPlainText(file.Path);
		
		       default:
					 return  new MSNChatDocumentMicrosoft(file.Path);		
			}
		}
	}

	
}
