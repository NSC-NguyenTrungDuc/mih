package nta.med.data.dao.medi.nur;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0805;

@Repository
public interface Nur0805Repository extends JpaRepository<Nur0805, Long>, Nur0805RepositoryCustom {
	
	@Modifying
	@Query(   " UPDATE Nur0805 A                                "
			+ "    SET A.updId            = :f_user_id          "
			+ "      , A.updDate          = SYSDATE()           "
			+ "      , A.needSoName       = :f_need_so_name     "
			+ "      , A.needSoPoint      = :f_need_so_point    "
			+ "      , A.sortKey          = :f_sort_key         "
			//+ "      , A.hFileFlag        = :f_h_file_flag      "
			+ "  WHERE A.hospCode         = :f_hosp_code        "
			+ "    AND A.needGubun        = :f_need_gubun       "
			+ "    AND A.needAsmtCode     = :f_need_asmt_code   "
			+ "    AND A.needResultCode   = :f_need_result_code "
			+ "    AND A.needSoCode       = :f_need_so_code     "
			+ "    AND A.startDate        = :f_start_date       ")
	public Integer updateNUR0803U01(@Param("f_user_id") String updId,
									@Param("f_need_so_name") 	    String needSoName    ,
									@Param("f_need_so_point") 	    Double needSoPoint   ,
									@Param("f_sort_key") 		    Double sortKey       ,
									//@Param("f_h_file_flag") 	    String hFileFlag     ,
									@Param("f_hosp_code") 		    String hospCode      ,
									@Param("f_need_gubun") 		    String needGubun     ,
									@Param("f_need_asmt_code") 	    String needAsmtCode  ,
									@Param("f_need_result_code") 	String needResultCode,
									@Param("f_need_so_code") 		String needSoCode    ,
									@Param("f_start_date") 			Date startDate     );
	
	@Modifying
	@Query(   " DELETE Nur0805                                "
			+ "  WHERE hospCode         = :f_hosp_code        "
			+ "    AND needGubun        = :f_need_gubun       "
			+ "    AND needAsmtCode     = :f_need_asmt_code   "
			+ "    AND needResultCode   = :f_need_result_code "
			+ "    AND needSoCode       = :f_need_so_code     "
			+ "    AND startDate        = :f_start_date       ")
	public Integer deleteNUR0803U01(@Param("f_hosp_code") 		    String hospCode      ,
									@Param("f_need_gubun") 		    String needGubun     ,
									@Param("f_need_asmt_code") 	    String needAsmtCode  ,
									@Param("f_need_result_code") 	String needResultCode,
									@Param("f_need_so_code") 		String needSoCode    ,
									@Param("f_start_date") 			Date startDate     );
}
