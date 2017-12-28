package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.bass.BAS0111U00GrdBas0111ItemInfo;

/**
 * @author dainguyen.
 */
public interface Bas0111RepositoryCustom {
	public List<BAS0111U00GrdBas0111ItemInfo> getBAS0111U00GrdBas0111ItemInfo(String hospCode, String johapGubun, String johap, String language);
	
	public List<String> getNuroNuroOUT0101U02GetGaein(String hospCode, String johap, String gaein);
}

