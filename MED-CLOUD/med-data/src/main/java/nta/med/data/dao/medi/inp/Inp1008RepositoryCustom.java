package nta.med.data.dao.medi.inp;

/**
 * @author dainguyen.
 */
public interface Inp1008RepositoryCustom {

	public Integer recordCount(String hospCode, Double fkinp1002, String gonbiCode);

	public Integer updateInInp1001U01(String hospCode, Double fkinp1002, String gonbiCode);

	public Integer deleteInInp1001U01(String hospCode, Double fkinp1002, String gonbiCode);
}

