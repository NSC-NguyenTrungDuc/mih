package nta.med.data.dao.medi.ifs;

import java.util.List;

/**
 * @author dainguyen.
 */
public interface Ifs3014RepositoryCustom {
	public List<Double> getINPBATCHTRANSOrderTransInfo(String hospCode, String fkinp3010, String transGubun, String ifFlag);
	public List<Double> getINPORDERTRANSSangTrans(String hospCode, Double fkinp3010, String transGubun);
}

