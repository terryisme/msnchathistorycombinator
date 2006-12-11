using System;
using System.Collections;
using System.IO;

namespace MSNMessageLibrary
{
	/// <summary>
	/// Summary description for MSNDocumentCombine.
	/// </summary>
	public class MSNDocumentCombine
	{
		#region Private Members
		/// <summary>
		/// construction.
		/// </summary>
		public MSNDocumentCombine()
		{
			m_firstDoc=new MSNFILESTRUCT();
			m_secondDoc=new MSNFILESTRUCT();
			m_savedDoc=new MSNFILESTRUCT();
		}

		private string m_strXslPath="";
		private MSNFILESTRUCT m_firstDoc;
		private MSNFILESTRUCT m_secondDoc;
		private MSNFILESTRUCT m_savedDoc;
		private SetProgressText m_spt;
		private MSNBaseChatDocument firstDoc;
		private MSNBaseChatDocument secondDoc;
#endregion
		
		#region Public Properties

		/// <summary>
		/// First document
		/// </summary>
		public MSNFILESTRUCT FirstDocument
		{
			get
			{
				 return m_firstDoc;
			}
			set
			{
				m_firstDoc=value;
			}
		}

		/// <summary>
		/// Second document
		/// </summary>
		public MSNFILESTRUCT SecondDocument
		{
			get
			{
				return m_secondDoc;
			}
			set
			{
				m_secondDoc=value;
			}
		}

		/// <summary>
		/// Saved document
		/// </summary>
		public MSNFILESTRUCT SavedDocument
		{
			get
			{
				return m_savedDoc;
			}
			set
			{
				m_savedDoc=value;
			}
		}
		#region Marked
//		/// <summary>
//		/// Saved file format
//		/// </summary>
//		public MSNChatHistoryFormat SavedFileFormat
//		{
//			get
//			{
//
//				return m_savedFormat;
//			}
//			set
//			{
//				m_savedFormat=value;
//			}
//		}
//		/// <summary>
//		/// Public Property.
//		/// The First Document path.
//		/// </summary>
//		public string FirstDocumentPath
//		{
//			get
//			{
//				return this.m_strFirstPath;
//			}
//			set
//			{
//				m_strFirstPath=value;
//			}
//		}
//
//		/// <summary>
//		/// Public Property.
//		/// The second MSN chat file path.
//		/// </summary>
//		public string SecondDocumentPath
//		{
//			get
//			{
//				return m_strSceondPath;
//			}
//			set
//			{
//				m_strSceondPath=value;
//			}
//		}
//
//
//		/// <summary>
//		/// Public Property.
//		/// The saved MSN chat file path.
//		/// </summary>
//		public string SavedDocumentPath
//		{
//			get
//			{
//				return m_strSavedPath;
//			}
//			set
//			{
//				m_strSavedPath=value;
//			}
//		}

		#endregion

		/// <summary>
		/// Public Property.
		/// The source XSL file path.
		/// </summary>
		public string XSLFilePathSrc
		{
			get
			{
				return this.m_strXslPath;
			}
			set
			{
				this.m_strXslPath=value;
			}
		}

		/// <summary>
		/// Delegate
		/// Set progress text.
		/// </summary>
		public SetProgressText OnSetProgressText
		{
			get
			{
				return this.m_spt;
			}
			set
			{
				this.m_spt=value;
			}
		}
#endregion
		
		#region  Public Methods

		/// <summary>
		/// Combine the MSN chat message.
		/// </summary>
		public void Combine()
		{
			//Copy XSL to document
			string strDest="";
			//Handle XSTL file when the saved file format is MSN only
			if(SavedDocument.Format==MSNChatHistoryFormat.MSN)
			{
				FileInfo src=new FileInfo(this.XSLFilePathSrc);		
				FileInfo dest=new FileInfo(this.SavedDocument.Path);		
				strDest=dest.DirectoryName+src.Name;
				if(!XSLFilePathSrc.Equals(strDest))				   
				{
					File.Copy(this.XSLFilePathSrc,strDest,true);
				}
			}

			//Load the first document
			this.OnSetProgressText("Loading "+this.FirstDocument.Path );
			firstDoc= MSNBaseChatDocument.DoInstance(this.FirstDocument);
			firstDoc.Load();

			//Load the second document		
			this.OnSetProgressText("Loading "+this.SecondDocument.Path);
			secondDoc= MSNBaseChatDocument.DoInstance(this.SecondDocument);
			secondDoc.Load();

			//Combine the 2 files records			
			this.OnSetProgressText("Combining "+this.FirstDocument.Path+ "and "+this.SecondDocument.Path);
			SortedList sl1=firstDoc.MSNMessages;
			SortedList sl2=secondDoc.MSNMessages;
			if(sl1.Count<=sl2.Count)
			{
				for(int index=0;index<sl1.Count;index++)
				{
					if(!sl2.ContainsKey(sl1.GetKey(index)))
					{
						sl2.Add(sl1.GetKey(index),sl1.GetByIndex(index));
					}
				}
				//save to new XML file
				this.OnSetProgressText("Saving the result!");
				Save(sl2);
			}
			else
			{
				for(int index=0;index<sl2.Count;index++)
				{
					if(!sl1.ContainsKey(sl2.GetKey(index)))
					{
						sl1.Add(sl2.GetKey(index),sl2.GetByIndex(index));
					}
				}
				//save to new XML file
				this.OnSetProgressText("Saving the result!");
				Save(sl1);
			}
				this.OnSetProgressText("Finished combining these 2 MSN files.!");
		}

#endregion
		
		private void Save(SortedList src)
		{
			switch(this.SavedDocument.Format)
			{	
				case MSNChatHistoryFormat.MSN:
					SaveToMSNFormat(src);
					break;
				case MSNChatHistoryFormat.GaimPlainText:
					SaveToGaimPlainText(src);
					break;
				case MSNChatHistoryFormat.GaimHTML:
				default:
					break;
			}
		}

		#region Save To Gaim Plain Text
       private void SaveToGaimPlainText(SortedList src)
	   {
		   //If no record, exit
		   if(src.Count==0) return ;
		   using (StreamWriter sw = new StreamWriter(this.SavedDocument.Path)) 
		   {
			   for(int index=0;index<src.Count;index++)
			   {
				   Object message=src.GetByIndex(index);
				   if(message is MSNMessageInfo)
				   {
					   sw.WriteLine("("+
						                   (message as MSNMessageInfo).DateTimeOn.ToLongTimeString()+
                                           ") " +
						                   ((message as MSNMessageInfo).FromUsers[0] as MSNUserInfo).FriendlyName+
						                   ": "+
						                   (message as MSNMessageInfo).Text.Text);
				   }
			   }
		   }
	   }
#endregion
		#region Private Save  to MSN methods

		/// <summary>
		/// Save the message.
		/// </summary>
		/// <param name="src">The message source.</param>
		private void SaveToMSNFormat(SortedList src)
		{
			
			//If no record, exit
			if(src.Count==0) return ;
			
			//Generate Session ID again
			MSNSession session=new MSNSession(src);
			session.Generate();
			src=session.MessagesSource;

//			for(int i=0;i<src.Count;i++)
//			{
//				Console.WriteLine(src.GetKey(i));
//			}
			//using (StreamWriter sw = new StreamWriter(this.SavedDocumentPath)) 
			using (StreamWriter sw = new StreamWriter(this.SavedDocument.Path)) 
			{
				//Build XML header
				sw.WriteLine("<?xml version=\"1.0\"?>");
				sw.WriteLine("<?xml-stylesheet type='text/xsl' href='MessageLog.xsl'?>");

				//Build Message
				
				//step 1:Build Root
				//<Log FirstSessionID="1" LastSessionID="22">
				int MaxSessionID=(src.GetByIndex(src.Count-1) as MSNBaseMessage).SessionID;

				sw.WriteLine("<Log FirstSessionID=\"1\" LastSessionID=\""+MaxSessionID.ToString()+"\">");
        
                //Step 2:Build Message
				for(int index=0;index<src.Count;index++)
				{
					Object message=src.GetByIndex(index);
					if(message is MSNMessageInfo)
					{
						BuildGeneralMessage(sw,(MSNMessageInfo)message);
					}
					else if(message is MSNJoinMessageInfo)
					{
						BuildJoinMessage(sw,(MSNJoinMessageInfo)message);
					}
					else if(message is MSNLeaveMessageInfo)
					{
						BuildLeaveMessage(sw,(MSNLeaveMessageInfo)message);
					}
					else if(message is MSNInvitationResponseMessageInfo)
					{
						BuildInvitationResponseMessage(sw,(MSNInvitationResponseMessageInfo)message);
					}
					else if(message is MSNInvitationMessageInfo)
					{
						BuildInvitationMessage(sw,(MSNInvitationMessageInfo)message);
					}
				}
				
				//step 3:Build bottom
				sw.WriteLine("</Log>");
			}
		}


		/// <summary>
		/// Build common message.
		/// </summary>
		/// <param name="sw">Stream witter to XML file</param>
		/// <param name="message">The common message.</param>
		private void BuildGeneralMessage(StreamWriter sw,MSNMessageInfo message)
			{																																																	
				//Message
				sw.WriteLine("<Message Date=\""+message.DateTimeOn.ToShortDateString() +"\" Time=\""+
					                 message.DateTimeOn.ToShortTimeString()+"\" DateTime=\""
					                 +message.DateTimeOn.ToString("s")+"."+message.DateTimeOn.Millisecond
					                 +"Z\" SessionID=\""+message.SessionID+"\">");
				
				//From User
				sw.WriteLine("<From>");
				for(int index=0;index<message.FromUsers.Count;index++)
				{
					sw.WriteLine("<User FriendlyName=\""+ToXmlString(((MSNUserInfo)message.FromUsers[index]).FriendlyName)+"\"/>");
				}
				sw.WriteLine("</From>");

				//To Users
				sw.WriteLine("<To>");
				for(int index=0;index<message.ToUsers.Count;index++)
				{
					sw.WriteLine("<User FriendlyName=\""+ToXmlString((((MSNUserInfo)message.ToUsers[index]).FriendlyName)+"\"/>"));
				}
				sw.WriteLine("</To>");

				//Text
				sw.Write("<Text ");
				if(message.Text.Style!=null)
				{
					sw.Write("Style=\""+ToXmlString(message.Text.Style)+"\">"+ToXmlString(message.Text.Text)+"</Text>");
				}
				else
				{
					sw.Write(">"+ToXmlString(message.Text.Text)+"</Text>");
				}
			sw.WriteLine();

				//Bottom
				sw.WriteLine("</Message>");
			}
		

		/// <summary>
		/// Build Join Message.
		/// </summary>
		/// <param name="sw">Stream witter to XML file</param>
		/// <param name="message">The Join message.</param>
		private void BuildJoinMessage(StreamWriter sw,MSNJoinMessageInfo message)
		{
			//Message
			sw.WriteLine("<Join Date=\""+message.DateTimeOn.ToShortDateString() +"\" Time=\""+
				message.DateTimeOn.ToShortTimeString()+"\" DateTime=\""
				+message.DateTimeOn.ToString("s")+"."+message.DateTimeOn.Millisecond
				+"Z\" SessionID=\""+message.SessionID+"\">");
				
			//From User
			sw.WriteLine("<User>");		    
			sw.WriteLine("<User FriendlyName=\""+ToXmlString(message.User.FriendlyName)+"\"/>");
			sw.WriteLine("</User>");

			//Text
			sw.Write("<Text ");
			if(message.Text.Style!=null)
			{
				sw.Write("Style=\""+ToXmlString(message.Text.Style)+"\">"+ToXmlString(message.Text.Text)+"</Text>");
			}
			else
			{
				sw.Write(">"+ToXmlString(message.Text.Text)+"</Text>");
			}
			sw.WriteLine();

			//Bottom
			sw.WriteLine("</Join>");
		}


		/// <summary>
		/// Build Leave message.
		/// </summary>
		/// <param name="sw">Stream witter to XML file</param>
		/// <param name="message">The Leave message.</param>
		private void BuildLeaveMessage(StreamWriter sw,MSNLeaveMessageInfo message)
		{
			//Message
			sw.WriteLine("<Leave Date=\""+message.DateTimeOn.ToShortDateString() +"\" Time=\""+
				message.DateTimeOn.ToShortTimeString()+"\" DateTime=\""
				+message.DateTimeOn.ToString("s")+"."+message.DateTimeOn.Millisecond
				+"Z\" SessionID=\""+message.SessionID+"\">");
				
			//From User
			sw.WriteLine("<User>");		    
			sw.WriteLine("<User FriendlyName=\""+ToXmlString(message.User.FriendlyName)+"\"/>");
			sw.WriteLine("</User>");

			//Text
			sw.Write("<Text ");
			if(message.Text.Style!=null)
			{
				sw.Write("Style=\""+ToXmlString(message.Text.Style)+"\">"+ToXmlString(message.Text.Text)+"</Text>");
			}
			else
			{
				sw.Write(">"+ToXmlString(message.Text.Text)+"</Text>");
			}
			sw.WriteLine();

			//Bottom
			sw.WriteLine("</Leave>");
		}


		/// <summary>
		/// Build Invitation Message.
		/// </summary>
		/// <param name="sw">Stream witter to XML file</param>
		/// <param name="message">The invitation message.</param>
		private void BuildInvitationMessage(StreamWriter sw,MSNInvitationMessageInfo message)
		{
			//Message
			sw.WriteLine("<Invitation Date=\""+message.DateTimeOn.ToShortDateString() +"\" Time=\""+
				message.DateTimeOn.ToShortTimeString()+"\" DateTime=\""
				+message.DateTimeOn.ToString("s")+"."+message.DateTimeOn.Millisecond
				+"Z\" SessionID=\""+message.SessionID+"\">");
				
			//From User
			sw.WriteLine("<From>");
			for(int index=0;index<message.FromUsers.Count;index++)
			{
				sw.WriteLine("<User FriendlyName=\""+ToXmlString(((MSNUserInfo)message.FromUsers[index]).FriendlyName)+"\"/>");
			}
			sw.WriteLine("</From>");

			//File
			if(message.File!=null)
			{
				sw.WriteLine("<File>"+ToXmlString(message.File)+"</File>");
			}

			//Application
//			if(message.Application!=null)
//			{
//				sw.WriteLine("<File>"+message.Application+"</File>");
//			}

			//Text
			sw.Write("<Text ");
			if(message.Text.Style!=null)
			{
				sw.Write("Style=\""+ToXmlString(message.Text.Style)+"\">"+ToXmlString(message.Text.Text)+"</Text>");
			}
			else
			{
				sw.Write(">"+ToXmlString(message.Text.Text)+"</Text>");
			}
			sw.WriteLine();

			//Bottom
			sw.WriteLine("</Invitation>");
		}


		/// <summary>
		/// Build InvitationReponse Message.
		/// </summary>
		/// <param name="sw">Stream witter to XML file</param>
		/// <param name="message">The invitation response message.</param>
		private void BuildInvitationResponseMessage(StreamWriter sw,MSNInvitationResponseMessageInfo message)
		{
			//Message
			sw.WriteLine("<InvatationResponse Date=\""+message.DateTimeOn.ToShortDateString() +"\" Time=\""+
				message.DateTimeOn.ToShortTimeString()+"\" DateTime=\""
				+message.DateTimeOn.ToString("s")+"."+message.DateTimeOn.Millisecond
				+"Z\" SessionID=\""+message.SessionID+"\">");
				
			//From User
			sw.WriteLine("<From>");
			for(int index=0;index<message.FromUsers.Count;index++)
			{
				sw.WriteLine("<User FriendlyName=\""+ToXmlString(((MSNUserInfo)message.FromUsers[index]).FriendlyName)+"\"/>");
			}
			sw.WriteLine("</From>");

			//File
			if(message.File!=null)
			{
				sw.WriteLine("<File>"+ToXmlString(message.File)+"</File>");
			}

			//Application
			//			if(message.Application!=null)
			//			{
			//				sw.WriteLine("<File>"+message.Application+"</File>");
			//			}

			//Text
			sw.Write("<Text ");
			if(message.Text.Style!=null)
			{
				sw.Write("Style=\""+ToXmlString(message.Text.Style)+"\">"+ToXmlString(message.Text.Text)+"</Text>");
			}
			else
			{
				sw.Write(">"+ToXmlString(message.Text.Text)+"</Text>");
			}
			sw.WriteLine();

			//Bottom
			sw.WriteLine("</InvitationResponse>");
		}

		
		/// <summary>
		/// To process the characters not display in XML files.Such as &,<
		/// </summary>
		/// <param name="src">The string to processed.</param>
		/// <returns>Return the string processed</returns>
		private string ToXmlString(string src)
		{
			src=src.Replace("&","&amp;");
			src=src.Replace("<","&lt;");			
			src=src.Replace("'","&apos;");
			return src;
		}
		#endregion

		#region Delegate
		/// <summary>
		/// Delegate
		/// Set progress text.The caller must provider the target for it.
		/// </summary>
		public delegate void  SetProgressText(string text);
		#endregion
	}

	/// <summary>
	/// MSN source file struct
	/// </summary>
	public class MSNFILESTRUCT
	{
		/// <summary>
		/// Path to file.
		/// </summary>
		public string Path=string.Empty;

		/// <summary>
		/// Format
		/// </summary>
		public MSNChatHistoryFormat Format=MSNChatHistoryFormat.MSN;

	};
}
