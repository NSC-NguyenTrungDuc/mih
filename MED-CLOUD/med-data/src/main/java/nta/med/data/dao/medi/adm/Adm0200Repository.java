package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.core.domain.adm.Adm0200;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0200Repository extends JpaRepository<Adm0200, Long>, Adm0200RepositoryCustom {
	@Modifying
	@Query("DELETE Adm0200 WHERE language = :f_language AND sysId = :f_sys_id ")
	public Integer deleteADM101USavePerformerCase2(@Param("f_language") String language,@Param("f_sys_id") String sysId);
	
	@Modifying
	@Query("UPDATE Adm0200 SET grpId = :f_grp_id ,sysNm = :f_sys_nm , "
			+ "admSysYn = :f_adm_sys_yn ,msgSysYn = :f_msg_sys_yn , "
			+ "sysSeq    = :f_sys_seq ,sysDesc   = :f_sys_desc , "
			+ "mangDept  = :f_mang_dept ,mangDept1 = :f_mang_dept1 , "
			+ "upMemb    = :f_user_id ,upTime = SYSDATE() WHERE language = :f_language AND sysId = :f_sys_id ")
	public Integer updateADM101USavePerformerCase2(@Param("f_language") String language,@Param("f_grp_id") String grpId,
			@Param("f_sys_nm") String sysNm,@Param("f_adm_sys_yn") String admSysYn,@Param("f_msg_sys_yn") String msgSysYn,
			@Param("f_sys_seq") Double sysSeq,@Param("f_sys_desc") String sysDesc,@Param("f_mang_dept") String mangDept,
			@Param("f_mang_dept1") String mangDept1,@Param("f_user_id") String upMemb,@Param("f_sys_id") String sysId);
	
	@Query("select a FROM Adm0200 a ORDER BY sysId")
	public List<Adm0200> findAllOrderBySysId();
	
	@Query("select sysNm FROM Adm0200  WHERE language = :f_language AND sysId = :sysId ")
	public List<String> findSysNm(@Param("f_language") String language,@Param("sysId") String sysId);
}

