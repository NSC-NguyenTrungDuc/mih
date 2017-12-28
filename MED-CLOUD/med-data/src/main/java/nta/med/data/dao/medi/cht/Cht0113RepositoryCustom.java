package nta.med.data.dao.medi.cht;

import java.util.List;

import nta.med.data.model.ihis.chts.CHT0113Q00GrdCHT0113Info;

/**
 * @author dainguyen.
 */
public interface Cht0113RepositoryCustom {
	public List<CHT0113Q00GrdCHT0113Info> getCHT0113Q00GrdCHT0113Info (String disabilityName, String date);
}

