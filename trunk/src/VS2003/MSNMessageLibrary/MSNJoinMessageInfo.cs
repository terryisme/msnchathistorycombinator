using System;

namespace MSN.Core.Message
{
	/// <summary>
	/// Summary description for MSNJoinMessageInfo.
	/// </summary>
	internal class MSNJoinMessageInfo:MSNBaseMessage
	{
		/// <summary>
		/// Construction
		/// </summary>
		public MSNJoinMessageInfo()
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
