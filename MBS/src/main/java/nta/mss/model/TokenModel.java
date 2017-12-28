package nta.mss.model;

/**
 * @author DEV-TiepNM
 */
public class TokenModel {

    private static final long serialVersionUID = -5037078490064972442L;

    private String mbsToken;
    private String phrToken;

    public String getPhrToken() {
        return phrToken;
    }

    public void setPhrToken(String phrToken) {
        this.phrToken = phrToken;
    }

    public String getMbsToken() {
        return mbsToken;
    }

    public void setMbsToken(String mbsToken) {
        this.mbsToken = mbsToken;
    }
}
