package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0804;

@Repository
public interface Nur0804Repository extends JpaRepository<Nur0804, Long>, Nur0804RepositoryCustom {

	@Query("SELECT T FROM Nur0804 T WHERE T.hospCode = :hospCode AND T.needGubun = :needGubun AND T.needAsmtCode = :needAsmtCode AND T.needResultCode = :needResultCode AND T.startDate = :startDate")
	public List<Nur0804> findByHospCodeNeedGubunNeedAsmtCodeNeedResultCodeStartDate(@Param("hospCode") String hospCode,
																					@Param("needGubun") String needGubun,
																					@Param("needAsmtCode") String needAsmtCode,
																					@Param("needResultCode") String needResultCode,
																					@Param("startDate") Date startDate);
	
	@Modifying
	@Query(   " UPDATE Nur0804 A                                 "
			+ "    SET A.updId            = :f_user_id           "
			+ "      , A.updDate          = SYSDATE()            "
			+ "      , A.needResultName   = :f_need_result_name  "
			+ "      , A.sumGubun         = :f_sum_gubun         "
			+ "      , A.sortKey          = :f_sort_key          "
			+ "      , A.globalYn         = :f_global_yn         "
			+ "  WHERE A.hospCode         = :f_hosp_code         "
			+ "    AND A.needGubun        = :f_need_gubun        "
			+ "    AND A.needAsmtCode     = :f_need_asmt_code    "
			+ "    AND A.needResultCode   = :f_need_result_code  "
			+ "    AND A.startDate        = :f_start_date        ")
	public Integer updateByHospCodeNeedGubunNeedAsmtCodeNeedResultCodeStartDate(@Param("f_user_id") 			String updId		 ,
																				@Param("f_need_result_name") 	String needResultName,
																				@Param("f_sum_gubun") 			String sumGubun      ,
																				@Param("f_sort_key") 			Double sortKey       ,
																				@Param("f_global_yn") 			String globalYn      ,
																				@Param("f_hosp_code") 			String hospCode      ,
																				@Param("f_need_gubun") 			String needGubun     ,
																				@Param("f_need_asmt_code") 		String needAsmtCode  ,
																				@Param("f_need_result_code") 	String needResultCode,
																				@Param("f_start_date") 			Date startDate);
	
	@Modifying
	@Query(   " DELETE Nur0804								   "
			+ "  WHERE hospCode         = :f_hosp_code         "
			+ "    AND needGubun        = :f_need_gubun        "
			+ "    AND needAsmtCode     = :f_need_asmt_code    "
			+ "    AND needResultCode   = :f_need_result_code  "
			+ "    AND startDate        = :f_start_date        ")
	public Integer deleteByHospCodeNeedGubunNeedAsmtCodeNeedResultCodeStartDate(@Param("f_hosp_code") 			String hospCode      ,
																				@Param("f_need_gubun") 			String needGubun     ,
																				@Param("f_need_asmt_code") 		String needAsmtCode  ,
																				@Param("f_need_result_code") 	String needResultCode,
																				@Param("f_start_date") 			Date startDate);
}
