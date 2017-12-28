package nta.med.data.dao.medi.ocs;

/**
 * @author dainguyen.
 */
public interface Ocs6015RepositoryCustom {

	public String checkDupOcs6015InOcs6010U10(String hospCode, Double fkocs6010, Double jaewonil, String inputGubun,
			String orderGubun, String hangmogCode);

	public Double getNextSeqOcs6015(String hospCode, Double fkocs6010, Double jaewonil, String inputGubun);

	public String checkPlanFromDateInOcs6010U10(String hospCode, Double fkocs6010, Double jaewonil, String inputGubun,Double pk, String orderDate);

	public int updateOcs6015InOcs6010U10Case02(String hospCode, Double fkocs6010, Double jaewonil, String inputGubun, Double pk, String orderDate);
	
}
