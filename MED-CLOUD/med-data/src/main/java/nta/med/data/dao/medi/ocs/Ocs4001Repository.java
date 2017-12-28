package nta.med.data.dao.medi.ocs;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs4001;

@Repository
public interface Ocs4001Repository extends JpaRepository<Ocs4001, Long>, Ocs4001RepositoryCustom {	
	@Modifying
	@Query("UPDATE Ocs4001 SET updDate = SYSDATE(), updId = :f_user_id, activeFlg = 0 WHERE id  = :f_id")
	public Integer deleteOcs4001(@Param("f_id") Long id, 
							     @Param("f_user_id") String userId);
	
	@Modifying
	@Query("UPDATE Ocs4001 SET updDate = SYSDATE(), updId = :f_user_id, " 	
							+ "inputContent = :f_input_content, "
							+ "inputValue = :f_input_value, "
							+ "printContent = :f_print_content " 
							+ "WHERE id  = :f_id ")
	public Integer updateOcs4001Save(@Param("f_id") Long id, 
							     @Param("f_user_id") String userId,
							     @Param("f_input_content") String inputContent,
							     @Param("f_input_value") String inputValue,
							     @Param("f_print_content") String printContent);
	
	@Modifying
	@Query("UPDATE Ocs4001 SET updDate = SYSDATE(), updId = :f_user_id, " 	
							+ "inputContent = :f_input_content, "
							+ "inputValue = :f_input_value, "
							+ "printContent = :f_print_content, " 
							+ "printDate = :f_print_date " 
							+ "WHERE id  = :f_id ")
	public Integer updateOcs4001Print(@Param("f_id") Long id, 
							     @Param("f_user_id") String userId,
							     @Param("f_input_content") String inputContent,
							     @Param("f_input_value") String inputValue,
							     @Param("f_print_content") String printContent,
							     @Param("f_print_date") Date printDate);

}
