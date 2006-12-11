using System;
using System.Collections;
namespace MSNMessageLibrary
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
