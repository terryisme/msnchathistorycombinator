using System;

namespace MSN.Core.Message
{
	/// <summary>
	/// Summary description for MSNUserInfo.
	/// </summary>
	internal class MSNUserInfo
	{
		public MSNUserInfo()
		{
			
		}
		public MSNUserInfo(string friendlyName)
		{
			m_strFriendlyName=friendlyName;
		}
		private string m_strFriendlyName="";
		public string FriendlyName
		{
			get
			{
				return m_strFriendlyName;
			}
			set
			{
				m_strFriendlyName=value;
			}
		}
	}
}
