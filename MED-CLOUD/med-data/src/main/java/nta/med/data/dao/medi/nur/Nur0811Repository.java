package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0811;

@Repository
public interface Nur0811Repository extends JpaRepository<Nur0811, Long>, Nur0811RepositoryCustom {

	@Query("SELECT T FROM Nur0811 T WHERE T.hospCode = :hospCode AND T.needHType = :needHType")
	public List<Nur0811> findByHospCodeNeedHType(@Param("hospCode") String hospCode,
												 @Param("needHType") String needHType);
	
	@Query("SELECT T FROM Nur0811 T WHERE T.hospCode = :hospCode AND T.needHType = :needHType AND T.needType = :needType")
	public List<Nur0811> findByHospCodeNeedHTypeNeedType(@Param("hospCode") String hospCode,
												 		 @Param("needHType") String needHType,
												 		 @Param("needType") String needType);
	
	@Modifying
	@Query("DELETE FROM Nur0811 WHERE hospCode = :hospCode AND needHType = :needHType AND needType = :needType")
	public List<Nur0811> deleteByHospCodeNeedHTypeNeedType(@Param("hospCode") String hospCode,
												 		   @Param("needHType") String needHType,
												 		   @Param("needType") String needType);

}
