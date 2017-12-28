package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.out.Out0105;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0105Repository extends JpaRepository<Out0105, Long>, Out0105RepositoryCustom {
	@Modifying
	@Query("UPDATE Out0105 SET updId = :userId, updDate = :updDate, startDate = :startDate, bunho = :bunho, budamjaBunho = :budamjaPatient,"
			+ " gongbiCode = :gongbiCode, sugubjaBunho = :sugubjaCode, endDate = :endDate, remark = :remark"
			+ ", lastCheckDate = :lastCheckDate WHERE hospCode = :hospitalCode AND startDate = STR_TO_DATE(:oldStartDate, '%Y/%m/%d')"
			+ "  AND bunho = :bunho AND gongbiCode = :gongbiCode ")
	public Integer updateNuroOUT0101U02Gongbi(@Param("userId") String userId, @Param("updDate") Date updDate,
			@Param("startDate") Date startDate, @Param("bunho") String patientCode, @Param("budamjaPatient") String budamjaPatient ,
			@Param("gongbiCode") String gongbiCode, @Param("sugubjaCode") String sugubjaCode,
			@Param("endDate") Date endDate, @Param("remark") String remark, @Param("lastCheckDate") Date lastCheckDate, 
		
			@Param("hospitalCode") String hospitalCode, @Param("oldStartDate") String oldStartDate);
	
	@Modifying
	@Query("DELETE Out0105 WHERE hospCode = :hospCode AND startDate = STR_TO_DATE(:startDate, '%Y/%m/%d') "
			+ "AND bunho = :patientCode AND gongbiCode = :gongbiCode")
	public Integer deleteOut0105ByPatientCodeAndGongbiCode(@Param("hospCode") String hospCode, @Param("startDate") String startDate,
			@Param("patientCode") String patientCode, @Param("gongbiCode") String gongbiCode);
	
	
	@Query("SELECT DISTINCT 'Y' FROM Out0105 WHERE hospCode = :hospitalCode "
			+ "AND gongbiCode = :gongbiCode AND bunho = :bunho AND startDate = :startDate")
	public String getNuroOUT0101U02GongbiListGetY(@Param("hospitalCode") String hospitalCode,
			@Param("gongbiCode") String gongbiCode,
			@Param("bunho") String patientCode,
			@Param("startDate") Date startDate);
	
	@Query("SELECT 'Y' FROM Out0105 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho AND T.budamjaBunho = :budamjaBunho")
	public List<String> existByHospCodeBunhoBudamjaBunho(@Param("hospCode") String hospCode, @Param("bunho") String bunho, @Param("budamjaBunho") String budamjaBunho);

	@Modifying
	@Query("DELETE Out0105 WHERE hospCode = :hospCode AND bunho IN :bunhoList")
	public Integer deleteOut0105ByHospCodeAndBunho(@Param("hospCode") String hospCode, @Param("bunhoList") List<String> bunhoList);
	
	@Query("SELECT T FROM Out0105 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho AND T.gongbiCode = :gongbiCode")
	public List<Out0105> findByHospCodeBunhoGongbiCode(@Param("hospCode") String hospCode, 
																@Param("bunho") String bunho, 
																@Param("gongbiCode") String gongbiCode);
	
	@Query("SELECT T FROM Out0105 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho")
	public List<Out0105> findByHospCodeBunho(@Param("hospCode") String hospCode, @Param("bunho") String bunho);
}

