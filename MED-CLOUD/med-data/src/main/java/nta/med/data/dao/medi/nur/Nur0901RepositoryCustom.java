package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR9001U00layBojoListInfo;

/**
 * @author dainguyen.
 */
public interface Nur0901RepositoryCustom {

	public List<NUR9001U00layBojoListInfo> getNUR9001U00layBojoListInfo(String hospCode, String soapGubun, String hoDong);
}

