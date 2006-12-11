#region Author:John
//Author:John
//date: 2005.12.15
//
//
//revision history
//
#endregion 



using System;

namespace DMD.Client.BLL
{
	/// <summary>
	/// MsgNumber.
	/// </summary>
	/// <remarks>
	/// Label ID;
	/// 00050-49999 for labels
	/// 50000-99999 for system message.
	/// </remarks>
	public class MsgNumber
	{
		
		public const	int NONE			= 0;


		#region Login Form System Message(50001-50002)
		public const int LOGIN_SYS_MSG_LOGIN_OK=50001;
		public const int LOGIN_SYS_MSG_LOGIN_FAILURE=50002;
#endregion

		#region  Labels(0-50000)
		#region Login Form Labels(1-20)
		public const int LOGIN_FORM_CAPTION=1;
		public const int LOGIN_LABEL_USER=2;
		public const int LOGIN_LABEL_PASSWORD=3;
		public const int LOGIN_BUTTON_LOGIN=4;
		public const int LOGIN_BUTTON_CANCEL=5;
		#endregion

		#region Main Form Label(21-40)
		public const int MAINFORM_CAPTION=21;
		public const int MAINFORM_WO_LIST=22;
		public const int MAINFORM_NEW_WO=23;
		public const int MAINFORM_TIMECARD=24;
		public const int MAINFORM_MESSAGE=25;
		public const int MAINFORM_PARTS_TOOLS=26;
		public const int MAINFORM_INVENTORY=27;
		public const int MAINFORM_PO=28;
		public const int MAINFORM_SYNC=29;
		public const int MAINFORM_SYSTEM=30;
		#endregion
		
		#region Work Order Form Tabs(41-60)
		public const int WO_DETAIL_FORM_TIME=41;
		public const int WO_DETAIL_FORM_ACCOUNT=42;
		public const int WO_DETAIL_FORM_WO=43;
		public const int WO_DETAIL_FORM_ACTION=44;
		public const int WO_DETAIL_FORM_SA=45;
		public const int WO_DETAIL_FORM_EQUIPMENT=46;
		public const int WO_DETAIL_FORM_TICKET=47;
		public const int WO_DETAIL_FORM_INVOICE=48;
		public const int WO_DETAIL_FORM_TASK=49;
		public const int WO_DETAIL_FORM_CLOSE=50;

#endregion
		
		#region WO List Form(61-80)
		public const int WO_LIST_CAPTION=61;
		public const int WO_LIST_BTN_VIEW=62;
		
#endregion
		
		#region Work Order Detail Form(81-90)
		public const int WO_DETAIL_FORM_CAPTION=81;
#endregion

		#region Work Order Detail Tab Pages(91-590)
		#region Action Tab Page(91-140)
		public const int WO_TP_ACTION_BTN_NEW_COMPLAINT=91;
		public const int WO_TP_ACTION_BTN_SAVE_COMPLAINT=92;
		public const int WO_TP_ACTION_COMPLAINT_LABEL=93;
		public const int WO_TP_ACTION_BTN_NEW_ACTION=94;
		public const int WO_TP_ACTION_BTN_VIEW_ACTION=95;
		public const int WO_TP_ACTION_ACTION_LIST_HEADER_ACTION=96;//Action
		public const int WO_TP_ACTION_ACTION_LIST_HEADER_DESCRIPTION=97;//Description
		#endregion

		#region Invoice Tab Page(141-190)
		public const int WO_TP_INVOICE_BTN_NEW=141;
		public const int WO_TP_INVOICE_BTN_VIEW=142;
		public const int WO_TP_INVOICE_BTN_EDIT=143;

#endregion

		#region Account Tab Page(191-240)
#endregion

		#region Time Tab Page(241-290)
#endregion

		#region WO Tab Page(291-340)
#endregion

		#region Ticket Tab Page(341-390)
		public const int WO_TP_TICKET_TICKET_LABEL=341;
		public const int WO_TP_TICKET_NOTES_LABEL=342;
		public const int WO_TP_TICKET_BI_LABEL=343;
		public const int WO_TP_TICKET_BI_LIST_HEADER_DESC=344;
		public const int WO_TP_TICKET_BI_LIST_HEADER_QTY=345;
		public const int WO_TP_TICKET_BI_LIST_HEADER_INVOICE=346;
		public const int WO_TP_TICKET_BTN_NEW=347;
#endregion

		#region SA Tab Page(391-440)
		public const int WO_TP_SA_BTN_VIEW=391;
#endregion

		#region Task Tab Page(441-490)
		public const int WO_TP_TASK_BTN_DETAIL=441;
	    public const int WO_TP_TASK_BTN_NEW=442;
		public const int WO_TP_TASK_LIST_HEADER_TYPE=443;
		public const int WO_TP_TASK_LIST_HEADER_SUBJECT=444;
#endregion

		#region Close Tab Page(491-540)
		public const int WO_TP_CLOSE_COMPLAINTS_LABEL=491;
		public const int WO_TP_CLOSE_COMPLAINTS_LIST_HEADER_COMPLAINT=492;
		public const int WO_TP_CLOSE_COMPLAINTS_LIST_HEADER_STATUS=493;
		public const int WO_TP_CLOSE_INVOICES_LABEL=494;
		public const int WO_TP_CLOSE_INVOICES_LIST_HEADER_NUMBER=495;
		public const int WO_TP_CLOSE_INVOICES_LIST_HEADER_DATETIME=496;

		public const int WO_TP_CLOSE_BTN_COMPLETE=497;
		public const int WO_TP_CLOSE_BTN_SIGNATURE=498;
#endregion

		#region Equipment Tab Pages(541-590)
		/// <summary>
		/// Button "New"  to create an equipment
		/// </summary>
		public const int WO_TP_EQUIPMENT_BTN_NEW=541;

		/// <summary>
		/// Button "View" to view the detail of equipment.
		/// </summary>
		public const int WO_TP_EQUIPMENT_BTN_VIEW=542;


#endregion
		#endregion

		#region Complaint-- New Form(701-750)
		public const int COMPLAINT_NEW_FORM_BTN_SAVE=701;
		public const int COMPLAINT_NEW_FORM_BTN_CANCEL=702;
		public const int COMPLAINT_NEW_FORM_LABEL_WO=703;
		public const int COMPLAINT_NEW_FORM_LABEL_COMPLAINT=704;
		public const int COMPLAINT_NEW_FORM_CAPTION=705;
#endregion

		#region Action--New/Edit Form(761-810)
		public const int ACTION_NEW_FORM_CAPTION=761;
		public const int ACTION_NEW_FORM_LABEL_EQUIPMENT=762;
		public const int ACTION_NEW_FORM_LABEL_SA=763;
		public const int ACTION_NEW_FORM_LABEL_SERVICE=764;
		public const int ACTION_NEW_FORM_LABEL_COMPLAINT_STATUS=765;
		public const int ACTION_NEW_FORM_BTN_VIEW_EQUIPMENT=766;
		public const int ACTION_NEW_FORM_BTN_VIEW_SA=767;
		public const int ACTION_NEW_FORM_BTN_VIEW_NOTE=768;
		public const int ACTION_NEW_FORM_BTN_VIEW_PART=769;
		public const int ACTION_NEW_FORM_BTN_NEW_NOTE=770;
		public const int ACTION_NEW_FORM_BTN_NEW_PART=771;
		public const int ACTION_NEW_FORM_BTN_NEW_CHECKLIST=772;
		public const int ACTION_NEW_FORM_BTN_SIGNATURE=773;
		public const int ACTION_NEW_FORM_BTN_SAVE=774;
		public const int ACTION_NEW_FORM_LABEL_COMPLAINT=775;
#endregion

		#region Equipment(811-950)

		#region Equipment --List Form(811-850)
		public const int EQUIPMENT_LIST_FORM_CAPTION=811;
		public const int EQUIPMENT_LIST_FORM_BTN_CANCEL=812;
		public const int EQUIPMENT_LIST_FORM_BTN_SELECT=813;
		public const int EQUIPMENT_LIST_FORM_LIST_HEADER_1=814;
		public const int EQUIPMENT_LIST_FORM_LIST_HEADER_2=815;
		public const int EQUIPMENT_LIST_FORM_LIST_HEADER_3=816;
#endregion

		#region Equipment--Detail Form(851-900)
		public const int EQUIPMENT_DETAIL_FORM_CAPTION=851;
		public const int EQUIPMENT_DETAIL_FORM_BTN_CANCEL=852;
		public const int EQUIPMENT_DETAIL_FORM_BTN_NOTES=853;
#endregion

		#region Equipment--New Form(901-950)
		public const int EQUIPMENT_NEW_FORM_CAPTION=901;
		public const int EQUIPMENT_NEW_FORM_LABEL_SERIAL=902;
		public const int EQUIPMENT_NEW_FORM_LABEL_MAKE=903;
		public const int EQUIPMENT_NEW_FORM_LABEL_MODEL=904;
		public const int EQUIPMENT_NEW_FORM_LABEL_TYPE=905;
		public const int EQUIPMENT_NEW_FORM_LABEL_BARCODE=906;
		public const int EQUIPMENT_NEW_FORM_LABEL_LOCATION=907;
		public const int EQUIPMENT_NEW_FORM_LABEL_INSTALLEDDATE=908;
		public const int EQUIPMENT_NEW_FORM_LABEL_WARRANTY_START_DATE=909;
		public const int EQUIPMENT_NEW_FORM_LABEL_WARRANTY_END_DATE=910;
		public const int EQUIPMENT_NEW_FORM_BTN_CANCEL=916;
		public const int EQUIPMENT_NEW_FORM_BTN_SAVEL=917;
#endregion
		
		#endregion

		#region Service Agreement(1001-2000)
		#region SA--List Form(1001-1040)
		public const int SA_LIST_FORM_CAPTION=1001;
		public const int SA_LIST_FORM_BTN_CANCEL=1002;
		public const int SA_LIST_FORM_BTN_SELECT=1003;
		public const int SA_LIST_FORM_LIST_HEADER_1=1009;
		public const int SA_LIST_FORM_LIST_HEADER_2=1010;

#endregion
		#region SA--Detail Form(1061-1110)
		public const int SA_DETAIL_FORM_CAPTION=1061;
		public const int SA_DETAIL_FORM_BTN_BACK=1062;
		public const int SA_DETAIL_FORM_BTN_COMPONENT=1063;
		public const int SA_DETAIL_FORM_BTN_PARTS=1064;
		public const int SA_DETAIL_FORM_BTN_NOTES=1065;

#endregion
		#endregion

		#endregion
		
		#region Messages(50001-99999)
		#region Login Form 
		public const int LOGIN_STATUS_LOGIN=50001;
		public const int LOGIN_STATUS_FAILURE=5002;
		public const int LOGIN_STATUS_INITIALIZE=5003;
		public const int LOGIN_STATUS_END=5004;
		public const int LOGIN_FAILURE=5005;
#endregion
#endregion
		
		#region System    Number: 50000-50999
		 
		public const	int System_Message_NoneField		= 50000;
		public const	int System_Message_EmptyID 			= 50001;
		public const	int System_Message_NoRecord			= 50002;
		public const	int System_Message_EmptyTableName			= 50003;
		public const	int System_Message_AreYouSure		= 50004;
			
		#endregion

	

	}
}
