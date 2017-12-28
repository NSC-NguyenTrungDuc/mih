package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.core.domain.ocs.Ocs1003C;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridReserOrderListInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayoutQueryInfo;

public interface Ocs1003cRepositoryCustom {

	public List<OcsoOCS1003P01LayoutQueryInfo> getOcsoOCS1003P01LayoutQueryInfo(String language, String hospCode, String bunho, Double fkout1001, String queryGubun, String inputGubun, String groupCode);
	
	public List<OcsoOCS1003P01GridReserOrderListInfo> getOcsoOCS1003P01GridReserOrderList(String language, String hospCode, String bunho, String naewonDate);

	public List<Ocs1003C> getByHospCodeAndFks0201(String hospCode, Double fksch0201) ;
	
	public List<OcsoOCS1003P01LayoutQueryInfo> getOcsoOCS1003P01LayoutQueryInfo(String language, String hospCode, String bunho, Double fkout1001, String queryGubun, String inputGubun);
}
