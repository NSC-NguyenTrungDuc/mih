package nta.mss.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.mss.entity.MailList;

/**
 * The interface MailListRepository
 * 
 * @author linh.nguyen.trong
 * @since 07/08/2014
 */
@Repository
public interface MailListRepository extends JpaRepository<MailList, Integer> {
	
	/**
	 * Find MailList by active_flg
	 * 
	 * @return list 
	 */
	@Query("SELECT m FROM MailList m WHERE m.activeFlg = ?1")
	public List<MailList> findMailListByActiveFlg(Integer activeFlg);
	
	@Query("SELECT m FROM MailList m WHERE m.activeFlg = 1 and lower(m.mailListName) = ?1")
	public List<MailList> findMailListByName(String mailListName);
	
	@Query("SELECT m FROM MailList m WHERE m.activeFlg = :activeFlg AND m.hospitalId = :hospitalId")
	public List<MailList> findMailListActiveByHospitalId(@Param("activeFlg") Integer activeFlg, @Param("hospitalId") Integer hospitalId);
}
