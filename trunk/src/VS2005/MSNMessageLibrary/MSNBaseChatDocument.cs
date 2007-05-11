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
using System.Collections;
namespace MSN.Core.Message
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
