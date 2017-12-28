package nta.mss.repository.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.info.HospitalDto;
import nta.mss.jpa.mapper.JpaResultMapper;
import nta.mss.model.HospitalModel;
import nta.mss.repository.HospitalRepositoryCustom;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class HospitalRepositoryImpl implements HospitalRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Integer updateHospitalInfo(HospitalModel hospitalModel) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("    UPDATE hospital set hospital_name = :hospitalName,      ");
		sql.append("    		hospital_name_furigana = :furigana,             ");
		sql.append("    		address = :address,                              ");
		sql.append("    		email = :email,                                 ");
		sql.append("    		phone_number = :phone,                          ");
		sql.append("    		hospital_icon_path = :iconPath                  ");
		sql.append("    		WHERE hospital_id = :hospitalId                 ");

		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("hospitalName", hospitalModel.getHospitalName());
		query.setParameter("furigana", hospitalModel.getHospitalNameFurigana());
		query.setParameter("address", hospitalModel.getAddress());
		query.setParameter("email", hospitalModel.getEmail());
		query.setParameter("phone", hospitalModel.getPhoneNumber());
		query.setParameter("iconPath", hospitalModel.getHospitalIconPath());
		query.setParameter("hospitalId", hospitalModel.getHospitalId());

		return query.executeUpdate();
	}
	
	@Override
	public List<HospitalDto> getHospitalModelByHospitalCode(String hospitalCode){
		
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT                               ");
		sql.append("   A.hospital_id,                       ");
		sql.append("   A.hospital_code,                     ");
		sql.append("   A.hospital_name,                     ");
		sql.append("   A.hospital_parent_id,                ");
		sql.append("   A.hospital_icon_path,                ");
		sql.append("   A.locale,                            ");
		sql.append("   A.email,                             ");
		sql.append("   A.time_zone,                         ");
		sql.append("   A.is_use_vaccine,                    ");
		sql.append("   A.is_use_mt                     		");
		sql.append("   FROM hospital A                      ");
		sql.append("   WHERE A.active_flg = 1               ");
		sql.append("   AND A.hospital_code = :hospitalCode  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);

		List<HospitalDto> list = new JpaResultMapper().list(query, HospitalDto.class);
		return list;
	}
}
