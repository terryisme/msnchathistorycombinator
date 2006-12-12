using System;
using System.Collections;

namespace MSN.Core.Message
{
	/// <summary>
	/// Summary description for Session.
	/// </summary>
	internal class MSNSession
	{
		#region Private Members
		private SortedList m_slSrc=new  SortedList();
		private SortedList m_slNew=new SortedList();
		private MSNBaseMessage pre;
		private MSNBaseMessage me;
#endregion

		#region Construction

		/// <summary>
		/// Construction.
		/// </summary>
		public MSNSession()
		{
		}


		/// <summary>
		/// Construction.
		/// </summary>
		/// <param name="src">The MSN messages </param>
		public MSNSession(SortedList src)
		{
			m_slSrc=src;
		}

		#endregion

		/// <summary>
		/// MSN messages source.
		/// </summary>
		public SortedList MessagesSource
		{
			get
			{
				//return  m_slNew;
				return m_slSrc;
			}
			set
			{
				m_slSrc=value;
			}
		}
		
		
		/// <summary>
		/// Generate Session ID
		/// </summary>
		public void Generate()
		{
			//if no MSN message, return
			if(m_slSrc==null) return;

			//If only one MSN message, it is necessary to not to do it.
			if(m_slSrc.Count==1) return;

			int nSessionID=1;
			int nOldSessionID=0;

			//There are more than 1 MSN messages
			for(int index=0;index<m_slSrc.Count;index++)
			{
				me=new MSNBaseMessage();
				me=m_slSrc.GetByIndex(index) as MSNBaseMessage;

				if(index==0) 
				{	
					nOldSessionID=me.SessionID;
					me.SessionID=1;
					nSessionID=1;
					
				}
				else
				{
					pre=new MSNBaseMessage();         
					pre=( MSNBaseMessage)(m_slSrc.GetByIndex(index-1));			

					if(me.SessionID==nOldSessionID&&me.FilePath.Equals(pre.FilePath))
					{
						me.SessionID=nSessionID;
					}
					else
					{
						nOldSessionID=me.SessionID;
						me.SessionID=nSessionID+1;
						nSessionID++;
					}
				}

			}

		}
	}
}
