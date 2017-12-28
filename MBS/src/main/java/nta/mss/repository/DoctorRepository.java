package nta.mss.repository;

import java.util.List;

import nta.mss.entity.Doctor;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

// TODO: Auto-generated Javadoc
/**
 * The Interface DoctorRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public interface DoctorRepository extends JpaRepository<Doctor, Integer>{
	
	/**
	 * Find by dept id.
	 * 
	 * @param deptId
	 *            the dept id
	 * @return the list
	 */
	@Query("SELECT d FROM Doctor d WHERE d.department.deptId = ?1 and activeFlg = 1 order by name asc, orderPriority asc")
	public List<Doctor> findByDeptId(Integer deptId);
	
	@Query("SELECT d FROM Doctor d WHERE d.department.deptId = ?1 and activeFlg = 1 order by orderPriority asc, name asc")
	public List<Doctor> findByDeptIdOrdered(Integer deptId);
	
	@Query("SELECT d FROM Doctor d WHERE d.department.deptId in ?1 order by orderPriority asc, name asc")
	public List<Doctor> findByLstDeptId(List<Integer> deptId);
	
	@Query("SELECT d FROM Doctor d WHERE d.orderPriority = ?1 and activeFlg = 1 order by orderPriority asc, name asc")
	public List<Doctor> findByOrderPriority(Integer orderPriority);
}
