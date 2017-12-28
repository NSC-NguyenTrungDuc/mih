package nta.med.data.dao.medi.kinki;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.kinki.Revision;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author DEV-TiepNM
 */
@Repository
public interface RevisionRepository extends JpaRepository<Revision, Long> ,RevisionRepositoryCustom {
	
	@Modifying
	@Query("UPDATE Revision  SET revision   = revision + 1, updated = :timeStamp, fileName = :fileName WHERE tableName in :tableName " )
	public Integer updateRevisionByTableName(@Param("tableName") List<String> tableNames, @Param("timeStamp")
	Date timeStamp, @Param("fileName") String fileName);

	@Query
	public Revision findByTableNameAndActiveFlg(String tableName, BigDecimal activeFlg);

}
