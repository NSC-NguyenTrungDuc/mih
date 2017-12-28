package nta.med.data.dao.medi.clis;

import java.util.List;

import nta.med.core.domain.clis.ClisProtocol;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface ClisProtocolRepository extends JpaRepository<ClisProtocol, Long>, ClisProtocolRepositoryCustom{
	@Query("SELECT protocolCode FROM ClisProtocol WHERE activeFlg = 1 AND protocolCode= :protocolCode AND hospCode = :hospCode AND clisProtocolId != :clisProtocolId")
	public List<String> validateProtocolCode(@Param("protocolCode") String protocolCode,@Param("hospCode") String hospCode,@Param("clisProtocolId") Long clisProtocolId);
	
	@Query("SELECT protocolCode FROM ClisProtocol WHERE activeFlg = 1 AND protocolCode= :protocolCode AND hospCode = :hospCode")
	public List<String> validateInsertProtocolCode(@Param("protocolCode") String protocolCode,@Param("hospCode") String hospCode);
}
