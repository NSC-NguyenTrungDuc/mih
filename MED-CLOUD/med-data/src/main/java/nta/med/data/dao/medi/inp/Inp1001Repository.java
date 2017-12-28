package nta.med.data.dao.medi.inp;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inp.Inp1001;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp1001Repository extends JpaRepository<Inp1001, Long>, Inp1001RepositoryCustom {
	@Query("select a from Inp1001 a where hospCode = :hospCode AND bunho = :bunho AND jaewonFlag = 'Y' "
			+ "AND IFNULL(cancelYn, 'N') <> 'Y' AND ipwonType <> '2' order by ipwonDate desc ")
	public List<Inp1001> getPatientInfo(
			@Param("hospCode") String hospCode,
			@Param("bunho") String bunho);
	
	@Modifying
	@Query("UPDATE Inp1001 SET chojae = :f_chojae WHERE hospCode = :hospCode AND pkinp1001 = :f_pk1001")
	public Integer oRDERTRANProcessRequiUpdateInp1001(
			@Param("hospCode") String hospCode,
			@Param("f_pk1001") Double pk1001);
	
	@Query("SELECT CASE WHEN toiwonResDate IS NULL THEN CASE IFNULL(toiwonGojiYn,'N') WHEN 'Y' THEN 'Y' ELSE 'N' END ELSE 'Y' END "
			+ "FROM Inp1001 A "
			+ "WHERE hospCode = :f_hosp_code 	"
			+ "  AND pkinp1001 = :f_fkinp1001	")
	public List<String> getOBIsToiwonResYn(@Param("f_hosp_code") String hospCode
										,@Param("f_fkinp1001") Double fkinp1001);
	
	@Query("SELECT T FROM Inp1001 T WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND ipwonDate = STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d') ")
	public List<Inp1001> findByHospCodeBunhoIpwonDate(@Param("f_hosp_code") String hospCode
													, @Param("f_bunho") String bunho
													, @Param("f_ipwon_date") String ipwonDate);
	
	@Query("SELECT T FROM Inp1001 T WHERE hospCode = :f_hosp_code AND hoDong1 = :f_ho_dong1 AND hoCode1 = :f_ho_code1 AND bedNo = :f_bed_no AND jaewonFlag = 'Y' AND IFNULL(cancelYn, 'N') = 'N' AND IFNULL(toiwonCancelYn, 'N') = 'N' ")
	public List<Inp1001> findByHospCodeHoDong1HoCode1BedNo(	@Param("f_hosp_code") String hospCode,
															@Param("f_ho_dong1") String hoDong1,
															@Param("f_ho_code1") String hoCode1, 
															@Param("f_bed_no") String bedNo);
	
	@Query("SELECT T FROM Inp1001 T WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND jaewonFlag = :f_jaewon_flag AND IFNULL(cancelYn, 'N') = 'N' AND ipwonType = :f_ipwon_type ")
	public List<Inp1001> findByHospCodeBunhoJaewonFlagIpwonType(@Param("f_hosp_code") String hospCode,
																@Param("f_bunho") String bunho,
																@Param("f_jaewon_flag") String jaewonFlag,
																@Param("f_ipwon_type") String ipwonType);
	
	@Query("SELECT T FROM Inp1001 T WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND pkinp1001 = :f_pkinp1001 ")
	public List<Inp1001> findByHospCodeBunhoPkinp1001(@Param("f_hosp_code") String hospCode,
													  @Param("f_bunho") String bunho,
													  @Param("f_pkinp1001") Double pkinp1001);
	
	@Modifying
	@Query("UPDATE Inp1001 SET updId = :userId , updDate = SYSDATE() , resultAfterDis = :resultAfterDis , resultAfterDisRemark = :resultAfterDisRemark   WHERE hospCode = :hospCode AND pkinp1001 = :f_pk1001")
	public Integer updateINPINP3003U00U00Execute(
			@Param("hospCode") String hospCode,
			@Param("userId") String userId,
			@Param("f_pk1001") Double pk1001,
			@Param("resultAfterDis") String resultAfterDis,
			@Param("resultAfterDisRemark") String resultAfterDisRemark);
	
	@Modifying
	@Query("UPDATE Inp1001 SET updId = :f_userId , updDate = SYSDATE() , gwa = :f_gwa , doctor = :f_doctor, resident = :f_doctor, toiwonDate = :f_toiwon_date  WHERE hospCode = :hospCode AND pkinp1001 = :f_pk1001")
	public Integer updateINP1001U01EtcIpwonExecute(
			@Param("hospCode") String hospCode,
			@Param("f_userId") String userId,
			@Param("f_pk1001") Double pk1001,
			@Param("f_gwa") String gwa,
			@Param("f_doctor") String doctor,
			@Param("f_toiwon_date") Date toiwonDate);
	
	@Modifying
	@Query("UPDATE Inp1001 SET updId = :f_userId , updDate = SYSDATE() , cancelDate = SYSDATE(), cancelUser = :f_userId, cancelYn = 'Y' WHERE hospCode = :hospCode AND pkinp1001 = :f_pk1001")
	public Integer deleteINP1001U01EtcIpwonExecute(
			@Param("hospCode") String hospCode,
			@Param("f_userId") String userId,
			@Param("f_pk1001") Double pk1001);
	
	@Query("SELECT pkinp1001  FROM Inp1001 A WHERE bunho = :bunho AND jaewonFlag = :jaewonFlag  AND hospCode = :hospCode  ORDER BY A.pkinp1001 DESC")
	public List<Double> getPkinp1001ByBunhoAndJaewonFlag(
			@Param("hospCode") String hospCode,
			@Param("bunho") String bunho,
			@Param("jaewonFlag") String jaewonFlag);
	
	@Modifying
	@Query("UPDATE Inp1001 SET updId = :f_userId , updDate = SYSDATE() , " 
				+ " toiwonResDate = :f_toiwon_res_date , toiwonResTime = :f_toiwon_res_time ,  " 
				+ " toiwonGojiYn = :f_toiwon_goji_yn , sigiMagamDate = :f_sigi_magam_date ,  "
				+ " sigiMagamYn = :f_sigi_magam_date2 ,  "
				+ " kiGubun = :f_ki_gubun , result = :f_result   "
				+ " WHERE hospCode = :hospCode AND bunho = :f_bunho AND IFNULL(cancelYn, 'N') = 'N' AND jaewonFlag = 'Y' ")
	public Integer updateINP1001U01OCS2003U99SaveLayout(
			@Param("hospCode") String hospCode,
			@Param("f_userId") String userId,
			@Param("f_toiwon_res_date") Date toiwonResDate,
			@Param("f_toiwon_res_time") String toiwonResTime,
			@Param("f_toiwon_goji_yn") String toiwonGojiYn,
			@Param("f_sigi_magam_date") Date sigiMagamDate,
			@Param("f_sigi_magam_date2") String sigiMagamDate2,
			@Param("f_ki_gubun") String kiGubun,
			@Param("f_result") String result,
			@Param("f_bunho") String bunho);
	
	@Modifying
	@Query("UPDATE Inp1001 SET updId = :f_userId , updDate = SYSDATE() , " 
				+ " toiwonResDate = :f_toiwon_res_date , toiwonResTime = :f_toiwon_res_time ,  " 
				+ " toiwonGojiYn = :f_toiwon_goji_yn , sigiMagamDate = :f_sigi_magam_date ,  "
				+ " sigiMagamYn = :f_sigi_magam_date2 ,  "
				+ " kiGubun = :f_ki_gubun , result = :f_result   "
				+ " WHERE hospCode = :hospCode AND pkinp1001 = :f_fkinp1001 ")
	public Integer updateINP1001U01OCS2003U99SaveLayoutExt(
			@Param("hospCode") String hospCode,
			@Param("f_userId") String userId,
			@Param("f_toiwon_res_date") Date toiwonResDate,
			@Param("f_toiwon_res_time") String toiwonResTime,
			@Param("f_toiwon_goji_yn") String toiwonGojiYn,
			@Param("f_sigi_magam_date") Date sigiMagamDate,
			@Param("f_sigi_magam_date2") String sigiMagamDate2,
			@Param("f_ki_gubun") String kiGubun,
			@Param("f_result") String result,
			@Param("f_fkinp1001") Double fkinp1001);
	
	@Modifying
	@Query("UPDATE Inp1001 SET updId = :f_userId , updDate = SYSDATE() , " 
				+ " gwa = TRIM(:f_to_gwa) , doctor = :f_to_doctor ,  " 
				+ " resident = :f_to_resident , hoCode1 = :f_to_ho_code1 , hoDong1 = :f_to_ho_dong1 ,   "
				+ " bedNo = :f_to_bed_no , bedNo2 = :f_to_bed_no2 , hoCode2 = :f_to_ho_code2 , hoDong2 = :f_to_ho_dong2 , "
				+ " hoGrade1 = :f_to_ho_grade1 , hoGrade2 = :f_to_ho_grade_2 , kaikeiHodong = :f_to_kaikei_hodong , kaikeiHocode = :f_to_kaikei_hocode "
				+ " WHERE hospCode = :hospCode AND pkinp1001 = :f_pkinp1001 ")
	public Integer updateNUR2004U01GetSubConfirmData4(
			@Param("hospCode") String hospCode,
			@Param("f_userId") String userId,
			@Param("f_to_gwa") String toGwa,
			@Param("f_to_doctor") String toDoctor,
			@Param("f_to_resident") String toResident,
			@Param("f_to_ho_code1") String toHoCode1,
			@Param("f_to_ho_dong1") String toHoDong1,
			@Param("f_to_bed_no") String toBedNo,
			@Param("f_to_bed_no2") String toBedNo2,
			@Param("f_to_ho_code2") String toHoCode2,
			@Param("f_to_ho_dong2") String toHoDong2,
			@Param("f_to_ho_grade1") String toHoGrade1,
			@Param("f_to_ho_grade_2") String toHoGrade2,
			@Param("f_to_kaikei_hodong") String toKaikeiHodong,
			@Param("f_to_kaikei_hocode") String toKaikeiHocode,
			@Param("f_pkinp1001") Double pkinp1001);
	
	@Modifying
	@Query("UPDATE Inp1001 SET cycleOrderGroup = :cycleOrderGroup WHERE hospCode = :hospCode AND pkinp1001 = :pkinp1001")
	public Integer updateCycleOrderGroupByPkInp1001(@Param("hospCode") String hospCode,
													@Param("pkinp1001") Double pkinp1001,
													@Param("cycleOrderGroup") String cycleOrderGroup);
	
	@Modifying
	@Query("    UPDATE Inp1001                          "
			+ " SET  updId        = :f_upd_id           "
			+ " 	,updDate      = SYSDATE()           "
			+ " 	,gwa          = :f_to_gwa           "
			+ " 	,doctor       = :f_to_doctor        "
			+ " 	,resident     = :f_to_resident      "
			+ " 	,hoCode1      = :f_to_ho_code1      "
			+ " 	,hoDong1      = :f_to_ho_dong1      "
			+ " 	,bedNo        = :f_to_bed_no        "
			+ " 	,bedNo2       = :f_to_bed_no2       "
			+ " 	,hoCode2      = :f_to_ho_code2      "
			+ " 	,hoDong2      = :f_to_ho_dong2      "
			+ " 	,hoGrade1     = :f_to_ho_grade1     "
			+ " 	,hoGrade2     = :f_to_ho_grade2     "
			+ " 	,kaikeiHodong = :f_to_kaikei_hodong "
			+ " 	,kaikeiHocode = :f_to_kaikei_hocode "
			+ " WHERE hospCode   = :f_hosp_code         "
			+ " AND pkinp1001    = :f_fkinp1001         ")
	public Integer updateInp1001InNUR2004U00(
			@Param("f_upd_id") String updId,
			@Param("f_to_gwa") String gwa,
			@Param("f_to_doctor") String doctor,
			@Param("f_to_resident") String resident,
			@Param("f_to_ho_code1") String hoCode1,
			@Param("f_to_ho_dong1") String hoDong1,
			@Param("f_to_bed_no") String bedNo,
			@Param("f_to_bed_no2") String bedNo2,
			@Param("f_to_ho_code2") String hoCode2,
			@Param("f_to_ho_dong2") String hoDong2,
			@Param("f_to_ho_grade1") String hoGrade1,
			@Param("f_to_ho_grade2") String hoGrade2,
			@Param("f_to_kaikei_hodong") String kaikeiHodong,
			@Param("f_to_kaikei_hocode") String kaikeiHocode,
			@Param("f_hosp_code") String hospCode,
			@Param("f_fkinp1001") Double pkinp1001);
	
	@Query("SELECT T FROM Inp1001 T WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND :f_date BETWEEN ipwonDate AND IFNULL(toiwonDate, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) ")
	public List<Inp1001> findByHospCodeBunhoFDate(@Param("f_hosp_code") String hospCode
													, @Param("f_bunho") String bunho
													, @Param("f_date") Date fdate);
	
	@Query("SELECT T FROM Inp1001 T WHERE hospCode = :f_hosp_code AND bunho = :f_bunho ")
	public List<Inp1001> findByHospCodeBunho(@Param("f_hosp_code") String hospCode, 
											 @Param("f_bunho") String bunho);
}

