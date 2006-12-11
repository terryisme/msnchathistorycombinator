using System;

namespace MSNMessageLibrary
{
	/// <summary>
	/// Summary description for MSNMessageTextInfo.
	/// </summary>
	internal class MSNMessageTextInfo
	{
		/// <summary>
		/// Construction
		/// </summary>
		public MSNMessageTextInfo()
		{
		}

		/// <summary>
		/// Message text.
		/// </summary>
		private string m_strText="";

		/// <summary>
		/// Message style.
		/// </summary>
		private string m_strStyle="";

		/// <summary>
		/// MSN message text.
		/// </summary>
		public string Text
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
		/// Message style.
		/// </summary>
		public string Style
		{
			get
			{
				return m_strStyle;
			}
			set
			{
				m_strStyle=value;
			}
		}
	}
}
