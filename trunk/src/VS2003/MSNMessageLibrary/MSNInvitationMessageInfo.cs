using System;
using System.Collections;

namespace MSNMessageLibrary
{
	/// <summary>
	///MSNInvitationMessageInfo class represents a  MSN invitation message
	/// </summary>
	internal class MSNInvitationMessageInfo:MSNBaseMessage
	{
		/// <summary>
		/// Construction
		/// </summary>
		public MSNInvitationMessageInfo()
		{
		}

		private string m_strApplication=string.Empty;
		private string m_strFile=string.Empty;
		/// <summary>
		/// From Users in MSN message.
		/// </summary>
		private ArrayList m_strFromUsers;

		/// <summary>
		/// The application in Invitation message. such as 
		/// <c><Application> ”∆µ∂‘ª∞</Application></c>
		/// </summary>
		public string Application
		{
			get
			{
				return this.m_strApplication;
			}
			set
			{
			   this.m_strApplication=value;
			}
		}

		/// <summary>
		/// File in Invitation Message. Such as <File>P1010035.JPG</File>
		/// </summary>
		public string File
		{
			get
			{
				return m_strFile;
			}
			set
			{
				m_strFile=value;
			}
		}

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
	}
}
