package nta.med.data.dao.medi.drg;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.drg.Drg2010;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg2010Repository extends JpaRepository<Drg2010, Long>, Drg2010RepositoryCustom {
	@Modifying
	@Query("UPDATE Drg2010 A SET A.fkdrg4010 = :fkdrg4010 WHERE A.hospCode = :hospCode AND A.jubsuDate = :jubsuDate "
			+ " AND A.drgBunho = :drgBunho AND A.bunho = :bunho")
	public Integer updateDrgsDRG5100P01UpdateFkdrg4010InDRG2010(@Param("fkdrg4010") Double fkdrg4010,
			@Param("hospCode") String hospCode,
			@Param("jubsuDate") Date jubsuDate,
			@Param("drgBunho") Double drgBunho,
			@Param("bunho") String bunho);
	
	@Modifying
	@Query("UPDATE Drg2010 SET boryuYn = :boryuYn WHERE hospCode = :hospCode AND drgBunho = :drgBunho"
			+ " AND gwa = :gwa AND doctor = :doctor AND  bunho = :bunho"
			+ " AND DATE_FORMAT(naewonDate, '%Y/%m/%d') = :naewonDate ")
	public Integer updateBoryuYn(@Param("boryuYn") String boryuYn, @Param("hospCode") String hospCode, @Param("drgBunho") Double drgBunho, 
			@Param("gwa") String gwa, @Param("doctor") String doctor, @Param("bunho") String bunho, @Param("naewonDate") String naewonDate);
	
	@Modifying
	@Query("UPDATE Drg2010 A SET A.powderYn = :powderYn WHERE A.hospCode = :hospCode AND A.fkocs1003 = :fkocs1003")
	public Integer updateDrgsDRG5100P01UpdatePowderYN(@Param("powderYn") String powderYn,
			@Param("hospCode") String hospCode,
			@Param("fkocs1003") Double fkocs1003);
	
	@Modifying
	@Query("UPDATE Drg2010 A SET A.drgPackYn = :drgPackYn WHERE A.hospCode = :hospCode AND A.fkocs1003 = :fkocs1003")
	public Integer updateDrgsDRG5100P01UpdateDrgPackYNInDRG2010(@Param("drgPackYn") String drgPackYn,
			@Param("hospCode") String hospCode,
			@Param("fkocs1003") Double fkocs1003);
	
	@Query("SELECT DISTINCT 'Y' FROM Drg2010 A WHERE A.hospCode = :hospCode AND A.orderDate = DATE_FORMAT(:orderDate,'%Y/%m/%d') "
			+ "AND A.drgBunho = :drgBunho AND IFNULL(A.dcYn,'N') = 'N' AND A.sourceFkocs1003 IS NULL "
			+ "AND IFNULL(A.wonyoiOrderYn,'N') = 'N' AND A.jubsuIlsi IS NULL ")
	public String checkDrgsDRG5100P01CheckJubsu(@Param("hospCode") String hospCode,
			@Param("orderDate") String orderDate,
			@Param("drgBunho") Double drgBunho);
	
	@Query("SELECT MIN(fkocs1003) FROM Drg2010 A WHERE A.hospCode = :hospCode AND A.orderDate = DATE_FORMAT(:orderDate,'%Y/%m/%d') "
			+ "AND A.drgBunho = :drgBunho AND A.sourceFkocs1003 IS NULL AND IFNULL(A.dcYn,'N') = 'N' AND IFNULL(A.bannabYn,'N') = 'N' AND A.jundalPart = 'PA'")
	public String getDrgsDRG5100P01MinFKOCS1003(@Param("hospCode") String hospCode,
			@Param("orderDate") String orderDate,
			@Param("drgBunho") Double drgBunho);
	
	@Query("SELECT DISTINCT 'X' FROM Drg2010 a  WHERE a.hospCode = :hospCode AND DATE_FORMAT(a.orderDate,'%Y%m%d') = :orderDate "
			+ "AND a.drgBunho = :drgBunho AND a.actDate IS NULL AND IFNULL(a.dcYn,'N') = 'N' AND a.sourceFkocs1003 IS NULL")
	public String checkActing(@Param("hospCode") String hospCode,
			@Param("orderDate") String orderDate,
			@Param("drgBunho") Double drgBunho);
	
	@Query("SELECT DISTINCT 'X' FROM Drg2010 a  WHERE a.hospCode = :hospCode AND DATE_FORMAT(a.orderDate,'%Y%m%d') = :orderDate "
			+ "AND a.drgBunho = :drgBunho AND a.jubsuIlsi IS NULL AND IFNULL(a.dcYn,'N') = 'N' AND a.sourceFkocs1003 IS NULL")
	public String checkJubsuIlsi (@Param("hospCode") String hospCode,
			@Param("orderDate") String orderDate,
			@Param("drgBunho") Double drgBunho);
	
	@Modifying
	@Query("UPDATE Drg2010  SET fkjihkey = :pkdrg5010 WHERE hospCode = :hospCode AND jubsuDate = :jubsuDate AND drgBunho = :drgBunho "
			+ "AND bunho = :bunho AND bunryu1 IN (:bunryu)")
	public Integer updateDRG0201U00ProcAtcInterface(@Param("pkdrg5010") Double pkdrg5010,
			@Param("hospCode") String hospCode,
			@Param("jubsuDate") Date jubsuDate,
			@Param("drgBunho") Double drgBunho,
			@Param("bunho") String bunho, 
			@Param("bunryu") List<String> bunryu);
	
	@Query("select distinct bunho from Drg2010 WHERE drgBunho = :drgBunho AND DATE_FORMAT(jubsuDate,'%Y/%m/%d') = :jubsuDate AND hospCode = :hospCode")
	public List<String> getDRG0201U00GetPatientId(@Param("drgBunho") Double drgBunho,
			@Param("jubsuDate") String jubsuDate,
			@Param("hospCode") String hospCode);
	
}

