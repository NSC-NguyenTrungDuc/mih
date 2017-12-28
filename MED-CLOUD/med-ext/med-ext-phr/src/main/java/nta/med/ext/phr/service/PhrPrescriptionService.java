package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.PrescriptionDetailModel;
import nta.med.ext.phr.model.PrescriptionModel;

public interface PhrPrescriptionService {
	public List<PrescriptionModel> getPrescription(Long profileId, PageRequest pageRequest);
	public PrescriptionDetailModel getPrescriptionDetail(Long prescriptionId, PageRequest pageRequest);
}
