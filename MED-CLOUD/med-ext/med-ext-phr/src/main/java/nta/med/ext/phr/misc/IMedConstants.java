package nta.med.ext.phr.misc;

public interface IMedConstants {
	public interface MAIL_CODE {
		final String CONFIRM_DEMO = "CONFIRM_DEMO";
		final String CONTACT = "CONTACT";
		final String REPLY_CONTACT = "REPLY_CONTACT";
		final String ACCOUNT_REGISTER = "DEMO_ACCOUNT_INFORMATION";
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
	}
}
