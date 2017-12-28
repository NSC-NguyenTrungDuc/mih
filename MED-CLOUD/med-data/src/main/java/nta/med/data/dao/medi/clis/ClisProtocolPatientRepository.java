package nta.med.data.dao.medi.clis;

import java.util.Date;

import nta.med.core.domain.clis.ClisProtocolPatient;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface ClisProtocolPatientRepository  extends JpaRepository<ClisProtocolPatient, Long>, ClisProtocolPatientRepositoryCustom {
	@Query("SELECT COUNT(protocolPatientId) FROM ClisProtocolPatient WHERE activeFlg = 1 AND clisProtocolId= :clisProtocolId AND hospCode = :hospCode")
	public Integer countPatient(@Param("clisProtocolId") Integer clisProtocolId,@Param("hospCode") String hospCode);
	@Modifying
	@Query("UPDATE ClisProtocolPatient SET   activeFlg = 0, updId = :f_user_id, updated = :f_upd_date WHERE clisProtocolId = :f_protocol_id AND bunho = :f_bunho")
	public Integer updateClisProtocolPatient(@Param("f_user_id") String updId, @Param("f_upd_date") Date updated, 
			@Param("f_protocol_id") Integer clisProtocolId, @Param("f_bunho") String bunho);
	
}
