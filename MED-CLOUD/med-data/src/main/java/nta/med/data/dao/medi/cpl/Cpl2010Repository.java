package nta.med.data.dao.medi.cpl;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.cpl.Cpl2010;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl2010Repository extends JpaRepository<Cpl2010, Long>, Cpl2010RepositoryCustom {
	@Modifying
	@Query(" UPDATE Cpl2010 SET updId = :q_user_id, updDate = :updDate, orderTime  = :f_order_time WHERE hospCode = :f_hosp_code AND pkcpl2010 = :f_pkcpl2010 ")
	public Integer updateCPL2010U00ChangeTimeUpdateCPL2010(@Param("q_user_id") String userId, @Param("updDate") Date updDate, 
			@Param("f_order_time") String oderTime,@Param("f_hosp_code") String hospCode,@Param("f_pkcpl2010") Double pkcpl2010);
	
	@Query("SELECT  A.suname FROM Cpl2010 A WHERE A.hospCode = :f_hosp_code AND A.bunho  = :f_bunho ORDER BY A.sysDate desc")
	public List<String> getSunameVsvPa(@Param("f_hosp_code") String hospCode,@Param("f_bunho") String bunho); 
	
	@Modifying
	@Query("UPDATE Cpl2010  SET dummy = NULL WHERE hospCode = :f_hosp_code AND jubsuDate = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d') AND bunho = :f_bunho AND dummy = 'Y' ")
	public Integer updateCpl2010LayBarcodeTempQueryEnd(@Param("f_hosp_code") String hospCode,@Param("f_jubsu_date") String jubsuDate,@Param("f_bunho") String bunho);
	
	@Modifying
	@Query("UPDATE Cpl2010 SET updId    = :q_user_id, updDate  = :updDate, dummy  = :f_dummy WHERE hospCode = :f_hosp_code AND pkcpl2010 = :f_pkcpl2010")
	public Integer updateCpl2010ExecuteUpdate(@Param("q_user_id") String userId, 
			@Param("f_dummy") String dummy,
			@Param("updDate") Date updDate,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkcpl2010") Double pkcpl2010);
	
	@Query("SELECT 'Y' FROM Cpl2010 WHERE hospCode = :f_hosp_code AND pkcpl2010 = :f_pkcpl2010 AND specimenSer IS NOT NULL")
	public String getCPL2010U00ExecuteGetYValue(@Param("f_hosp_code") String hospCode,@Param("f_pkcpl2010") Double pkcpl2010);
	
	@Modifying
	@Query("UPDATE Cpl2010 SET updDate = :updDate,dummy  = NULL,partJubsuDate = NULL,partJubsuTime = NULL, "
			+ "partJubsuja = NULL, jubsuDate = NULL,jubsuja = NULL,specimenSer = NULL WHERE fkocs1003 = :f_fkocs1003")
	public Integer getCPL2010U00OrderCancelUpdate(
			@Param("updDate") Date updDate,
			@Param("f_fkocs1003") Double fkocs1003);
	@Modifying
	@Query("UPDATE Cpl2010 SET gumJubsuDate = :f_gum_jubsu_date, gumJubsuTime = :f_gum_jubsu_time, gumJubsuja = :f_part_jubsuja "
			+ "WHERE hospCode = :f_hosp_code AND specimenSer = :f_specimen_ser AND gumJubsuDate IS NULL")
	public Integer updateCPL3010U00QueryLaySpecimenReadUpdate(@Param("f_gum_jubsu_date") Date gumJubsuDate,
			@Param("f_gum_jubsu_time") String gumJubsuTime,
			@Param("f_part_jubsuja") String gumJubsuja,
			@Param("f_hosp_code") String hospCode,
			@Param("f_specimen_ser") String specimenSer);
	
	@Modifying
	@Query("UPDATE Cpl2010 SET gumJubsuDate = :f_gum_jubsu_date, gumJubsuTime = :f_gum_jubsu_time, gumJubsuja = :f_part_jubsuja "
			+ "WHERE hospCode = :f_hosp_code AND specimenSer = :f_specimen_ser AND gumJubsuDate IS NOT NULL")
	public Integer updateCPL3010U00QueryLaySpecimenReadUpdateExt(@Param("f_gum_jubsu_date") Date gumJubsuDate,
			@Param("f_gum_jubsu_time") String gumJubsuTime,
			@Param("f_part_jubsuja") String gumJubsuja,
			@Param("f_hosp_code") String hospCode,
			@Param("f_specimen_ser") String specimenSer);
	
	@Query("SELECT jundalGubun FROM Cpl2010 WHERE hospCode = :f_hosp_code "
			+ "AND specimenSer = :f_specimen_ser AND partJubsuDate IS NULL GROUP BY jundalGubun")
	public List<String> getCPL3010U00QueryLaySpecimenReadSelectJundalGubun(@Param("f_hosp_code") String hospCode,
			@Param("f_specimen_ser") String specimenSer);
	
	@Query("SELECT DISTINCT 'Z' FROM Cpl2010 WHERE hospCode = :f_hosp_code AND specimenSer = :f_specimen_ser")
	public String getCPL3010U00GetZValue(@Param("f_hosp_code") String hospCode,
			@Param("f_specimen_ser") String specimenSer);
	
	@Query("SELECT CASE inOutGubun WHEN 'O' THEN fkocs1003 WHEN 'I' THEN fkocs2003 END "
			+ "FROM Cpl2010 WHERE hospCode = :f_hosp_code AND pkcpl2010 = :f_fkcpl2010")
	public Double getCPL3010U00GrdGumQueryEnd(@Param("f_hosp_code") String hospCode,
			@Param("f_fkcpl2010") Double pkcpl2010);
	
	
	@Modifying
	@Query("UPDATE Cpl2010 SET gumJubsuDate = NULL, gumJubsuTime = NULL, gumJubsuja = NULL "
			+ "WHERE hospCode = :f_hosp_code AND specimenSer = :f_specimen_ser AND gumJubsuDate IS NOT NULL")
	public Integer updateCPL3010U00Execute(@Param("f_hosp_code") String hospCode,
			@Param("f_specimen_ser") String specimenSer);
	
	@Query(" SELECT DISTINCT 'Y' FROM Cpl2010 WHERE hospCode = :f_hosp_code AND specimenSer  = :f_specimen_ser AND partJubsuDate IS NULL")
	public String getYValueBySpecimentSerAndJubsuDateNull(@Param("f_hosp_code") String hospCode,@Param("f_specimen_ser") String specimenSer);
	
	@Query(" SELECT DISTINCT 'Y' FROM Cpl2010 WHERE hospCode = :f_hosp_code AND specimenSer  = :f_specimen_ser AND partJubsuDate IS NOT NULL")
	public String getYValueBySpecimentSerAndJubsuDateNotNull(@Param("f_hosp_code") String hospCode,@Param("f_specimen_ser") String specimenSer);
	
	@Query(" SELECT DISTINCT 'N' FROM Cpl2010 WHERE hospCode = :f_hosp_code AND pkcpl2010  = :f_pkcpl2010 AND partJubsuDate IS NOT NULL")
	public String getNValueByPkcpl2010AndpartJubsuDateNotNull(@Param("f_hosp_code") String hospCode
			,@Param("f_pkcpl2010") double pkcpl2010);
}

