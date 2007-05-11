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
	///  MSNChatDocumentGaimHTML is a class  to process Gaim file with HTML format.
	/// </summary>
	internal class MSNChatDocumentGaimHTML:MSNChatDocumentGaimPlainText
	{
		private string m_strGaimPath;

		/// <summary>
		/// Class construction.
		/// </summary>
		/// <param name="gaimLogPath">Gaim chat history file path.</param>
		public MSNChatDocumentGaimHTML(string gaimLogPath):base(gaimLogPath)
		{
			
		}

		/// <summary>
		/// This methods is to read the gaim chat history file.
		/// </summary>
		/// <param name="path">Chat history file path.</param>
		protected override void ReadGaimFile(string path)
		{

		}
	}
}
