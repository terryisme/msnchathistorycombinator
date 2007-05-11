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
