package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.bass.BAS0270GrdBAS0271Info;

/**
 * @author dainguyen.
 */
public interface Bas0271RepositoryCustom {
	public List<BAS0270GrdBAS0271Info > getBAS0270GrdBAS0271Info (String hospCode, String language, String doctorYmd, String doctorName);
}

