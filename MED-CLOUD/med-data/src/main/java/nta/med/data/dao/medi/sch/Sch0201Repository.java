package nta.med.data.dao.medi.sch;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.sch.Sch0201;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch0201Repository extends JpaRepository<Sch0201, Long>, Sch0201RepositoryCustom {
	
	@Modifying
	@Query(" 	DELETE FROM Sch0201				    "	
		  +"    WHERE hospCode = :hospCode           "
		  +"    AND pksch0201 = :pksch0201          	")
		public Integer deleteSch0201U99(@Param("hospCode") String hospCode,
				@Param("pksch0201") Double pksch0201);
	
	@Modifying
	@Query("UPDATE Sch0201 SET jundalTable = :f_jundal_table, jundalPart = :f_jundal_part "
			+ " WHERE hospCode = :f_hosp_code AND hangmogCode = :f_hangmog_code AND actingDate IS NULL "
			+ " AND IFNULL(cancelYn,'N') = 'N' AND IFNULL(:f_gumsaja,'%') = '%' ")
	public Integer updateXSavePerformerCase3(@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_hosp_code") String hospCode,
			@Param("f_hangmog_code") String hangmogCode,
			@Param("f_gumsaja") String gumsaja);
	
	@Query("SELECT a FROM Sch0201 a WHERE a.hospCode = :hospCode AND pksch0201 =:pksch0201 AND jundalTable =:jundalTable")
	public List<Sch0201> getByPkSch0201AndJundalTable(
			@Param("hospCode") String hospCode,
			@Param("pksch0201") String pksch0201,
			@Param("jundalTable") String jundalTable);
	
	@Modifying
	@Query("UPDATE Sch0201 SET updId = :userId, updDate = :updDate, seq = :seq WHERE"
			+ " hospCode = :hospCode AND pksch0201 =:pksch0201 AND :gubun = 'N' AND jundalTable <> 'CPL' ")
	public Integer updateSch0201U10(
			@Param("userId") String userId,
			@Param("updDate") Date updDate,
			@Param("seq") String seq,
			@Param("hospCode") String hospCode,
			@Param("pksch0201") String pksch0201,
			@Param("gubun") String gubun);
	
	@Modifying
	@Query("UPDATE Sch0201 SET updId = :userId, updDate = :updDate, seq = :seq WHERE"
			+ " hospCode = :hospCode AND bunho = :bunho AND reserDate = :reserDate "
			+ " AND jundalTable = 'CPL' AND jundalPart = :jundalPart AND :gubun = 'N'")
	public Integer updateSch0201U10ParentLayout(
			@Param("userId") String userId,
			@Param("updDate") Date updDate,
			@Param("seq") String seq,
			@Param("hospCode") String hospCode,
			@Param("bunho") String bunho,
			@Param("reserDate") String reserDate,
			@Param("jundalPart") String jundalPart,
			@Param("gubun") String gubun);

	public Sch0201 findByHospCodeAndPksch0201(String hospCode, Double pksch0201);
	public Sch0201 findByOutHospCodeAndPksch0201(String hospCode, Double pksch0201);
	public Sch0201 findByHospCodeAndPksch0201Out(String hospCode, Double pksch0201);


}

