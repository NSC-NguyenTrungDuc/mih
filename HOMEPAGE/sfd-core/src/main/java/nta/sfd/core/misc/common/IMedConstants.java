package nta.sfd.core.misc.common;

public interface IMedConstants {
	
	public interface MAIL_CODE {
		final String CONFIRM_DEMO = "CONFIRM_DEMO";
		final String CONTACT = "CONTACT";
		final String REPLY_CONTACT = "REPLY_CONTACT";
		final String ACCOUNT_REGISTER = "DEMO_ACCOUNT_INFORMATION";
		final String EMAIL_TEMPLATE_INFORM_CASE_NO_VPN = "DEMO_ACCOUNT_INFORMATION_NO_VPN";
		final String CONFIRM_REAL = "CONFIRM_REAL";
		final String CONFIRM_DEMO_MARKETING_TEAM = "CONFIRM_DEMO_MARKETING_TEAM";
		final String CONFIRM_REAL_MARKETING_TEAM = "CONFIRM_REAL_MARKETING_TEAM";
		final String REJECT_MARKETING_TEAM = "REJECT_MARKETING_TEAM";
		final String REAL_ACCOUNT_REGISTER = "REAL_ACCOUNT_INFORMATION";
		final String REAL_EMAIL_TEMPLATE_INFORM_CASE_NO_VPN = "REAL_ACCOUNT_INFORMATION_NO_VPN";
	}
	
	public interface SYS_PROPERTY {
		final String TYPE_CONTACT = "CONTACT";
		final String CODE_TO = "TO";
		final String CODE_COMPANY = "COMPANY";
	}
	
	public interface HOSPITAL_REGISTER_STATUS {
		final Integer REQUEST = 0;
		final Integer CONFIRMED = 1;
		final Integer INPROGRESS = 2;
		final Integer COMPLETED = 3;
		final Integer CANCEL = 4;
		final Integer WAITING_MARKETING_CONFIRM = 5;
	}
	
	public interface LOCALE{
		final String JP = "JP";
		final String VN = "VN";
		final String EN = "EN";
	}
	
	public interface REGISTRATION_TYPE{
		final String REAL = "REAL";
	}
	
	public interface HOSP_GROUP{
		final String DEMO = "DEMO";
		final String JP = "JP";
		final String VN = "VN";
	}
}
