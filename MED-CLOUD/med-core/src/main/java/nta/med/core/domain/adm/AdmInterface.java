package nta.med.core.domain.adm;

import java.util.Date;

/**
 * @author Tiepnm
 */
public interface AdmInterface {
    public String getA3();
    public String getA1();
    public String getA6();
    public String getA2();
    public void setSysDate(Date sysDate);
    public void setSysId(String sysId);
    public String getSysId();
}
