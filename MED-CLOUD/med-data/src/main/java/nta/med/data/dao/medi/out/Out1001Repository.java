package nta.med.data.dao.medi.out;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.out.Out1001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out1001Repository extends JpaRepository<Out1001, Long>, Out1001RepositoryCustom {

	@Query("SELECT 'Y' FROM Out1001 WHERE hospCode   = :f_hosp_code AND bunho       = :f_bunho AND naewonDate = STR_TO_DATE(:f_naewon_date,'%Y/%m/%d') "
		+ "  AND gwa         = :f_gwa AND doctor      = :f_doctor AND naewonType = :f_naewon_type AND jubsuNo    = :f_jubsu_no   ")
	public String getNuroOUT1001U01CheckY2(@Param("f_hosp_code") String f_hosp_code,
			@Param("f_bunho") String f_bunho,
			@Param("f_naewon_date") Date f_naewon_date,
			@Param("f_gwa") String f_gwa,
			@Param("f_doctor") String f_doctor,
			@Param("f_naewon_type") String f_naewon_type,
			@Param("f_jubsu_no") BigDecimal f_jubsu_no);
	
	@Query("SELECT 'Y' FROM Out1001 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho  "
			+ " AND naewonDate = STR_TO_DATE(:f_naewon_date,'%Y/%m/%d') AND jubsuNo = :f_jubsu_no")
	public String getNuroOUT1001U01CheckY3(@Param("f_hosp_code") String f_hosp_code,
			@Param("f_bunho") String f_bunho,
			@Param("f_naewon_date") Date f_naewon_date,
			@Param("f_jubsu_no") BigDecimal f_jubsu_no);
	
	@Modifying
	@Query(" UPDATE Out1001  SET updId = :f_user_id, updDate = :f_upd_date, doctor = :f_doctor, chojae = :f_chojae, jubsuNo = :f_jubsu_no, "
			+ " gubun = :f_gubun, jubsuTime = :f_jubsu_time, arriveTime = :f_arrive_time, jubsuGubun = :f_jubsu_gubun, "
			+ "naewonYn = :f_check_naewon, receptRefId = :f_receptRefId WHERE hospCode = :f_hosp_code AND pkout1001 = :f_pkout1001 ")
	public Integer updateTableOUT1001(@Param("f_user_id") String updId,
			@Param("f_upd_date") Date updDate,
			@Param("f_doctor") String doctor,
			@Param("f_chojae") String chojae,
			@Param("f_jubsu_no") BigDecimal jubsuNo,
			@Param("f_gubun") String gubun,
			@Param("f_jubsu_time") String jubsuTime,
			@Param("f_arrive_time") String arriveTime,
			@Param("f_jubsu_gubun") String jubsuGubun,
			@Param("f_check_naewon") String naewonYn,
			@Param("f_receptRefId") String receptRefId,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkout1001") Double pkout1001);
	
	@Modifying
	@Query(" UPDATE Out1001  SET updId = :f_user_id, updDate = :f_upd_date, doctor = :f_doctor, chojae = :f_chojae, jubsuNo = :f_jubsu_no, "
			+ " gubun = :f_gubun, jubsuTime = :f_jubsu_time, arriveTime = :f_arrive_time, jubsuGubun = :f_jubsu_gubun, "
			+ "naewonYn = :f_check_naewon, gwa = :f_gwa, receptRefId = :f_receptRefId WHERE hospCode = :f_hosp_code AND pkout1001 = :f_pkout1001 ")
	public Integer updateOUT1001(@Param("f_user_id") String updId,
			@Param("f_upd_date") Date updDate,
			@Param("f_doctor") String doctor,
			@Param("f_chojae") String chojae,
			@Param("f_jubsu_no") BigDecimal jubsuNo,
			@Param("f_gubun") String gubun,
			@Param("f_jubsu_time") String jubsuTime,
			@Param("f_arrive_time") String arriveTime,
			@Param("f_jubsu_gubun") String jubsuGubun,
			@Param("f_check_naewon") String naewonYn,
			@Param("f_gwa") String gwa,
			@Param("f_receptRefId") String receptRefId,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkout1001") Double pkout1001);
	
//	@Modifying
//	@Query(" UPDATE Out1001  SET updId = :f_user_id, updDate = :f_upd_date, doctor = :f_doctor, chojae = :f_chojae, jubsuNo = :f_jubsu_no, "
//			+ " gubun = :f_gubun, jubsuTime = :f_jubsu_time, arriveTime = :f_arrive_time, jubsuGubun = :f_jubsu_gubun, "
//			+ " gwa = :f_gwa, receptRefId = :f_receptRefId WHERE hospCode = :f_hosp_code AND pkout1001 = :f_pkout1001 ")
//	public Integer updateOUT1001(@Param("f_user_id") String updId,
//			@Param("f_upd_date") Date updDate,
//			@Param("f_doctor") String doctor,
//			@Param("f_chojae") String chojae,
//			@Param("f_jubsu_no") BigDecimal jubsuNo,
//			@Param("f_gubun") String gubun,
//			@Param("f_jubsu_time") String jubsuTime,
//			@Param("f_arrive_time") String arriveTime,
//			@Param("f_jubsu_gubun") String jubsuGubun,
//			@Param("f_gwa") String gwa,
//			@Param("f_receptRefId") String receptRefId,
//			@Param("f_hosp_code") String hospCode,
//			@Param("f_pkout1001") Double pkout1001);
	
	@Modifying
	@Query("DELETE FROM Out1001 WHERE hospCode = :hospitalCode AND pkout1001 = :f_pkout1001 ")
	public Integer deleteOut1001ById(@Param("hospitalCode") String hospitalCode, @Param("f_pkout1001") Double pkout1001);
	
	@Modifying
	@Query("DELETE FROM Out1001 WHERE hospCode = :hospCode AND outHospCode = :sessionHospCode AND pkout1001 = :f_pkout1001 ")
	public Integer deleteOut1001ByIdIsOtherClinic(@Param("hospCode") String hospCode, @Param("sessionHospCode") String sessionHospCode, @Param("f_pkout1001") Double pkout1001);

	@Modifying
	@Query("UPDATE Out1001 SET updId = :userId, updDate = :updDate, naewonDate = :examPreDate, jubsuTime   = :examPreTime, "
			+ "jubsuNo     = :receptionNo WHERE hospCode    = :hospitalCode AND pkout1001    = :pkout1001")
	public Integer updateNuroRES1001U00ReservationOut1001(@Param("userId") String userId, @Param("updDate") Date updDate,
			@Param("examPreDate") Date examPreDate, @Param("examPreTime") String examPreTime, @Param("receptionNo") String receptionNo,
			@Param("hospitalCode") String hospitalCode, @Param("pkout1001") String pkout1001);
	
	@Modifying
	@Query("UPDATE Out1001 SET updId = :userId, updDate = :updDate, naewonDate = :examPreDate, jubsuTime   = :examPreTime, "
			+ "jubsuNo     = :receptionNo WHERE hospCode    = :hospitalCode AND pkout1001    = :pkout1001 ")
	public Integer updateRES1001U00FrmModifyReserGrdRES1001SavePerformer(@Param("userId") String userId, @Param("updDate") Date updDate,
			@Param("examPreDate") Date examPreDate, @Param("examPreTime") String examPreTime, @Param("receptionNo") BigDecimal receptionNo,
			@Param("hospitalCode") String hospitalCode, @Param("pkout1001") Double pkout1001);
	
	@Modifying
	@Query("UPDATE Out1001 SET updId = :userId, updDate = :updDate, naewonDate = :examPreDate, jubsuTime   = :examPreTime, "
			+ "jubsuNo     = :receptionNo WHERE  hospCode = :hospCode AND outHospCode    = :sessionHospCode AND pkout1001    = :pkout1001 ")
	public Integer updateRES1001U00FrmModifyReserGrdRES1001SavePerformerIsOtherClinic(@Param("userId") String userId, @Param("updDate") Date updDate,
			@Param("examPreDate") Date examPreDate, @Param("examPreTime") String examPreTime, @Param("receptionNo") BigDecimal receptionNo,
			@Param("hospCode") String hospCode, @Param("sessionHospCode") String sessionHospCode, @Param("pkout1001") Double pkout1001);
	
	@Modifying
	@Query(   " UPDATE Out1001 SET naewonYn = :naewonYn "
			+ " WHERE hospCode = :hospCode              "
			+ "   AND pkout1001 = :pkout1001            ")
	public Integer updateOcsoOCS1003P01JubsuInfo(@Param("hospCode") String hospCode,
			@Param("naewonYn") String naewonYn,
			@Param("pkout1001") Double pkout1001);
	
	@Query("SELECT 'X' FROM Out1001 A where A.hospCode = :hospCode AND A.doctor = :doctor "
			+ "AND A.bunho = :bunho AND A.pkout1001 = :pkout1001")
	public String getOcsoOCS1003P01CheckX(@Param("hospCode") String hospCode,
			@Param("doctor") String doctor,
			@Param("bunho") String bunho,
			@Param("pkout1001") Double pkout1001);
	
	@Modifying
	@Query("UPDATE Out1001 SET doctor = :doctor, gwa = :gwa WHERE hospCode = :hospCode AND pkout1001 = :pkout1001 ")
	public Integer updateOcsoOCS1003P01UpdateDoctor(@Param("doctor") String doctor,
			@Param("gwa") String gwa,
			@Param("hospCode") String hospCode,
			@Param("pkout1001") Double pkout1001);
	
	
	@Modifying
	@Query("	UPDATE Out1001					 "
		  + "	  SET kensaYn  = 'N'              "
		  + "	WHERE hospCode = :hospCode        "
		  + "	  AND pkout1001 = :pkout1001       ")
		public Integer updateSchsSCH0201Q12UpdateKensaYn(
				@Param("hospCode") String hospCode,
				@Param("pkout1001") Double pkout1001);
	
	@Query("select naewonYn from Out1001  where hospCode = :hospCode   and pkout1001= :pkout1001 ")
	public List<String> OcsaOCS0503U00GetNaewonYn(@Param("hospCode") String hospCode,@Param("pkout1001") Double pkout1001 );
	
	@Query("select naewonYn from Out1001 where hospCode = :hospCode AND bunho = :f_bunho AND naewonDate = :f_naewon_date and pkout1001= :pkout1001 ")
	public String getOcsoGetNaewonYn(@Param("hospCode") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_naewon_date") Date naewonDate,
			@Param("pkout1001") Double pkout1001 );
	
	@Modifying
	@Query("UPDATE Out1001 SET updId = :userId, updDate = :updDate, jubsuNo = :seq "
			+ " WHERE hospCode = :hospCode AND reserYn = 'Y' AND pkout1001= :pkout1001"
			+ " AND :gubun = 'Y' ")
		public Integer updateSCH0201U00(
				@Param("userId") String userId,
				@Param("updDate") Date updDate,
				@Param("seq") String seq,
				@Param("hospCode") String hospCode,
				@Param("pkout1001") Double pkout1001);
	
	@Query("SELECT DATE_FORMAT(naewonDate,'%Y/%m/%d') FROM Out1001 WHERE hospCode = :f_hosp_code AND pkout1001 =  :naewonKey")
	public List<String> getnaewonDateByPkout1001(@Param("f_hosp_code") String hospCode,@Param("naewonKey") Double pkout1001);
	
	@Modifying
	@Query("UPDATE Out1001 A SET A.updId = :f_user_id, A.updDate = SYSDATE() , "
			+ "  A.naewonYn   = :f_naewon_yn, A.arriveTime = :f_arrive_time, A.jubsuGubun = :f_jubsu_gubun "
			+ " WHERE A.hospCode   = :f_hosp_code AND A.pkout1001   = :f_pkout1001")
	public Integer updatePhyWherePkout1001(@Param("f_hosp_code") String hospCode,@Param("f_user_id") String userId,
			@Param("f_naewon_yn") String naewonYn, @Param("f_arrive_time") String arriveTime,
			 @Param("f_jubsu_gubun") String jubsuGubun, @Param("f_pkout1001") Double pkout1001 );
	
	@Query(" SELECT 'Y' FROM Out1001  WHERE hospCode = :f_hosp_code AND pkout1001 = :f_pkout1001")
	public String getCheckY(@Param("f_hosp_code") String hospCode,@Param("f_pkout1001") Double pkout1001);
	
	@Query(" SELECT 'Y' FROM Out1001  WHERE hospCode = :f_hosp_code AND bunho = :bunho AND naewonDate = :naewonDate AND  arriveTime = :arriveTime")
	public List<String> checkIfBunhoExist(@Param("f_hosp_code") String hospCode,
			@Param("bunho") String bunho,
			@Param("naewonDate") Date naewonDate,
			@Param("arriveTime") String arriveTime);
	
	@Query(" SELECT 'Y' FROM Out1001  WHERE hospCode = :f_hosp_code AND bunho = :bunho ")
	public List<String> checkIfBunhoExistByBunhoAndHospCode(@Param("f_hosp_code") String hospCode, @Param("bunho") String bunho);
	
	@Modifying
	@Query(" UPDATE Out1001 set gubun = :f_gubun, chojae = :f_chojae, sangjungGubun = :f_sanjung_gubun "
			+ "WHERE hospCode = :f_hosp_code AND  pkout1001 = :f_pk1001 ")
	public Integer oRDERTRANProcessRequiUpdateOut1001(@Param("f_hosp_code") String hospCode,
			@Param("f_gubun") String gubun,
			@Param("f_chojae") String chojae,
			@Param("f_sanjung_gubun") String sangjungGubun,
			@Param("f_pk1001") Double pk1001);
	
	@Query(" SELECT pkout1001 FROM Out1001  WHERE hospCode = :f_hosp_code AND bunho = :bunho AND naewonDate = :naewonDate AND jubsuTime = :jubsuTime")
	public List<Double> findPK(@Param("f_hosp_code") String hospCode,
			@Param("bunho") String bunho,
			@Param("naewonDate") Date naewonDate,
			@Param("jubsuTime") String jubsuTime);
	
	@Query(" SELECT pkout1001 FROM Out1001  WHERE hospCode = :f_hosp_code AND bunho = :bunho AND naewonDate = :naewonDate AND jubsuTime = :jubsuTime AND (gubun = :gubun OR gubun=:defaultGubun)")
	public List<Double> findByHospCodeBunhoExamTimeGubun(@Param("f_hosp_code") String hospCode,
			@Param("bunho") String bunho,
			@Param("naewonDate") Date naewonDate,
			@Param("jubsuTime") String jubsuTime,
			@Param("gubun") String gubun, @Param("defaultGubun") String defaultGubun);
	
	@Query(" SELECT out FROM Out1001 out WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND pkout1001 = :f_pkout1001")
	public List<Out1001> findPkOut1001Ext(@Param("f_hosp_code") String hospCode, 
										 @Param("f_bunho") String bunho, 
										 @Param("f_pkout1001") Double pkout1001);
	
	@Query(" SELECT pkout1001 FROM Out1001  WHERE hospCode = :f_hosp_code AND bunho = :bunho AND naewonDate = :naewonDate AND doctor = :doctor AND gwa = :gwa AND reserYn = 'Y' ")
	public List<Double> getSchs0201U99CheckInsert(@Param("f_hosp_code") String hospCode, 
										 @Param("bunho") String bunho, 
										 @Param("naewonDate") Date naewonDate,
										 @Param("doctor") String doctor,
										 @Param("gwa") String gwa);

	@Query(" SELECT out FROM Out1001 out WHERE out.hospCode = :f_hosp_code AND out.bunho = :bunho order by pkout1001 desc")
	public List<Out1001> findByHospCodeAndBunho(@Param("f_hosp_code") String hospCode, @Param("bunho") String bunho);


	@Query(" SELECT out FROM Out1001 out WHERE out.hospCode = :f_hosp_code AND out.pkout1001 = :pkout1001 ")
	public Out1001 findByHospCodeAndPkOut1001(@Param("f_hosp_code") String hospCode, @Param("pkout1001") Double pkout1001);
	
	@Modifying
	@Query(" UPDATE Out1001 set paidYn = :paidYn, updId = :updId, updDate = :updDate "
			+ "WHERE hospCode = :f_hosp_code AND  pkout1001 = :pkout1001 ")
	public Integer updateOut1001PaidYn(@Param("f_hosp_code") String hospCode,
			@Param("pkout1001") Double pkout1001,
			@Param("paidYn") String paidYn,
			@Param("updId") String updId,
			@Param("updDate") Date updDate);
	
	@Query(" SELECT out FROM Out1001 out WHERE out.hospCode = :f_hosp_code AND out.naewonDate = :naewonDate AND out.bunho = :bunho AND receptRefId = :receptRefId ")
	public List<Out1001> findByHospCodeNaewonDateBunhoRefReceptId(@Param("f_hosp_code") String hospCode, 
															@Param("naewonDate") Date naewonDate,
															@Param("bunho") String bunho,
															@Param("receptRefId") String receptRefId);
	
	@Query(" SELECT out FROM Out1001 out WHERE out.hospCode = :f_hosp_code AND out.naewonDate = :naewonDate AND out.bunho = :bunho AND out.jubsuTime = :jubsuTime AND out.doctor = :doctor AND out.gwa = :gwa AND out.reserYn = :reserYn ")
	public List<Out1001> findReservation(@Param("f_hosp_code") String hospCode, 
									@Param("naewonDate") Date naewonDate,
									@Param("bunho") String bunho,
									@Param("jubsuTime") String jubsuTime,
									@Param("doctor") String doctor,
									@Param("gwa") String gwa,
									@Param("reserYn") String reserYn);
	

	@Query(" SELECT out FROM Out1001 out WHERE out.hospCode = :f_hosp_code AND out.naewonDate = :naewonDate AND out.receptRefId IN :refIdList")
	public List<Out1001> findByNaewonDateReceptRefId(@Param("f_hosp_code") String hospCode, 
													 @Param("naewonDate") Date naewonDate,
													 @Param("refIdList") List<String> refIdList);
}

