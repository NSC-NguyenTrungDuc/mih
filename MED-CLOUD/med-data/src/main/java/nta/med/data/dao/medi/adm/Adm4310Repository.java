package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm4310;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm4310Repository extends JpaRepository<Adm4310, Long>, Adm4310RepositoryCustom {
	// BA confirm menyGenYn case update = Y
	@Modifying
	@Query("Update Adm4310 SET menuGenYn = :menuGenYn WHERE hospCode = :hospCode AND userId = :userId AND sysId = :sysId")
	public Integer updateAdm4310(@Param("hospCode") String hospCode, @Param("userId") String userId, @Param("sysId")
	String sysId, @Param("menuGenYn")String menuGenYn);
	
	@Modifying
	@Query("	Update Adm4310                     "
		+ "      SET menuGenYn = :menuGenYn        "
		+ "      WHERE         "
		+ "       sysId = :sysId                ")
	public Integer updateAdm106UAdm4310(
			@Param("menuGenYn") String menuGenYn, 
			@Param("sysId") String sysId);


}

