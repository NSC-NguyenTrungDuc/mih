package nta.med.data.dao.medi.nut;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuts.NUT9001U00grdINP5001Info;

/**
 * @author dainguyen.
 */
public interface Nut2011RepositoryCustom {

	public List<NUT9001U00grdINP5001Info> getNUT9001U00grdINP5001Info(String hospCode, Date magamDate);

	public String getMaxMagamSeqByHospCodeNutDateBldGubun(String hospCode, Date nutDate, String bldGubun);
}
