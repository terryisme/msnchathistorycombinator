using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MSNMessageLibrary;
namespace MSNChatCombinator
{
	/// <summary>
	/// Summary description for frmChooseFileType.
	/// </summary>
	public class frmChooseFileType : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbMSN;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rbHTML;
		private System.Windows.Forms.RadioButton rbGaimPlain;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChooseFileType()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.rbMSN = new System.Windows.Forms.RadioButton();
			this.rbGaimPlain = new System.Windows.Forms.RadioButton();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.rbHTML = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please choose the file type ";
			// 
			// rbMSN
			// 
			this.rbMSN.Location = new System.Drawing.Point(64, 40);
			this.rbMSN.Name = "rbMSN";
			this.rbMSN.TabIndex = 1;
			this.rbMSN.Text = "MSN";
			// 
			// rbGaimPlain
			// 
			this.rbGaimPlain.Location = new System.Drawing.Point(64, 64);
			this.rbGaimPlain.Name = "rbGaimPlain";
			this.rbGaimPlain.Size = new System.Drawing.Size(120, 24);
			this.rbGaimPlain.TabIndex = 2;
			this.rbGaimPlain.Text = "Gaim-Plain Text";
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(24, 128);
			this.btnNext.Name = "btnNext";
			this.btnNext.TabIndex = 3;
			this.btnNext.Text = "Next";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(152, 128);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// rbHTML
			// 
			this.rbHTML.Enabled = false;
			this.rbHTML.Location = new System.Drawing.Point(64, 88);
			this.rbHTML.Name = "rbHTML";
			this.rbHTML.TabIndex = 5;
			this.rbHTML.Text = "Gaim-HTML";
			// 
			// frmChooseFileType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 174);
			this.Controls.Add(this.rbHTML);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.rbGaimPlain);
			this.Controls.Add(this.rbMSN);
			this.Controls.Add(this.label1);
			this.Name = "frmChooseFileType";
			this.Text = "Choose File Type";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if(!rbMSN.Checked&&!rbGaimPlain.Checked&&!rbHTML.Checked)
			{
				MessageBox.Show("Please choose a type!");
				return;
			}            
			if(rbMSN.Checked) 
			   m_format=MSNChatHistoryFormat.MSN;
		   else if(rbGaimPlain.Checked)
			   m_format=MSNChatHistoryFormat.GaimPlainText;
		   else if(rbHTML.Checked)
				m_format=MSNChatHistoryFormat.GaimHTML;
           
			this.DialogResult=DialogResult.Yes;
		}
		
		private MSNChatHistoryFormat m_format=MSNChatHistoryFormat.MSN;

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.DialogResult=DialogResult.No;
		}
		/// <summary>
		/// MSN chat history format.
		/// </summary>
		public MSNChatHistoryFormat ChatHistoryFormat
		{
			get
			{

				return m_format;
			}
			set
			{

				m_format=value;
			}
		}
	}
}
