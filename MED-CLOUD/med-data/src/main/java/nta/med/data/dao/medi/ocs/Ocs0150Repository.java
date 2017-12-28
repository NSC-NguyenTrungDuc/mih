package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0150;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0150Repository extends JpaRepository<Ocs0150, Long>, Ocs0150RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Ocs0150 SET allergyPopYn = IFNULL(:f_allergy_pop_yn, 'N'), doOrderPopYn = IFNULL(:f_do_order_pop_yn, 'N'), "
			+ "drgPrtYn = IFNULL(:f_drg_prt_yn, 'N'), emrPopYn = IFNULL(:f_emr_pop_yn, 'N'), reserPrtYn = IFNULL(:f_reser_prt_yn, 'N'), "
			+ "specialwritePopYn = IFNULL(:f_specialwrite_pop_yn, 'N'), vitalsignsPopYn   = IFNULL(:f_vitalsigns_pop_yn  , 'N'), "
			+ "xrtPrtYn = IFNULL(:f_xrt_prt_yn, 'N'), sentouSearchYn = IFNULL(:f_sentou_search_yn, 'N'), "
			+ "orderLabelPrtYn = IFNULL(:f_order_label_prt_yn, 'N'), generalDispYn = IFNULL(:f_general_disp_yn, 'N'), "
			+ "sameNameCheckYn = IFNULL(:f_same_name_check_yn, 'N') , checkingDrgYn = IFNULL(:f_checking_drg_yn, 'N') , potionDrugYn = :f_potion_drug_yn , diseaseUnregisteredYn = :f_disease_unregistered_yn , infectionPopYn = :f_infection_pop_yn    WHERE doctor = :f_doctor "
			+ "AND gwa = :f_gwa AND ioGubun = :f_io_gubun AND hospCode = :f_hosp_code")
	public Integer updateOcsaOCS0150U00UpdateOCS0150New(@Param("f_allergy_pop_yn") String allergyPopYn,
			@Param("f_do_order_pop_yn") String doOrderPopYn,
			@Param("f_drg_prt_yn") String drgPrtYn,
			@Param("f_emr_pop_yn") String emrPopYn,
			@Param("f_reser_prt_yn") String reserPrtYn,
			@Param("f_specialwrite_pop_yn") String specialwritePopYn,
			@Param("f_vitalsigns_pop_yn") String vitalsignsPopYn,
			@Param("f_xrt_prt_yn") String xrtPrtYn,
			@Param("f_sentou_search_yn") String sentouSearchYn,
			@Param("f_order_label_prt_yn") String orderLabelPrtYn,
			@Param("f_general_disp_yn") String generalDispYn,
			@Param("f_same_name_check_yn") String sameNameCheckYn,
			@Param("f_doctor") String doctor,
			@Param("f_gwa") String gwa,
			@Param("f_io_gubun") String ioGubun,
			@Param("f_hosp_code") String hospCode,
			@Param("f_checking_drg_yn") String checkingDrgYn,
			@Param("f_potion_drug_yn") String potionDrugYn,
			@Param("f_disease_unregistered_yn") String diseaseUnregisteredYn,
			@Param("f_infection_pop_yn") String infectionPopYn);
	
	@Modifying
	@Query("UPDATE Ocs0150 SET allergyPopYn = IFNULL(:f_allergy_pop_yn, 'N'), doOrderPopYn = IFNULL(:f_do_order_pop_yn, 'N'), "
			+ "drgPrtYn = IFNULL(:f_drg_prt_yn, 'N'), emrPopYn = IFNULL(:f_emr_pop_yn, 'N'), reserPrtYn = IFNULL(:f_reser_prt_yn, 'N'), "
			+ "specialwritePopYn = IFNULL(:f_specialwrite_pop_yn, 'N'), vitalsignsPopYn   = IFNULL(:f_vitalsigns_pop_yn  , 'N'), "
			+ "xrtPrtYn = IFNULL(:f_xrt_prt_yn, 'N'), sentouSearchYn = IFNULL(:f_sentou_search_yn, 'N'), "
			+ "orderLabelPrtYn = IFNULL(:f_order_label_prt_yn, 'N'), generalDispYn = IFNULL(:f_general_disp_yn, 'N'), "
			+ "sameNameCheckYn = IFNULL(:f_same_name_check_yn, 'N') , checkingDrgYn = IFNULL(:f_checking_drg_yn, 'N')  WHERE doctor = :f_doctor "
			+ "AND gwa = :f_gwa AND ioGubun = :f_io_gubun AND hospCode = :f_hosp_code")
	public Integer updateOcsaOCS0150U00UpdateOCS0150(@Param("f_allergy_pop_yn") String allergyPopYn,
			@Param("f_do_order_pop_yn") String doOrderPopYn,
			@Param("f_drg_prt_yn") String drgPrtYn,
			@Param("f_emr_pop_yn") String emrPopYn,
			@Param("f_reser_prt_yn") String reserPrtYn,
			@Param("f_specialwrite_pop_yn") String specialwritePopYn,
			@Param("f_vitalsigns_pop_yn") String vitalsignsPopYn,
			@Param("f_xrt_prt_yn") String xrtPrtYn,
			@Param("f_sentou_search_yn") String sentouSearchYn,
			@Param("f_order_label_prt_yn") String orderLabelPrtYn,
			@Param("f_general_disp_yn") String generalDispYn,
			@Param("f_same_name_check_yn") String sameNameCheckYn,
			@Param("f_doctor") String doctor,
			@Param("f_gwa") String gwa,
			@Param("f_io_gubun") String ioGubun,
			@Param("f_hosp_code") String hospCode,
			@Param("f_checking_drg_yn") String checkingDrgYn);
	
	@Modifying
	@Query("DELETE FROM Ocs0150 WHERE doctor = :f_doctor AND gwa = :f_gwa AND ioGubun = :f_io_gubun AND hospCode = :f_hosp_code")
	public Integer deleteOcsaOCS0150U00DeleteOCS0150(
			@Param("f_doctor") String doctor,
			@Param("f_gwa") String gwa,
			@Param("f_io_gubun") String ioGubun,
			@Param("f_hosp_code") String hospCode);

	@Query
	public List<Ocs0150> findByHospCodeAndDoctorAndGwa(String hospCode, String doctor, String gwa);
}

