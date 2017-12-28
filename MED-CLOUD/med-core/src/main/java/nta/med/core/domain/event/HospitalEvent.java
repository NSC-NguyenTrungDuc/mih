package nta.med.core.domain.event;

import nta.med.core.domain.event.vo.DepartmentVo;

import nta.med.core.domain.event.vo.DoctorScheduleVo;
import nta.med.core.domain.event.vo.DoctorVo;
import nta.med.core.domain.event.vo.MbsConfigVo;

import org.springframework.data.mongodb.core.mapping.Document;

import java.util.ArrayList;
import java.util.List;

/**
 * @author dainguyen.
 */
@Document(collection = "hospital_events")
public class HospitalEvent extends AbstractEvent {


    private String type;
    private Integer hospitalId ;
    private List<DepartmentVo> depts = new ArrayList<>();
    private DoctorVo doctor ;
    private DoctorScheduleVo schedules ;
    private String hospCode;
    private MbsConfigVo mbsConfig;
    
    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }


    public Integer getHospitalId() {
        return hospitalId;
    }

    public void setHospitalId(Integer hospital_id) {
        this.hospitalId = hospital_id;
    }

    public List<DepartmentVo> getDepts() {
        return depts;
    }

    public void setDepts(List<DepartmentVo> depts) {
        this.depts = depts;
    }

    public DoctorVo getDoctor() {
        return doctor;
    }

    public void setDoctor(DoctorVo doctor) {
        this.doctor = doctor;
    }

    public DoctorScheduleVo getSchedules() {
        return schedules;
    }

    public void setSchedules(DoctorScheduleVo schedules) {
        this.schedules = schedules;
    }

    public String getHospCode() {
        return hospCode;
    }

    public void setHospCode(String hospCode) {
        this.hospCode = hospCode;
    }

	public MbsConfigVo getMbsConfig() {
		return mbsConfig;
	}

	public void setMbsConfig(MbsConfigVo mbsConfig) {
		this.mbsConfig = mbsConfig;
	}

}
