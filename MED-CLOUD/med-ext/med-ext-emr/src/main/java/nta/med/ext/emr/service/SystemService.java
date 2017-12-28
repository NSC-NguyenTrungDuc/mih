package nta.med.ext.emr.service;

/**
 * @author DEV-TiepNM
 */
public interface SystemService {
    public boolean authenticate(String login, String password, String hospCode);
}
