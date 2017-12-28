package nta.mss.repository;

import java.util.List;

import nta.mss.entity.Department;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface DepartmentRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface DepartmentRepository extends JpaRepository<Department, Integer> {
	
	/**
	 * Find all active department.
	 *
	 * @return the list
	 */
	@Query("SELECT d FROM Department d WHERE d.activeFlg = 1 order by displayOrder asc, deptName asc")
	public List<Department> findAllActiveDepartment();
	
	/**
	 * Find all department in hospital.
	 *
	 * @param hospitalId the hospital id
	 * @return the list
	 */
	@Query("SELECT d FROM Department d WHERE d.hospital.hospitalId = ?1 and d.activeFlg = 1 order by displayOrder asc, deptName asc")
	public List<Department> findAllDepartmentInHospital(Integer hospitalId);
	
	/**
	 * Find by dept code.
	 *
	 * @param deptCode the dept code
	 * @return the list
	 */
	@Query("SELECT d FROM Department d WHERE d.hospital.hospitalCode = ?1 and d.deptCode = ?2 and d.activeFlg = 1 order by displayOrder asc, deptName asc")
	public List<Department> findByDeptCode(String hospitalCode, String deptCode);
	
	@Query("SELECT d FROM Department d WHERE d.displayOrder = ?1 and d.activeFlg = 1")
	public List<Department> findByDisplayOrder(Integer displayOrder);
	
	@Query("SELECT d FROM Department d WHERE d.hospital.hospitalId = :hospitalId and d.deptCode = :deptCode and d.activeFlg = 1 order by displayOrder asc, deptName asc")
	public List<Department> findDepartmentInHospital(@Param("hospitalId") Integer hospitalId, @Param("deptCode") String deptCode);
	
	@Query("SELECT d FROM Department d WHERE d.hospital.hospitalId = :hospitalId AND d.deptType = :deptType AND d.activeFlg = 1 ")
	public List<Department> findDepartmentByType(@Param("hospitalId") Integer hospitalId, @Param("deptType") Integer deptType);
}
