package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.out.Out0102;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0102Repository extends JpaRepository<Out0102, Long>, Out0102RepositoryCustom {
	@Modifying
	@Query("DELETE Out0102 WHERE hospCode = :hospitalCode AND bunho = :bunho "
			+ " AND gubun = :gubun AND startDate = :startDate ")
	public Integer deleteNuroOUT0101U02DeleteBoheom(@Param("hospitalCode") String hospitalCode,
			@Param("bunho") String bunho,
			@Param("gubun") String gubun,
			@Param("startDate") Date startDate);
	
	@Modifying
	@Query("UPDATE Out0102 SET updId = :updId , updDate = :updDate , startDate = :startDate, "
			+ " gubun = :gubun, johap = :johap, gaein = :gaein, piname = :piname, bonGaGubun = :bonGaGubun, "
			+ " endDate = IFNULL(:endDate, '9998/12/31'), gaeinNo = :gaeinNo, lastCheckDate = :lastCheckDate, "
			+ " chuidukDate = :chuidukDate WHERE hospCode = :hospCode AND bunho = :bunho AND gubun = :oldGubun AND startDate = :oldStartDate")
	public Integer updateNuroOUT0101U02UpdateBoheom(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("startDate") Date startDate,
			@Param("bunho") String bunho,
			@Param("gubun") String gubun,
			@Param("johap") String johap,
			@Param("gaein") String gaein,
			@Param("piname") String piname,
			@Param("bonGaGubun") String bonGaGubun,
			@Param("endDate") Date endDate,
			@Param("gaeinNo") String gaeinNo,
			@Param("lastCheckDate") Date lastCheckDate,
			@Param("chuidukDate") Date chuidukDate,
			@Param("hospCode") String hospCode,
			@Param("oldGubun") String oldGubun,
			@Param("oldStartDate") Date oldStartDate);
	
	@Query("SELECT T FROM Out0102 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho AND T.johap = :johap")
	public List<Out0102> findByHospCodeBunhoJohap(@Param("hospCode") String hospCode, @Param("bunho") String bunho, @Param("johap") String johap);
	
	@Query("SELECT T FROM Out0102 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho")
	public List<Out0102> findByHospCodeBunho(@Param("hospCode") String hospCode, @Param("bunho") String bunho);
	
	@Modifying
	@Query("DELETE Out0102 WHERE hospCode = :hospCode AND bunho IN :bunhoList")
	public Integer deleteOut0102ByBunhoAndHospCode(@Param("hospCode") String hospCode, @Param("bunhoList") List<String> bunhoList);
	
	@Query("SELECT T FROM Out0102 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho AND T.gubun = :gubun AND :fDate BETWEEN T.startDate AND T.endDate ")
	public List<Out0102> findByHospCodeBunhoGubunFDate(@Param("hospCode") String hospCode, 
													   @Param("bunho") String bunho, 
													   @Param("gubun") String gubun,
													   @Param("fDate") Date fDate);
}

