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
	/// The constant of every style
	/// </summary>
	public struct Style
	{
		/// <summary>
		/// Default text style
		/// </summary>
		public const string DEFAULT_TEXT_STYLE="font-family:ËÎÌו; color:#000000; ";
	}

	/// <summary>
	/// MSN Chat history format 
	/// </summary>
	public enum MSNChatHistoryFormat:int
	{
		/// <summary>
		/// MSN
		/// </summary>
		MSN=0,

		/// <summary>
		/// Gaim Plain Text
		/// </summary>
		GaimPlainText=1,

		/// <summary>
		/// Gaim  HTML
		/// </summary>
		GaimHTML=2
	}

	/// <summary>
	/// Indicates MSN source type.
	/// </summary>
	public enum MSNSourceType
	{
		/// <summary>
		/// Directory
		/// </summary>
		Directory,

		/// <summary>
		/// File
		/// </summary>
		File
	}
}
