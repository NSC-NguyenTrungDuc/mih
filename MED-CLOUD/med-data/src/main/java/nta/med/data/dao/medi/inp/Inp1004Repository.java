package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp1004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp1004Repository extends JpaRepository<Inp1004, Long>, Inp1004RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Inp1004										"
			+ " SET updId       = :f_user_id						"
			+ "   , updDate     = SYSDATE()							"
			+ "   , name        = :f_name							"
			+ "   , zipCode1    = :f_zip_code1						"
			+ "   , zipCode2    = :f_zip_code2						"
			+ "   , address1    = :f_address1						"
			+ "   , address2    = :f_address2						"
			+ "   , tel1        = :f_tel1							"
			+ "   , tel2        = :f_tel2							"
			+ "   , bigo        = :f_bigo							"
			+ "   , boninGubun  = :f_bonin_gubun					"
			+ "   , tel3        = :f_tel3							"
			+ "   , telGubun    = :f_tel_gubun						"
			+ "   , telGubun2   = :f_tel_gubun2						"
			+ "   , telGubun3   = :f_tel_gubun3						"
			+ "   , name2       = :f_name2							"
			+ "   , priority    = :f_priority 						"
			+ "   , birth       = STR_TO_DATE(:f_birth, '%Y/%m/%d')	"
			+ "   , withYn      = :f_with_yn						"
			+ "   , liveYn      = :f_live_yn						"
			+ " WHERE hospCode = :f_hosp_code 						"
			+ "   AND bunho    = :f_bunho							"
			+ "   AND seq      = :f_seq								")
	public Integer updateInp1004ByBunhoSeq( @Param("f_user_id") String userId,
											@Param("f_name") String name,
											@Param("f_zip_code1") String zipCode1,
											@Param("f_zip_code2") String zipCode2,
											@Param("f_address1") String address1,
											@Param("f_address2") String address2,
											@Param("f_tel1") String tel1,
											@Param("f_tel2") String tel2,
											@Param("f_bigo") String bigo,
											@Param("f_bonin_gubun") String boninGubun,
											@Param("f_tel3") String tel3,
											@Param("f_tel_gubun") String telGubun,
											@Param("f_tel_gubun2") String telGubun2,
											@Param("f_tel_gubun3") String telGubun3,
											@Param("f_name2") String name2,
											@Param("f_priority") Double priority,
											@Param("f_birth") String birth,
											@Param("f_with_yn") String withYn,
											@Param("f_live_yn") String liveYn,
											@Param("f_hosp_code") String hospCode,
											@Param("f_bunho") String bunho,
											@Param("f_seq") Double seq);
	
	
	@Modifying
	@Query("DELETE FROM Inp1004 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND seq = :f_seq")
	public Integer deleteInp1004ByBunhoSeq( @Param("f_hosp_code") String hospCode,
											@Param("f_bunho") String bunho,
											@Param("f_seq") Double seq);
}

