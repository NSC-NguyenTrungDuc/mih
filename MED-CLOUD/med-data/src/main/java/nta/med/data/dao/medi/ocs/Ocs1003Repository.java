package nta.med.data.dao.medi.ocs;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.ocs.Ocs1003;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs1003Repository extends JpaRepository<Ocs1003, Long>, Ocs1003RepositoryCustom {
	@Query("SELECT CASE SIGN(COUNT(hangmogCode)) WHEN 1 THEN 'Y' ELSE 'N' END FROM Ocs1003 WHERE "
			+ "hospCode = :hospCode AND bunho = :patientCode AND orderDate  = :examPreDate AND gwa = :departmentCode AND doctor = :doctorCode AND naewonType = '0'")
	public List<String> getNuroRES1001U00CheckingHangmogCode(@Param("hospCode") String hospCode, 
			@Param("patientCode") String patientCode, 
			@Param("examPreDate") Date examPreDate, 
			@Param("departmentCode") String departmentCode, 
			@Param("doctorCode") String doctorCode);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET updDate = :updDate, updId = :updId, orderGubun = :orderGubun, suryang = :suryang, ordDanui = :ordDanui, dvTime = :dvTime, dv = :dv, nalsu = :nalsu, jusa = :jusa, bogyongCode = :bogyongCode, "
			+ " emergency = :emergency, jaeryoJundalYn = :jaeryoJundalYn, jundalTable = :jundalTable, jundalPart = :jundalPart, movePart = :movePart, muhyo = :muhyo, portableYn = :portableYn, antiCancerYn = :antiCancerYn, "
			+ " dcYn = :dcYn, dcGubun = :dcGubun, bannabYn = :bannabYn, bannabConfirm = :bannabConfirm, sutakYn = :sutakYn, powderYn = :powderYn, hopeDate = :hopeDate, hopeTime = :hopeTime, dv1 = :dv1, dv2 = :dv2, "
			+ " dv3 = :dv3, dv4 = :dv4, dv5 = :dv5, dv6 = :dv6, dv7 = :dv7, dv8 = :dv8, mixGroup = :mixGroup, orderRemark = :orderRemark, nurseRemark = :nurseRemark, bomOccurYn = :bomOccurYn, bomSourceKey = :bomSourceKey, "
			+ " nurseConfirmUser = :nurseConfirmUser, nurseConfirmDate = :nurseConfirmDate, nurseConfirmTime = :nurseConfirmTime, dangilGumsaOrderYn = :dangilGumsaOrderYn, dangilGumsaResultYn = :dangilGumsaResultYn, "
			+ " homeCareYn = :homeCareYn, regularYn = :regularYn, hubalChangeYn = :hubalChangeYn, pharmacy = :pharmacy, jusaSpdGubun = :jusaSpdGubun, drgPackYn = :drgPackYn, sortFkocskey = :sortFkocskey, "
			+ " wonyoiOrderYn = :wonyoiOrderYn, imsiDrugYn = :imsiDrugYn, specimenCode = :specimenCode, generalDispYn = :generalDispYn, bogyongCodeSub = :bogyongCodeSub, groupSer = :groupSer				"
			+ " WHERE pkocs1003 = :pkocs1003 AND hospCode = :hospCode ")
	public Integer updateOcsoOCS1003P01UpdateDataOCS1003(@Param("updDate") Date updDate,
			@Param("updId") String updId,
			@Param("orderGubun") String orderGubun,
			@Param("suryang") Double suryang,
			@Param("ordDanui") String ordDanui,
			@Param("dvTime") String dvTime,
			@Param("dv") Double dv,
			@Param("nalsu") Double nalsu,
			@Param("jusa") String jusa,
			@Param("bogyongCode") String bogyongCode,
			@Param("emergency") String emergency,
			@Param("jaeryoJundalYn") String jaeryoJundalYn,
			@Param("jundalTable") String jundalTable,
			@Param("jundalPart") String jundalPart,
			@Param("movePart") String movePart,
			@Param("muhyo") String muhyo,
			@Param("portableYn") String portableYn,
			@Param("antiCancerYn") String antiCancerYn,
			@Param("dcYn") String dcYn,
			@Param("dcGubun") String dcGubun,
			@Param("bannabYn") String bannabYn,
			@Param("bannabConfirm") String bannabConfirm,
			@Param("sutakYn") String sutakYn,
			@Param("powderYn") String powderYn,
			@Param("hopeDate") Date hopeDate,
			@Param("hopeTime") String hopeTime,
			@Param("dv1") Double dv1,
			@Param("dv2") Double dv2,
			@Param("dv3") Double dv3,
			@Param("dv4") Double dv4,
			@Param("dv5") Double dv5,
			@Param("dv6") Double dv6,
			@Param("dv7") Double dv7,
			@Param("dv8") Double dv8,
			@Param("mixGroup") String mixGroup,
			@Param("orderRemark") String orderRemark,
			@Param("nurseRemark") String nurseRemark,
			@Param("bomOccurYn") String bomOccurYn,
			@Param("bomSourceKey") Double bomSourceKey,
			@Param("nurseConfirmUser") String nurseConfirmUser,
			@Param("nurseConfirmDate") Date nurseConfirmDate,
			@Param("nurseConfirmTime") String nurseConfirmTime,
			@Param("dangilGumsaOrderYn") String dangilGumsaOrderYn,
			@Param("dangilGumsaResultYn") String dangilGumsaResultYn,
			@Param("homeCareYn") String homeCareYn,
			@Param("regularYn") String regularYn,
			@Param("hubalChangeYn") String hubalChangeYn,
			@Param("pharmacy") String pharmacy,
			@Param("jusaSpdGubun") String jusaSpdGubun,
			@Param("drgPackYn") String drgPackYn,
			@Param("sortFkocskey") Double sortFkocskey,
			@Param("wonyoiOrderYn") String wonyoiOrderYn,
			@Param("imsiDrugYn") String imsiDrugYn,
			@Param("specimenCode") String specimenCode,
			@Param("generalDispYn") String generalDispYn,
			@Param("bogyongCodeSub") String bogyongCodeSub,
			@Param("groupSer") Double groupSer,
			@Param("pkocs1003") Double pkocs1003,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET updDate = :updDate, updId = :updId, orderGubun = :orderGubun, suryang = :suryang, ordDanui = :ordDanui, dvTime = :dvTime, dv = :dv, nalsu = :nalsu, jusa = :jusa, bogyongCode = :bogyongCode, "
			+ " emergency = :emergency, jaeryoJundalYn = :jaeryoJundalYn, jundalTable = :jundalTable, jundalPart = :jundalPart, movePart = :movePart, muhyo = :muhyo, portableYn = :portableYn, antiCancerYn = :antiCancerYn, "
			+ " dcYn = :dcYn, dcGubun = :dcGubun, bannabYn = :bannabYn, bannabConfirm = :bannabConfirm, sutakYn = :sutakYn, powderYn = :powderYn, hopeDate = :hopeDate, hopeTime = :hopeTime, dv1 = :dv1, dv2 = :dv2, "
			+ " dv3 = :dv3, dv4 = :dv4, dv5 = :dv5, dv6 = :dv6, dv7 = :dv7, dv8 = :dv8, mixGroup = :mixGroup, orderRemark = :orderRemark, nurseRemark = :nurseRemark, bomOccurYn = :bomOccurYn, bomSourceKey = :bomSourceKey, "
			+ " nurseConfirmUser = :nurseConfirmUser, nurseConfirmDate = :nurseConfirmDate, nurseConfirmTime = :nurseConfirmTime, dangilGumsaOrderYn = :dangilGumsaOrderYn, dangilGumsaResultYn = :dangilGumsaResultYn, "
			+ " homeCareYn = :homeCareYn, regularYn = :regularYn, hubalChangeYn = :hubalChangeYn, pharmacy = :pharmacy, jusaSpdGubun = :jusaSpdGubun, drgPackYn = :drgPackYn, sortFkocskey = :sortFkocskey, "
			+ " wonyoiOrderYn = :wonyoiOrderYn, imsiDrugYn = :imsiDrugYn, specimenCode = :specimenCode, generalDispYn = :generalDispYn, bogyongCodeSub = :bogyongCodeSub, groupSer = :groupSer "
			+ " WHERE pkocs1003 = :pkocs1003 AND hospCode = :hospCode ")
	public Integer updateOcsoOCS1003P01UpdateDataOCS1003IgnoreActingDate(@Param("updDate") Date updDate,
			@Param("updId") String updId,
			@Param("orderGubun") String orderGubun,
			@Param("suryang") Double suryang,
			@Param("ordDanui") String ordDanui,
			@Param("dvTime") String dvTime,
			@Param("dv") Double dv,
			@Param("nalsu") Double nalsu,
			@Param("jusa") String jusa,
			@Param("bogyongCode") String bogyongCode,
			@Param("emergency") String emergency,
			@Param("jaeryoJundalYn") String jaeryoJundalYn,
			@Param("jundalTable") String jundalTable,
			@Param("jundalPart") String jundalPart,
			@Param("movePart") String movePart,
			@Param("muhyo") String muhyo,
			@Param("portableYn") String portableYn,
			@Param("antiCancerYn") String antiCancerYn,
			@Param("dcYn") String dcYn,
			@Param("dcGubun") String dcGubun,
			@Param("bannabYn") String bannabYn,
			@Param("bannabConfirm") String bannabConfirm,
			@Param("sutakYn") String sutakYn,
			@Param("powderYn") String powderYn,
			@Param("hopeDate") Date hopeDate,
			@Param("hopeTime") String hopeTime,
			@Param("dv1") Double dv1,
			@Param("dv2") Double dv2,
			@Param("dv3") Double dv3,
			@Param("dv4") Double dv4,
			@Param("dv5") Double dv5,
			@Param("dv6") Double dv6,
			@Param("dv7") Double dv7,
			@Param("dv8") Double dv8,
			@Param("mixGroup") String mixGroup,
			@Param("orderRemark") String orderRemark,
			@Param("nurseRemark") String nurseRemark,
			@Param("bomOccurYn") String bomOccurYn,
			@Param("bomSourceKey") Double bomSourceKey,
			@Param("nurseConfirmUser") String nurseConfirmUser,
			@Param("nurseConfirmDate") Date nurseConfirmDate,
			@Param("nurseConfirmTime") String nurseConfirmTime,
			@Param("dangilGumsaOrderYn") String dangilGumsaOrderYn,
			@Param("dangilGumsaResultYn") String dangilGumsaResultYn,
			@Param("homeCareYn") String homeCareYn,
			@Param("regularYn") String regularYn,
			@Param("hubalChangeYn") String hubalChangeYn,
			@Param("pharmacy") String pharmacy,
			@Param("jusaSpdGubun") String jusaSpdGubun,
			@Param("drgPackYn") String drgPackYn,
			@Param("sortFkocskey") Double sortFkocskey,
			@Param("wonyoiOrderYn") String wonyoiOrderYn,
			@Param("imsiDrugYn") String imsiDrugYn,
			@Param("specimenCode") String specimenCode,
			@Param("generalDispYn") String generalDispYn,
			@Param("bogyongCodeSub") String bogyongCodeSub,
			@Param("groupSer") Double groupSer,
			@Param("pkocs1003") Double pkocs1003,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("DELETE FROM Ocs1003 WHERE hospCode = :hospCode AND pkocs1003 = :pkocs1003 ")
	public Integer deleteOcsoOCS1003P01DeleteFromOCS1003(@Param("pkocs1003") Double pkocs1003,
			@Param("hospCode") String hospCode);
	
	@Query("SELECT MAX(seq) + 1 FROM Ocs1003 WHERE fkout1001 = :fkout1001 AND hospCode = :hospCode")
	public String getOcsoOCS1003P01GetMaxOcs1003Seq(@Param("fkout1001") BigDecimal fkout1001,
	@Param("hospCode") String hospCode);
	
	@Query("SELECT A.bunho FROM Ocs1003 A WHERE hospCode = :f_hosp_code AND A.bunho = :f_bunho "
			+ "AND A.hopeDate  != :f_naewon_date AND A.actingDate IS NULL AND A.ocsFlag != '3'")
	public String getKensaReser(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_naewon_date") Date hopeDate);
	
	@Query("SELECT A FROM Ocs1003 A WHERE hospCode = :f_hosp_code AND A.pkocs1003 = :f_pkocs1003")
	public List<Ocs1003> findByHospCodeAndPk(
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkocs1003") Double pkocs1003);
	
	@Modifying
	@Query("	UPDATE Ocs1003 A					              "
			+"	  SET A.updId        = :updId                     "
			+"	    , A.updDate      = SYSDATE()                  "
			+"	    , A.jundalPart  = :jundalPart                 "
			+"	    , A.jundalTable = :jundalTable                "
			+"	    , A.movePart    = :movePart                   "
			+"	    , A.inputGubun  = :inputGubun                 "
			+"	    , A.nalsu        = :nalsu                     "
			+"	    , A.suryang      = :suryang                   "
			+"	    , A.dv           = :dv                        "
			+"	    , A.approveYn   = 'Y'                         "
			+"	    , A.approveId   = :approveId                  "
			+"	    , A.approveDate = SYSDATE()                   "
			+"	    , A.approveTime = DATE_FORMAT(SYSDATE(), '%H%i')         "
			+"	    , A.inputId     = :inputId                    "
			+"	    , A.muhyo        = :muhyo                     "
			+"	WHERE A.hospCode    = :hospCode                   "
			+"	  AND A.pkocs1003    = :pkocs1003                 ")
	public Integer updateOCSAPPROVEOcs1003(
			@Param("updId") String updId,
			@Param("jundalPart") String jundalPart,
			@Param("jundalTable") String jundalTable,
			@Param("movePart") String movePart,
			@Param("inputGubun") String inputGubun,
			@Param("nalsu") Double nalsu,
			@Param("suryang") Double suryang,
			@Param("dv") Double dv,
			@Param("approveId") String approveId,
			@Param("inputId") String inputId,
			@Param("muhyo") String muhyo,
			@Param("hospCode") String hospCode,
			@Param("pkocs1003") Double pkocs1003);
	
	@Modifying
	@Query("	UPDATE Ocs1003 A					              		"
			+"	  SET A.updId        = :updId                     		"
			+"	    , A.updDate      = SYSDATE()                  		"
			+"	    , A.jundalPart  = :jundalPart                 		"
			+"	    , A.jundalTable = :jundalTable                		"
			+"	    , A.movePart    = :movePart                  	 	"
			+"	    , A.inputGubun  = :inputGubun                 		"
			+"	    , A.nalsu        = :nalsu                     		"
			+"	    , A.suryang      = :suryang                   		"
			+"	    , A.dv           = :dv                        		"
			+"	    , A.approveYn   = 'Y'                        	 	"
			+"	    , A.approveId   = :approveId                  		"
			+"	    , A.approveDate = SYSDATE()                   		"
			+"	    , A.actingDate = :actingDate                   		"
			+"	    , A.approveTime = DATE_FORMAT(SYSDATE(), '%H%i')    "
			+"	    , A.inputId     = :inputId                    		"
			+"	    , A.muhyo        = :muhyo                     		"
			+"	WHERE A.hospCode    = :hospCode                   		"
			+"	  AND A.pkocs1003    = :pkocs1003                 		")
	public Integer approveOrderOcs1003(
			@Param("updId") String updId,
			@Param("jundalPart") String jundalPart,
			@Param("jundalTable") String jundalTable,
			@Param("movePart") String movePart,
			@Param("inputGubun") String inputGubun,
			@Param("nalsu") Double nalsu,
			@Param("suryang") Double suryang,
			@Param("dv") Double dv,
			@Param("approveId") String approveId,
			@Param("actingDate") Date actingDate,
			@Param("inputId") String inputId,
			@Param("muhyo") String muhyo,
			@Param("hospCode") String hospCode,
			@Param("pkocs1003") Double pkocs1003);
	
	@Query("select ifDataSendYn  from Ocs1003 where hospCode  = :hospCode AND pkocs1003 = :f_pkocs")
	public List<String> getIfDataSendYnOCS1003(@Param("hospCode") String hospCode, 
			@Param("f_pkocs") Double pkocs1003);

	@Modifying
	@Query("UPDATE Ocs1003 SET nurseRemark = :f_remark,updId = 'UPD_REC_'  WHERE hospCode = :f_hosp_code AND pkocs1003 = :f_pkocs")
	public Integer updateOCSACTOcs1003ChangeNurSeRemarkAndUpdId(@Param("f_hosp_code") String hospCode, 
			@Param("f_remark") String reMark,
			@Param("f_pkocs") Double pkocs1003);
	
	@Modifying
	@Query("UPDATE Ocs1003 A SET A.suryang = :f_suryang, A.nalsu   = :f_nalsu WHERE A.hospCode = :f_hosp_code AND A.pkocs1003 = :f_pkocskey")
	public Integer updateOCSATOcs1003ChangeSuRyangNalsu(@Param("f_hosp_code") String hospCode, 
			@Param("f_suryang") Double suryang,
			@Param("f_nalsu") Double nalsu, 
			@Param("f_pkocskey") Double pkocs1003);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET jubsuDate = null , actingDate = null WHERE hospCode  = :f_hosp_code  AND pkocs1003  = :f_pkocs")
	public Integer updateOCSACTOcs1003ChangeJubsuDateAndActingDate(@Param("f_hosp_code") String hospCode, 
			@Param("f_pkocs") Double pkocs1003);
	
	@Modifying
	@Query(  "	UPDATE Ocs1003 A										 "
			+"	  SET A.sunabYn        	= 'Y'                     		 "
			+"	    , A.sunabDate  		= :sunabDate                 	 "
			+"	    , A.sunabTime 		= DATE_FORMAT(SYSDATE(), '%H%i') "
			+"	    , A.ifDataSendYn    = 'Y'                   		 "
			+"	    , A.ifDataSendDate  = SYSDATE()                 	 "
			+"	    , A.fkout1003       = :fkout1003               		 "
			+"	WHERE A.hospCode	= :hospCode                   		 "
			+"	  AND A.pkocs1003   = :pkocs1003                 	 	 ")
	public Integer updateORDERTRANOcs1003Update(@Param("sunabDate") Date sunabDate, 
			@Param("fkout1003") Double fkout1003, 
			@Param("pkocs1003") Double pkocs1003, 
			@Param("hospCode") String hospCode);
		
	@Query("select a  from Ocs1003 a where a.hospCode  = :hospCode AND a.hangmogCode = :f_hangmog_Code")
	public List<String> getFkocs1003ByHangmogCode(@Param("hospCode") String hospCode, 
			@Param("f_hangmog_Code") String hangmogCode);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET paidYn = :f_paid_yn WHERE hospCode  = :f_hosp_code AND pkocs1003 = :f_fkocs1003")
	public Integer modifyPaidYn(@Param("f_paid_yn") String paidYn, @Param("f_hosp_code") String hospCode, @Param("f_fkocs1003") Double fkocs1003);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET paidYn = :f_paid_yn, updId = :f_updId, updDate = :f_updDate WHERE hospCode  = :f_hosp_code AND pkocs1003 = :f_fkocs1003")
	public Integer updatePaidYn(@Param("f_paid_yn") String paidYn, @Param("f_updId") String updId, @Param("f_updDate") Date updDate, @Param("f_hosp_code") String hospCode, @Param("f_fkocs1003") Double fkocs1003);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET paidYn = :f_paid_yn, updId = :f_updId, updDate = :f_updDate, ifDataSendYn = :ifDataSendYn, ifDataSendDate = :ifDataSendDate WHERE hospCode  = :f_hosp_code AND pkocs1003 = :f_fkocs1003")
	public Integer updatePaidYnAndIfDataSendYn(@Param("f_paid_yn") String paidYn, 
			@Param("f_updId") String updId, 
			@Param("f_updDate") Date updDate,
			@Param("ifDataSendYn") String ifDataSendYn,
			@Param("ifDataSendDate") Date ifDataSendDate,
			@Param("f_hosp_code") String hospCode, 
			@Param("f_fkocs1003") Double fkocs1003);
	
	@Query("SELECT T FROM Ocs1003 T WHERE hospCode = :hospCode AND fkout1001 = :fkout1001")
	public List<Ocs1003> findByHospCodeFkout1001(@Param("hospCode") String hospCode, @Param("fkout1001") BigDecimal fkout1001);


	@Modifying
	@Query("UPDATE Ocs1003 SET actingDate = :f_acting_date WHERE hospCode  = :f_hosp_code AND pkocs1003 IN :f_pkocs1003_list")
	public Integer updateActingDate(@Param("f_acting_date") Date actingDate, @Param("f_hosp_code") String hospCode, @Param("f_pkocs1003_list") List<Double> pkocs1003List);
	
	@Modifying
	@Query(  "	UPDATE Ocs1003 A										 "
			+"	  SET A.sunabYn        	= 'Y'                     		 "
			+"	    , A.sunabDate  		= :sunabDate                 	 "
			+"	    , A.sunabTime 		= DATE_FORMAT(SYSDATE(), '%H%i') "
			+"	    , A.ifDataSendYn    = 'Y'                   		 "
			+"	    , A.ifDataSendDate  = SYSDATE()                 	 "
			+"	    , A.fkout1003       = :fkout1003               		 "
			+"	    , A.orderStatus     = :orderStatus				 	 "
			+"	WHERE A.hospCode	= :hospCode                   		 "
			+"	  AND A.pkocs1003   = :pkocs1003                 	 	 ")
	public Integer updateOrderTransfer(@Param("sunabDate") Date sunabDate, 
			@Param("fkout1003") Double fkout1003, 
			@Param("pkocs1003") Double pkocs1003, 
			@Param("hospCode") String hospCode,
			@Param("orderStatus") String orderStatus);

	@Modifying
	@Query("UPDATE Ocs1003 SET orderStatus = :newOrderStatus WHERE hospCode = :hospCode AND fkout1001 IN :fkout1001List AND orderStatus = :oldOrderStatus ")
	public Integer updateOrderStatus(@Param("hospCode") String hospCode,
									 @Param("fkout1001List") List<BigDecimal> fkout1001List,
									 @Param("oldOrderStatus") String oldOrderStatus,
									 @Param("newOrderStatus") String newOrderStatus);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET orderStatus = :orderStatus, ifDataSendYn = 'Y' WHERE hospCode = :hospCode AND pkocs1003 IN :pkocs1003List ")
	public Integer updateOrderStatusByPkOcs1003(@Param("hospCode") String hospCode,
									 @Param("pkocs1003List") List<Double> pkocs1003List,
									 @Param("orderStatus") String orderStatus);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET orderStatus = :orderStatus, sunabYn = :sunabYn, sunabDate = :sunabDate, sunabTime = :sunabTime, "
			+ "ifDataSendYn = :ifDataSendYn, ifDataSendDate = :ifDataSendDate, fkout1003 = :fkout1003 WHERE hospCode = :hospCode AND pkocs1003 IN :pkocs1003List ")
	public Integer updateOrderCanceled(@Param("hospCode") String hospCode,
									 @Param("pkocs1003List") List<Double> pkocs1003List,
									 @Param("orderStatus") String orderStatus,
									 @Param("sunabYn") String sunabYn,
									 @Param("sunabDate") Date sunabDate,
									 @Param("sunabTime") String sunabTime,
									 @Param("ifDataSendYn") String ifDataSendYn,
									 @Param("ifDataSendDate") Date ifDataSendDate,
									 @Param("fkout1003") Double fkout1003);
	
	@Query(" SELECT T FROM Ocs1003 T WHERE hospCode = :hospCode AND fkout1001 = :pkout1001 AND ifDataSendYn = 'Y' AND orderStatus = :orderStatus ")
	public List<Ocs1003> findByHospCodePkout1001OrderStatus(@Param("hospCode") String hospCode, @Param("pkout1001") BigDecimal pkout1001, @Param("orderStatus") String orderStatus);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET orderStatus = :orderStatus, ifDataSendYn = 'Y', fkout1003 = :fkout1003 WHERE hospCode = :hospCode AND pkocs1003 IN :pkocs1003List ")
	public Integer updateFailTransferOrder(@Param("hospCode") String hospCode,
									 @Param("pkocs1003List") List<Double> pkocs1003List,
									 @Param("orderStatus") String orderStatus,
									 @Param("fkout1003") Double fkout1003);
	
	@Modifying
	@Query("UPDATE Ocs1003 SET actDoctor = :actDoctor WHERE hospCode = :hospCode AND pkocs1003 = :pkocs1003 ")
	public Integer updateActDoctor(@Param("hospCode") String hospCode,
									 @Param("pkocs1003") Double pkocs1003,
									 @Param("actDoctor") String actDoctor);
}


