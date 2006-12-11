using System;

namespace MSNMessageLibrary
{
	/// <summary>
	/// Summary description for MSNLeaveMessageInfo.
	/// </summary>
	internal class MSNLeaveMessageInfo:MSNBaseMessage
	{
		/// <summary>
		/// Construction
		/// </summary>
		public MSNLeaveMessageInfo()
		{
		}
		private MSNUserInfo m_user=new MSNUserInfo();

		/// <summary>
		/// User
		/// </summary>
		public MSNUserInfo User
		{
			get
			{
				return m_user;
			}
			set
			{
				m_user=value;
			}
		}
	}
}
