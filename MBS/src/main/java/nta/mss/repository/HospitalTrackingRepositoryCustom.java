package nta.mss.repository;

import java.util.List;

import nta.mss.model.HospitalTrackingModel;

public interface HospitalTrackingRepositoryCustom {
	public List<HospitalTrackingModel> getTrackingCodeByPageCode(Integer hospitalId);
}
