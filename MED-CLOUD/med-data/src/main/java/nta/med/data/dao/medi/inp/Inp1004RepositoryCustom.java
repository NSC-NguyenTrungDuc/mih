package nta.med.data.dao.medi.inp;

import java.util.List;

import nta.med.data.model.ihis.inps.INP1001U01GrdInp1004Info;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdINP1004Info;

/**
 * @author dainguyen.
 */
public interface Inp1004RepositoryCustom {
	
	public List<INP1001U01GrdInp1004Info> getINP1001U01GrdInp1004Info(String hospCode, String language, String bunho, Integer startNum, Integer offset);
	public Double getNextSeqInp1004ByBunho(String hospCode, String bunho);
	public List<NUR1001U00GrdINP1004Info> getNUR1001U00GrdINP1004Info(String hospCode, String language, String bunho, Integer startNum, Integer offset);
}
