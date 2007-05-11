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
	///  MSNMessageInfo, represents a MSN message entity.
	/// </summary>
	internal class MSNMessageInfo:MSNBaseMessage
	{
		#region Construction
		public MSNMessageInfo()
		{
			m_strFromUsers=new ArrayList();
			m_strToUsers=new ArrayList();
		}
		#endregion
		
		#region Private Members
		/// <summary>
		/// From Users in MSN message.
		/// </summary>
		private ArrayList m_strFromUsers;

		/// <summary>
		/// To users in MSN messages.
		/// </summary>
		private ArrayList m_strToUsers;

#endregion

		#region Public Properties
		/// <summary>
		/// From users.
		/// </summary>
		public ArrayList FromUsers
		{
			get
			{
				return m_strFromUsers;
			}
			set
			{
				m_strFromUsers=value;
			}
		}

		/// <summary>
		/// To users
		/// </summary>
		public ArrayList ToUsers
		{
			get
			{
				return m_strToUsers;
			}
			set
			{
				m_strToUsers=value;
			}
		}
		#endregion
	}
}
