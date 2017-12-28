package nta.med.data.dao.medi.nut;

import java.util.List;

import nta.med.data.model.ihis.nuts.Nut0001U00GrdNut0002ItemInfo;

/**
 * @author dainguyen.
 */
public interface Nut0002RepositoryCustom {
	
	public List<Nut0001U00GrdNut0002ItemInfo> getNut0001U00GrdNut0002ItemInfo(String hospCode, Double pkocsKey);
}

