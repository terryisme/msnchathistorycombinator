using System;
using System.Collections;
using System.Data;
using System.Xml;
using System.Xml.Xsl;
using System.Globalization;
namespace MSNMessageLibrary
{
	/// <summary>
	/// Summary description for MSNChatDocument.
	/// </summary>
	internal class MSNChatDocumentMicrosoft:MSNBaseChatDocument
	{
		#region Construction
		/// <summary>
		/// Construction.
		/// </summary>
		public MSNChatDocumentMicrosoft()
		{
		}

		/// <summary>
		/// Construction.
		/// </summary>
		///<param name="path">The path of MSN chat history file.</param>
		public MSNChatDocumentMicrosoft(string path)
		{
			this.Path=path;

		}

		#endregion
		
		#region Private members

		private int m_nFirstSessionID=-1;
		private int m_nLastSessionID=-1;
		
		
		private string m_strDeclaration=string.Empty;
		private string m_strStyleSheet=string.Empty;
		
#endregion
		
		#region  Public Properties

		/// <summary>
		/// MSN chat first session id.
		/// </summary>
		public int FirstSessionID
		{
			get
			{
				return m_nFirstSessionID;
			}
			set
			{
				m_nFirstSessionID=value;
			}
		}


		/// <summary>
		/// MSN chat last session id.
		/// </summary>
		public int LastSessionID
		{
			get
			{
				return m_nLastSessionID;
			}
			set
			{
				m_nLastSessionID=value;
			}
		}


		/// <summary>
		/// MSN file declaration.
		/// </summary>
		public string Declaration
		{
			get
			{
				return m_strDeclaration;
			}
			set
			{
				m_strDeclaration=value;
			}
		}


		/// <summary>
		/// Style sheet
		/// </summary>
		public string StyleSheet
		{
			get
			{
				return m_strStyleSheet;
			}
			set
			{
				m_strStyleSheet=value;
			}
		}


		
#endregion
		
		#region Public Methods
		/// <summary>
		/// Load the MSN chat history file. and read each MSN chat message item into List
		/// </summary>
		public override void Load()
		{
			XmlDocument xmlDoc=new XmlDocument();
			XmlTextReader reader=null;
		//	try
			{
				//Load the reader with the XML file.
				reader = new XmlTextReader(this.Path);
  				xmlDoc.Load(reader);
				
				XmlElement element=xmlDoc.DocumentElement;			
				if(element==null) return;

				//get the Log element first and last session ID.
				if(element.Name.Equals("Log"))
				{
					this.m_nFirstSessionID=Convert.ToInt32(element.Attributes["FirstSessionID"].Value);
					this.m_nLastSessionID=Convert.ToInt32(element.Attributes["LastSessionID"].Value);
				}

				//Get all messages.
				if(element.ChildNodes.Count==0) return;
				MSNBaseMessage message=null;
				foreach(XmlNode node in element.ChildNodes)
				{
					string strMessageType=node.Name.ToLower();
					switch(strMessageType)
					{
						case "message":
							#region Text Message
							message=new MSNMessageInfo();
							MSNUserInfo user=new MSNUserInfo();
							for(int index=0;index<node.ChildNodes.Count;index++)
							{
								string strChildName=node.ChildNodes.Item(index).Name.ToLower();
								//From User in Message
								if(strChildName.Equals("from"))
								{
									((MSNMessageInfo)message).FromUsers=
										this.GetUsersFromXmlNode(node.ChildNodes.Item(index));
								}
								else if(strChildName.Equals("to"))
								{
								
									((MSNMessageInfo)message).ToUsers= 
										this.GetUsersFromXmlNode(node.ChildNodes.Item(index));
								}
							}
							#endregion
							 break;
						case "leave":
							message=new MSNLeaveMessageInfo();
							break;
						case "join":
							message=new MSNJoinMessageInfo();
							break;
						case "invitation":
							message=new MSNInvitationMessageInfo();
							((MSNInvitationMessageInfo)message).File=this.GetFileTextFromXmlNode(node);
							((MSNInvitationMessageInfo)message).Application=this.GetApplicationFromXmlNode(node);

							for(int index=0;index<node.ChildNodes.Count;index++)
							{
								string strChildName=node.ChildNodes.Item(index).Name.ToLower();
								//From User in Message
								if(strChildName.Equals("from"))
								{
									((MSNInvitationMessageInfo)message).FromUsers=
										this.GetUsersFromXmlNode(node.ChildNodes.Item(index))	;
								}
							}
							break;
						case "invationresponse":
							message=new MSNInvitationResponseMessageInfo();
							((MSNInvitationResponseMessageInfo)message).File=
								                                           this.GetFileTextFromXmlNode(node);
							((MSNInvitationResponseMessageInfo)message).Application=
								                                           this.GetApplicationFromXmlNode(node);
							for(int index=0;index<node.ChildNodes.Count;index++)
							{
								string strChildName=node.ChildNodes.Item(index).Name.ToLower();
								//From User in Message
								if(strChildName.Equals("from"))
								{
									((MSNInvitationMessageInfo)message).FromUsers=
										this.GetUsersFromXmlNode(node.ChildNodes.Item(index))	;
								}
							}
							break;							
					    default:
							 break;
					}
				
					message.FilePath=this.Path;
					message.DateTimeOn=DateTime.Parse(node.Attributes["DateTime"].InnerXml);// Convert.ToDateTime(node.Attributes["DateTime"].InnerText);
					message.SessionID=Convert.ToInt32(node.Attributes["SessionID"].InnerXml);
					message.Text=this.GetMessageTextFromXmlNode(node);
					string key=message.DateTimeOn.ToString("s")+"."+message.DateTimeOn.Millisecond+"Z";
					if(!this.MSNMessages.ContainsKey(key))
					{
						this.MSNMessages.Add(key,message);
					}
				}
				
			} 
			//catch(Exception err)
//			{
//				string drf=err.Message;
//			}
	//		finally 
			{
				if (reader != null)
					reader.Close();
			}

		}

		#endregion
		
		#region Private Methods

		/// <summary>
		/// 
		/// <param name="node">
		/// <c>
		/// <From>		<User FriendlyName="confach@hotmail.com"/>			 </From>
		/// </c>
		/// </param>
		/// <returns></returns>
		private ArrayList GetUsersFromXmlNode(XmlNode node)
		{
			if(node==null) return null;
			if(node.ChildNodes.Count==0) return null;
			ArrayList arr=new ArrayList();
			foreach( XmlNode subNode in node.ChildNodes)
			{
				MSNUserInfo user=new MSNUserInfo();
				user.FriendlyName=subNode.Attributes["FriendlyName"].InnerXml;
				arr.Add(user);
			}
			return arr;
		}

		/// <summary>
		/// Get the File text.
		/// </summary>
		/// <param name="node">
		/// <c><Invitation Date="2005-12-30" Time="13:50:34" DateTime="2005-12-30T05:50:34.003Z" SessionID="26">
		///<From>
		///<User FriendlyName="xxxx@hotmail.com"/> </From>
		///<File>C:\Documents and Settings\confach.zhang\桌面\未命名.JPG</File>
		///<Text Style="color:#545454; ">confach@hotmail.com 发送 C:\Documents and Settings\confach.zhang\桌面\未命名.JPG</Text></c>
		/// </param>
		/// <returns></returns>
		private string GetFileTextFromXmlNode(XmlNode node)
		{
			if(node==null) return string.Empty;
			foreach(XmlNode subNode in node.ChildNodes)
			{
				if(subNode.Name.ToLower().Equals("file"))
				{
					return  subNode.InnerXml;
				}
			}
			return string.Empty;
		}


		/// <summary>
		/// Get the application text
		/// </summary>
		/// <param name="node">The node in  MSN chat(XML format) </param>
		/// <returns></returns>
		private string GetApplicationFromXmlNode(XmlNode node)
		{
			if(node==null) return string.Empty;
			foreach(XmlNode subNode in node.ChildNodes)
			{
				if(subNode.Name.ToLower().Equals("application"))
				{
					return  subNode.InnerXml;
				}
			}
			return string.Empty;
		}


		/// <summary>
		/// Get the MSN message text.
		/// </summary>
		/// <param name="node">The node in  MSN chat(XML format) </param>
		/// <returns></returns>
		private MSNMessageTextInfo GetMessageTextFromXmlNode(XmlNode node)
		{
			if(node==null) return null;
			MSNMessageTextInfo text=new MSNMessageTextInfo();
			foreach(XmlNode subNode in node.ChildNodes)
			{
				if(subNode.Name.ToLower().Equals("text"))
				{
					text.Text=subNode.InnerXml;
					try
					{
						text.Style=subNode.Attributes["Style"].Value;
					}
					catch
					{
						text.Style=null;
					}
					return text;
				}
			}
			return null;
		}
		#endregion
		
	}
}
