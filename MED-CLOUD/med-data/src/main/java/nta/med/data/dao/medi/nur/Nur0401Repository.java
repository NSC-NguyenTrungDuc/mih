package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0401;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0401Repository extends JpaRepository<Nur0401, Long>, Nur0401RepositoryCustom {
	
	@Query("SELECT T FROM Nur0401 T WHERE T.hospCode = :hospCode AND T.nurPlanBunryu = :nurPlanBunryu ORDER BY IFNULL(SORT_KEY, 99), nurPlanJin")
	public List<Nur0401> findByHospCodeNurPlanBunryu(@Param("hospCode") String hospCode, 
													 @Param("nurPlanBunryu") String nurPlanBunryu);
	
	@Query("SELECT T FROM Nur0401 T WHERE T.hospCode = :hospCode AND T.nurPlanJin = :nurPlanJin")
	public List<Nur0401> findByHospCodeNurPlanJin(@Param("hospCode") String hospCode, 
												  @Param("nurPlanJin") String nurPlanJin);
	
	@Modifying
	@Query("UPDATE Nur0401 SET updId = :updId, updDate = SYSDATE(), vald = :vald WHERE hospCode = :hospCode AND nurPlanBunryu = :nurPlanBunryu")
	public Integer updateValdByHospCodeNurPlanBunryu(@Param("updId") String updId,
													 @Param("vald") String vald,
													 @Param("hospCode") String hospCode,
													 @Param("nurPlanBunryu") String nurPlanBunryu);
	
	@Modifying
	@Query("DELETE Nur0401 WHERE hospCode = :hospCode AND nurPlanBunryu = :nurPlanBunryu")
	public Integer deleteByHospCodeNurPlanBunryu(@Param("hospCode") String hospCode,
			 									 @Param("nurPlanBunryu") String nurPlanBunryu);
	
	@Modifying
	@Query("UPDATE Nur0401 SET updId = :updId, "
			+ "updDate = SYSDATE(), "
			+ "nurPlanJinName = :nurPlanJinName, "
			+ "nurPlanBunryu = :nurPlanBunryu, "
			+ "vald = :vald, "
			+ "sortKey = :sortKey "
			+ "WHERE hospCode = :hospCode "
			+ "AND nurPlanJin = :nurPlanJin")
	public Integer updateNur0401ByHospCodeNurPlanJin(@Param("updId") String updId,
													 @Param("nurPlanJinName") String nurPlanJinName, 
													 @Param("nurPlanBunryu") String nurPlanBunryu,
													 @Param("vald") String vald, 
													 @Param("sortKey") Double sortKey, 
													 @Param("hospCode") String hospCode,
													 @Param("nurPlanJin") String nurPlanJin);
	
	@Modifying
	@Query("DELETE Nur0401 WHERE hospCode = :hospCode AND nurPlanJin = :nurPlanJin")
	public Integer deleteByHospCodeNurPlanJin(@Param("hospCode") String hospCode,
			 								  @Param("nurPlanJin") String nurPlanJin);
	
	@Query("SELECT T FROM Nur0401 T WHERE T.hospCode = :hospCode AND T.nurPlanBunryu = :nurPlanBunryu AND T.nurPlanJin = :nurPlanJin AND T.vald = :vald ")
	public List<Nur0401> findByHospCodeNurPlanBunryuNurPlanJinVald(@Param("hospCode") 		String hospCode, 
																   @Param("nurPlanBunryu") 	String nurPlanBunryu,
																   @Param("nurPlanJin") 	String nurPlanJin,
																   @Param("vald") 			String vald);
	
}

