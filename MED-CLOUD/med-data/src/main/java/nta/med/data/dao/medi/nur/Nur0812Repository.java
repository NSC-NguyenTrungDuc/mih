package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0812;

@Repository
public interface Nur0812Repository extends JpaRepository<Nur0812, Long>, Nur0812RepositoryCustom {

	@Query("SELECT T FROM Nur0812 T WHERE hospCode = :hospCode AND needHType = :needHType AND needGubun = :needGubun AND needAsmtCode = :needAsmtCode")
	public List<Nur0812> findByNeedHTypeNeedGubunNeedAsmtCode(@Param("hospCode") String hospCode,
															  @Param("needHType") String needHType,
															  @Param("needGubun") String needGubun,
															  @Param("needAsmtCode") String needAsmtCode);
	
	@Modifying
	@Query("	UPDATE Nur0812 A					    "
			+ "	SET payloadNo       = :f_payload_no	    "
			+ "	WHERE hospCode      = :f_hosp_code	    "
			+ "	  AND needHType     = :f_need_h_type    "
			+ "	  AND needGubun     = :f_need_gubun	    "
			+ "	  AND needAsmtCode  = :f_need_asmt_code ")
	public Integer updatePayloadNoNUR0812U00(@Param("f_payload_no") String payloadNo,
											 @Param("f_hosp_code") String hospCode,
											 @Param("f_need_h_type") String needHType,
											 @Param("f_need_gubun") String needGubun,
											 @Param("f_need_asmt_code") String needAsmtCode);
	
	@Modifying
	@Query("	DELETE Nur0812 					    	"
			+ "	WHERE hospCode      = :f_hosp_code	    "
			+ "	  AND needHType     = :f_need_h_type    "
			+ "	  AND needGubun     = :f_need_gubun	    "
			+ "	  AND needAsmtCode  = :f_need_asmt_code ")
	public Integer deleteNUR0812U00(@Param("f_hosp_code") String hospCode,
									@Param("f_need_h_type") String needHType,
									@Param("f_need_gubun") String needGubun,
									@Param("f_need_asmt_code") String needAsmtCode);
	
}
