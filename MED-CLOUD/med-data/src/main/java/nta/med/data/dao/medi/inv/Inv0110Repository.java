package nta.med.data.dao.medi.inv;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inv.Inv0110;

/**
 * @author dainguyen.
 */
@Repository
public interface Inv0110Repository extends JpaRepository<Inv0110, Long>, Inv0110RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Inv0110 SET chk3 = :f_drg_pack_yn, chk2 = :f_phamarcy, chk1 = :f_powder_yn,toijangYn = :f_hubal_change_yn "
			+ ",bunryu2 = :f_bunryu2, smallCode = :f_small_code, cautionCode = :f_caution_code, updId = :f_user_id "
			+ ",updDate = :f_upd_date WHERE jaeryoCode = :f_hangmog_code AND hospCode = :f_hosp_code")
	public Integer updateInv0110(@Param("f_drg_pack_yn") String chk3,
			@Param("f_phamarcy") String chk2,
			@Param("f_powder_yn") String chk1,
			@Param("f_hubal_change_yn") String toijangYn,
			@Param("f_bunryu2") String bunryu2,
			@Param("f_small_code") String smallCode,
			@Param("f_caution_code") String cautionCode,
			@Param("f_user_id") String updId,
			@Param("f_upd_date") Date updDate,
			@Param("f_hangmog_code") String jaeryoCode,
			@Param("f_hosp_code") String hospCode);
	
	@Query("SELECT 'Y' FROM Inv0110  WHERE jaeryoCode = :f_jaery_code AND hospCode = :f_hosp_code")
	public String checkInvenByJaeryCode(@Param("f_jaery_code") String jaeryoCode,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("DELETE FROM Inv0110  WHERE jaeryoCode = :f_jaery_code AND hospCode = :f_hosp_code")
	public Integer deleteInv0110ByJaeryoCode(@Param("f_jaery_code") String jaeryoCode,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("Update Inv0110 Set jaeryoName = :jaeryoName, jaeryoNameInx = :jaeryoNameInx "
			+ ", subulDanui = :subulDanui, stockYn = :stockYn, subulDanga = :subulDanga, jukyongDate = :jukyongDate, modifyFlg = :modifyFlg "
			+ "  WHERE jaeryoCode = :f_jaery_code AND hospCode = :f_hosp_code")
	public Integer updateInv0110ByJaeryoCode(@Param("jaeryoName") String jaeryoName,
			@Param("jaeryoNameInx") String jaeryoNameInx,
			@Param("subulDanui") String subulDanui,
			@Param("stockYn") String stockYn,
			@Param("subulDanga") Double subulDanga,
			@Param("jukyongDate") Date jukyongDate,
			@Param("modifyFlg") String modifyFlg,
			@Param("f_jaery_code") String jaeryoCode,
			@Param("f_hosp_code") String hospCode);
	
	
	@Modifying
	@Query("Update Inv0110 Set jaeryoName = :jaeryoName, jaeryoNameInx = :jaeryoNameInx, smallCode = :smallCode "
			+ ", subulDanui = :subulDanui, stockYn = :stockYn, subulDanga = :subulDanga, jukyongDate = :jukyongDate, modifyFlg = :modifyFlg , subulQcodeOut = :f_subul_qcode_out , subulQcodeInp = :f_subul_qcode_inp "
			+ "  WHERE jaeryoCode = :f_jaery_code AND hospCode = :f_hosp_code")
	public Integer updateInv0110ByJaeryoCode2(@Param("jaeryoName") String jaeryoName,
			@Param("jaeryoNameInx") String jaeryoNameInx,
			@Param("smallCode") String smallCode,
			@Param("subulDanui") String subulDanui,
			@Param("stockYn") String stockYn,
			@Param("subulDanga") Double subulDanga,
			@Param("jukyongDate") Date jukyongDate,
			@Param("modifyFlg") String modifyFlg,
			@Param("f_jaery_code") String jaeryoCode,
			@Param("f_subul_qcode_out") String subulQcodeOut,
			@Param("f_subul_qcode_inp") String subulQcodeInp,
			@Param("f_hosp_code") String hospCode);
	
	
	@Query("SELECT T FROM Inv0110 T WHERE T.hospCode = :hospCode AND T.jaeryoCode = :jaeryoCode")
	public List<Inv0110> findByHospCodeJaeryoCode(@Param("hospCode") String hospCode,
			@Param("jaeryoCode") String jaeryoCode);
	
}

