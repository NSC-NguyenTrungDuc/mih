package nta.helper;



/**
 * @author DEV-TiepNM
 */
public enum Message {


    MESSAGE_DUPLICATE_EMAIL("fail.email.duplicate"),
    FACEBOOK_ID_IN_USED("facebook.id.in.used"),
    MESSAGE_ACCOUNT_ALREADY_ACTIVE("fail.email.aready.active"),
    SUCCESS("SUCCESS"),
    FAIL("FAIL");



    private String value;

    Message(String value) {
        this.value =value;
    }
    public String getValue()
    {
        return value;
    }

}
