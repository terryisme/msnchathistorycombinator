using System;
using System.Collections;
using System.IO;

namespace MSNMessageLibrary
{
	/// <summary>
	///  MSNChatDocumentGaimPlainText class is to process Gaim plain text.
	/// </summary>
	internal class MSNChatDocumentGaimPlainText:MSNBaseChatDocument
	{
		
		private string m_strGaimPath;
		/// <summary>
		/// Construction
		/// </summary>
		///<param name="gaimLogPath">Gaim log  path</param>
		public MSNChatDocumentGaimPlainText(string gaimLogPath)
		{
			m_strGaimPath=gaimLogPath;
		}

		/// <summary>
		/// Load the document from gaim.
		/// </summary>
		public override void Load()
		{
			if(GaimLogFileType.Directory==CheckPathType(m_strGaimPath))
			{
				//Directory
				//Traverse the entire directory
				ReadGaimDirectory(m_strGaimPath);
 
			}
			else //File
			{
				ReadGaimFile(m_strGaimPath);
			}
		}


		/// <summary>
		/// Check the path type is Directory or File.
		/// </summary>
		/// <param name="path">Gaim path.</param>
		/// <returns>Return the path type.</returns>
		private GaimLogFileType CheckPathType(string path)
		{
			if(path==null ||path.Trim().Length==0)
				throw new Exception("The supported Gaim file is invalid" );

			string dirName=System.IO.Path.GetDirectoryName(path);
			
			if(dirName==null||string.Empty==dirName)
				throw new Exception("The supported Gaim path is error!");

			
			if(Directory.Exists(path)) return GaimLogFileType.Directory;			
			return GaimLogFileType.File;
		}


		/// <summary>
		/// Read the Gaim text fie.
		/// </summary>
		/// <param name="path">The path of file.</param>
		/// <remarks>
		/// Gaim file has many types: Plain Text ,HTML .
		/// </remarks>
		protected virtual void ReadGaimFile(string path)
		{
			if (!File.Exists(path))  return;
	
			StreamReader sr = File.OpenText(path);
			String input;
			while ((input=sr.ReadLine())!=null) 
			{
				MSNBaseMessage message=ParseHistoryText(input,path);
				string key=message.DateTimeOn.ToString("s")+"."+message.DateTimeOn.Millisecond+"Z";
				if(!this.MSNMessages.ContainsKey(key))
				{
					this.MSNMessages.Add(key,message);
				}
			}
			sr.Close();

		}

		private void ReadGaimDirectory(string path)
		{
			SortedList msnList=new SortedList();
			if(path==null||path.Trim().Length==0) return ;

			string[] files=Directory.GetFiles(path);
			foreach (string aFile in files)
			{
				ReadGaimFile(aFile);
			}

			string[] dirs=Directory.GetDirectories(path);
			foreach(string aDir in dirs)
				ReadGaimDirectory(aDir);
		
		}

		private MSNBaseMessage ParseHistoryText(string text,string path)
		{
			MSNBaseMessage message=new MSNBaseMessage();
			MSNMessageTextInfo msnText=new MSNMessageTextInfo();

			//get the data and time from gaim file name
			string fileName=new FileInfo(path).Name;
			string[] arr=fileName.Split('.');
			DateTime dt=Convert.ToDateTime(arr[0]);
			string[] hms=arr[1].Split('+');

			if(!text.StartsWith("("))//system information
			{				
				message=new  MSNMessageInfo();
				msnText.Text=text;
				msnText.Style=Style.DEFAULT_TEXT_STYLE;
				message.Text=msnText;
				message.DateTimeOn=dt;
				// Set the MSN From people
				(message as MSNMessageInfo).FromUsers.Add(new MSNUserInfo("System"));
				
				// Set the MSN To people
				(message as MSNMessageInfo).ToUsers.Add(new MSNUserInfo("Me"));
				if(hms.Length>1)// have hour/minute/second/MillSecond
				{	
					message.DateTimeOn=new DateTime(message.DateTimeOn.Year,
						                                                    message.DateTimeOn.Month,
						                                                    message.DateTimeOn.Day,
						                                                    Convert.ToInt32(hms[0].Substring(0,2)),
						                                                    Convert.ToInt32(hms[0].Substring(2,2)),
						                                                    Convert.ToInt32(hms[0].Substring(4,2)),
						                                                     Convert.ToInt32(hms[1].Substring(0,4)));
				}
				else
				{
					message.DateTimeOn=new DateTime(message.DateTimeOn.Year,
																			message.DateTimeOn.Month,
																			message.DateTimeOn.Day,
																			Convert.ToInt32(hms[0].Substring(0,2)),
																			Convert.ToInt32(hms[0].Substring(2,2)),
																			Convert.ToInt32(hms[0].Substring(4,2)),
																			0
						                                                    );
				}
			}
			else
			{
				//Set the date and time
				int index=text.IndexOf(")",2);
				string strCreatedOn=text.Substring(1,index-1);

				message.DateTimeOn=Convert.ToDateTime(arr[0]+" "+strCreatedOn);

				//Search the position of ":"
				string strElse=text.Substring(index+1);
				int nPosToggle=strElse.IndexOf(":");
				if(nPosToggle>=0)//it is a conversation text.
				{
					message=new MSNMessageInfo();

					// Set the MSN From people
					(message as MSNMessageInfo).FromUsers.Add(new MSNUserInfo(strElse.Substring(0,nPosToggle)));
				
					// Set the MSN To people
                   (message as MSNMessageInfo).ToUsers.Add(new MSNUserInfo("N/A"));
					
					//Set the MSN text
					msnText.Text=strElse.Substring(nPosToggle+1);

					//set the MSN text style
					msnText.Style=Style.DEFAULT_TEXT_STYLE;
				}
				else// it may be a system message 
				{
					message=new MSNMessageInfo();
				
					// Set the MSN From people
					(message as MSNMessageInfo).FromUsers.Add(new MSNUserInfo("System"));
				
					// Set the MSN To people
					(message as MSNMessageInfo).ToUsers.Add(new MSNUserInfo("Me"));
					
					//Set the MSN text
					msnText.Text=strElse;

					//Set the text style
					msnText.Style=Style.DEFAULT_TEXT_STYLE;
				}

				message.Text=msnText;			
			}

			return message;
		}
		/// <summary>
		/// Gaim log file type. because gaim path can be a folder or file(s)
		/// </summary>
		public enum GaimLogFileType:int
		{
			/// <summary>
			/// Directory
			/// </summary>
			 Directory=0,

			/// <summary>
			/// File
			/// </summary>
			 File=1
		};
	}
}
