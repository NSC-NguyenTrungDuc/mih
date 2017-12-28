package nta.med.data.dao.medi.res;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuro.NuroRES0102U00GetDoctorInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GridDoctorInfo;

/**
 * @author dainguyen.
 */
public interface Res0104RepositoryCustom {
	
	/**
	 * @param hospCode
	 * @param doctor
	 * @return
	 */
	public List<NuroRES0102U00GridDoctorInfo> getNuroRES0102U00GridDoctor(String hospCode, String doctor);
	
	/**
	 * @param hospCode
	 * @param doctor
	 * @param startDate
	 * @return
	 */
	public List<NuroRES0102U00GetDoctorInfo> getNuroRES0102U00GetDoctorByStarDate(String hospCode, String doctor, String startDate);
	
	/**
	 * @param hospCode
	 * @param doctor
	 * @param date
	 * @return
	 */
	public String getNuroRES0102U00CheckDoctor3(String hospCode, String doctor, String date);
	public String getRES1001U00CheckJinryoYn(String hospCode, String doctor, Date preDate, String preTime);
	
//	/**
//	 * @param hospCode
//	 * @param nuroRES0102U00UpdateRES0104Info
//	 * @return
//	 */
//	public boolean InsertNuroRES0102U00InsertRES0104(String hospCode, NuroRES0102U00UpdateRES0104Info nuroRES0102U00UpdateRES0104Info);
}

