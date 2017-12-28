package nta.med.data.dao.medi.ifs;

/**
 * @author dainguyen.
 */
public interface Ifs7303RepositoryCustom {

	public String callPrJihInjIfsProc(String hospCode, String ioGubun, Double fkdrg, String userId);

}
