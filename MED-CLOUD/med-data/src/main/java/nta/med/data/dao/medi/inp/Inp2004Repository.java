package nta.med.data.dao.medi.inp;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inp.Inp2004;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp2004Repository extends JpaRepository<Inp2004, Long>, Inp2004RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Inp2004 SET updDate = SYSDATE(), updId = :f_user_id, cancelYn = :f_cancel_yn "
			+ "WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fkinp1001 = :f_fkinp1001 AND toNurseConfirmDate IS NULL")
	public Integer updateInp2004NUR2004U00ConfirmTransCancel(@Param("f_user_id") String userId,
															 @Param("f_cancel_yn") String cancelYn, 
															 @Param("f_hosp_code") String hospCode,
															 @Param("f_bunho") String bunho,
															 @Param("f_fkinp1001") Double fkinp1001);

	@Query("SELECT T FROM Inp2004 T WHERE T.hospCode = :hospCode AND T.fkinp1001 = :fkinp1001 AND T.transCnt = :transCnt ")
	public List<Inp2004> findByHospCodeFkinp1001TransCnt(@Param("hospCode") String hospCode,
														 @Param("fkinp1001") Double fkinp1001,
														 @Param("transCnt") Double transCnt);
	
	@Modifying
	@Query("UPDATE Inp2004 SET updDate = SYSDATE(), updId = :f_user_id, cancelYn = :f_cancel_yn "
			+ "WHERE hospCode = :f_hosp_code AND fkinp1001 = :f_fkinp1001 AND toNurseConfirmDate IS NULL")
	public Integer updateInp2004NUR1010Q00ConfirmTransCancel(@Param("f_user_id") String userId,
															 @Param("f_cancel_yn") String cancelYn, 
															 @Param("f_hosp_code") String hospCode,
															 @Param("f_fkinp1001") Double fkinp1001);
	
}

