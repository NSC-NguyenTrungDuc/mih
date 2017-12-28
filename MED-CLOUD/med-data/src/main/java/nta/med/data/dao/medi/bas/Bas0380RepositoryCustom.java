package nta.med.data.dao.medi.bas;

import java.util.Date;

/**
 * @author dainguyen.
 */
public interface Bas0380RepositoryCustom {
	public String checkHangSangInfo(String hospCode, String hangmogCode, String sangCode, Date checkDate, String inOutGubun,
			String gwa, Date birthDate);
}

