using System;
using System.Collections;

namespace MSNMessageLibrary
{
	/// <summary>
	/// Summary description for MSNLogInfo.
	/// </summary>
	public class MSNLogInfo
	{
		public MSNLogInfo()
		{
		}

		private int m_nFirstSessionID=-1;
		private int m_nLastSessionID=-1;

		private SortedList  m_listMessages=new SortedList() ;

		public int FirstSessionID
		{
			get
			{
				return m_nFirstSessionID;
			}
			set
			{
				m_nFirstSessionID=value;
			}
		}

		public int LastSessionID
		{
			get
			{
				return m_nLastSessionID;
			}
			set
			{
				m_nLastSessionID=value;
			}
		}

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
	}
}
