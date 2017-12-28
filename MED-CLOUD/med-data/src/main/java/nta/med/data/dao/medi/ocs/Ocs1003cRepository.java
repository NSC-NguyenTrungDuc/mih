package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs1003C;

@Repository
public interface Ocs1003cRepository extends JpaRepository<Ocs1003C, Long>, Ocs1003cRepositoryCustom{

	@Modifying
	@Query("UPDATE Ocs1003C SET updDate = :updDate, updId = :updId, orderGubun = :orderGubun, suryang = :suryang, ordDanui = :ordDanui, dvTime = :dvTime, dv = :dv, nalsu = :nalsu, jusa = :jusa, bogyongCode = :bogyongCode, "
			+ " emergency = :emergency, jaeryoJundalYn = :jaeryoJundalYn, jundalTable = :jundalTable, jundalPart = :jundalPart, movePart = :movePart, muhyo = :muhyo, portableYn = :portableYn, antiCancerYn = :antiCancerYn, "
			+ " dcYn = :dcYn, dcGubun = :dcGubun, bannabYn = :bannabYn, bannabConfirm = :bannabConfirm, sutakYn = :sutakYn, powderYn = :powderYn, hopeDate = :hopeDate, hopeTime = :hopeTime, dv1 = :dv1, dv2 = :dv2, "
			+ " dv3 = :dv3, dv4 = :dv4, dv5 = :dv5, dv6 = :dv6, dv7 = :dv7, dv8 = :dv8, mixGroup = :mixGroup, orderRemark = :orderRemark, nurseRemark = :nurseRemark, bomOccurYn = :bomOccurYn, bomSourceKey = :bomSourceKey, "
			+ " nurseConfirmUser = :nurseConfirmUser, nurseConfirmDate = :nurseConfirmDate, nurseConfirmTime = :nurseConfirmTime, dangilGumsaOrderYn = :dangilGumsaOrderYn, dangilGumsaResultYn = :dangilGumsaResultYn, "
			+ " homeCareYn = :homeCareYn, regularYn = :regularYn, hubalChangeYn = :hubalChangeYn, pharmacy = :pharmacy, jusaSpdGubun = :jusaSpdGubun, drgPackYn = :drgPackYn, sortFkocskey = :sortFkocskey, "
			+ " wonyoiOrderYn = :wonyoiOrderYn, imsiDrugYn = :imsiDrugYn, specimenCode = :specimenCode, generalDispYn = :generalDispYn, bogyongCodeSub = :bogyongCodeSub, groupSer = :groupSer				"
			+ " WHERE pkocs1003c = :pkocs1003c AND hospCode = :hospCode ")
	public Integer updateOcsoOCS1003P01UpdateDataOCS1003C(@Param("updDate") Date updDate,
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
			@Param("pkocs1003c") Double pkocs1003c,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("DELETE FROM Ocs1003C WHERE hospCode = :hospCode AND pkocs1003c = :pkocs1003c ")
	public Integer deleteOcsoOCS1003P01DeleteFromOCS1003C(@Param("pkocs1003c") Double pkocs1003c, @Param("hospCode") String hospCode);
	
	@Query("SELECT A FROM Ocs1003C A WHERE hospCode = :f_hosp_code AND A.pkocs1003c = :f_pkocs1003c")
	public List<Ocs1003C> findByHospCodeAndPk(
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkocs1003c") Double pkocs1003);
}
