using System;

namespace MSN.Core.Message
{
	/// <summary>
	/// Summary description for MSNMessage.
	/// </summary>
	internal class MSNBaseMessage
	{
	
		#region Construction
		/// <summary>
		/// Construction.
		/// </summary>
		public MSNBaseMessage()
		{
			
		}
		#endregion
		
		#region Private Members
		
		/// <summary>
		/// Session ID for each MSN message.
		/// </summary>
		private int m_nSessionID=-1;

		/// <summary>
		/// Date time
		/// </summary>
		private DateTime m_dtDateTime=DateTime.Now;

		/// <summary>
		/// Message text.
		/// </summary>
		private MSNMessageTextInfo m_strText=new MSNMessageTextInfo();

		/// <summary>
		///The file path MSN message located 
		/// </summary>
		private string m_strPath="";

		#endregion

		#region Public Properties
		/// <summary>
		/// Session ID.
		/// </summary>
		public int SessionID
		{
			get
			{
				return m_nSessionID;
			}
			set
			{
				m_nSessionID=value;
			}
		}

		/// <summary>
		/// Date time Message On.
		/// </summary>
		public DateTime DateTimeOn
		{
			get
			{
				return m_dtDateTime;
			}
			set
			{
				m_dtDateTime=value;
			}
		}


		/// <summary>
		/// Message text.
		/// </summary>
		public MSNMessageTextInfo Text
		{
			get
			{
				return m_strText;
			}
			set
			{
				m_strText=value;
			}
		}

		/// <summary>
		/// File path.
		/// </summary>
		public string FilePath
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
		#endregion
	}
}
