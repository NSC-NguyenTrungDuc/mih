package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.core.domain.cpl.Cplreq1;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cplreq1Repository extends JpaRepository<Cplreq1, Long>, Cplreq1RepositoryCustom {

	@Modifying
	@Query(" UPDATE Cplreq1 SET curSendYn = 'N' WHERE requestDate  = SYSDATE() ")
	public Integer updateCPL3010U01IsWriteFileUpdateNoParam();
	
	@Modifying
	@Query(" UPDATE Cplreq1 SET sysDate = SYSDATE(), updId  = :f_user_id, requestDate = SYSDATE() , requestId   = :f_user_id, "
			+ " bunho  = :f_bunho, jubsuDate  = :f_jubsu_date, jubsuTime = :f_jubsu_time, "
			+ "hangmogCnt  = :f_hangmog_cnt , urine = :f_urine , sendYn  = :f_send_yn, curSendYn  = :f_send_yn WHERE requestKey  = :f_request_key " )
	public Integer updateCPL3010U01IsWriteFileSelectOrUpdate(@Param("f_user_id") String userId,@Param("f_bunho") String bunho,@Param("f_jubsu_date") String jubsuDate ,
			@Param("f_jubsu_time") String jubsuTime,@Param("f_hangmog_cnt") String hangmogCnt,@Param("f_urine") String urine,@Param("f_send_yn") String sendYn,
			@Param("f_request_key") String requestKey);
	@Query("SELECT 'Y'  FROM Cplreq1  WHERE requestKey = :f_request_key ")
	public List<String> getYValue(@Param("f_request_key") String requestKey);
}

