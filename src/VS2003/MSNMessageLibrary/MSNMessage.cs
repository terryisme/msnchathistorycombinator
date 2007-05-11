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
