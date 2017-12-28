package nta.med.data.dao.medi.out;

import java.util.List;

import nta.med.data.model.ihis.system.DetailPaInfoFormGridVisitListInfo;

/**
 * The Interface Out0103RepositoryCustom.
 *
 * @author dainguyen.
 */
public interface Out0103RepositoryCustom {
	
	/**
	 * Gets the detail pa info form grid visit list.
	 *
	 * @param language the language
	 * @param hospCode the hosp code
	 * @param patientCode the patient code
	 * @return the detail pa info form grid visit list
	 */
	public List<DetailPaInfoFormGridVisitListInfo> getDetailPaInfoFormGridVisitList(String language, String hospCode, String patientCode);
	
	/**
	 * Call pr out insert out0103.
	 *
	 * @param hospitalCode the hospital code
	 * @param iudGubun the iud gubun
	 * @param user the user
	 * @param naewonDate the naewon date
	 * @param bunho the bunho
	 * @param gwa the gwa
	 * @param gubun the gubun
	 * @param tuyakIlsu the tuyak ilsu
	 * @param doctor the doctor
	 * @param inOut the in out
	 * @param chartGwa the chart gwa
	 * @param specialYn the special yn
	 * @param toiwonDate the toiwon date
	 * @return the string
	 */
	public String callPrOutInsertOut0103(String hospitalCode, String iudGubun, String user, String naewonDate, String bunho, String gwa, String gubun, String tuyakIlsu, String doctor, 
			String inOut, String chartGwa, String specialYn, String toiwonDate);
	
	public List<String> callPrcLoadDoctorJinryoTime(String hospCode, String gwa, String doctor, String date, String time, String ioAmPm, 
			String ioFromTime, String ioToTime,String ioFlag);

}

