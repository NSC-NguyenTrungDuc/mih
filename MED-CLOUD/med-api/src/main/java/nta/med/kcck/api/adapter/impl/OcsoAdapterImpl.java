package nta.med.kcck.api.adapter.impl;

import java.util.List;

import org.springframework.stereotype.Component;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.adapter.AbstractAdapter;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.adapter.OcsoAdapter;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.OrderServiceProto;
import nta.med.kcck.api.rpc.proto.OrderServiceProto.UpdatePaidOrderRequest;
import nta.med.kcck.api.rpc.proto.OrderServiceProto.UpdatePaidOrderResponse;
import nta.med.kcck.api.rpc.proto.PatientModelProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

/**
 * @author dainguyen.
 */
@Component("ocsoAdapter")
public class OcsoAdapterImpl extends AbstractAdapter implements OcsoAdapter {

    public OcsoAdapterImpl() {
        super(OcsoServiceProto.class, OcsoServiceProto.getDescriptor());
    }

	@Override
	public PatientServiceProto.GetPatientDiseaseResponse getPatientDisease(RpcApiSession session, PatientServiceProto.GetPatientDiseaseRequest request) {
		OcsoServiceProto.OUTSANGPatientDiseaseRequest req = OcsoServiceProto.OUTSANGPatientDiseaseRequest.newBuilder()
				.setPatientCode(request.getPatientCode())
				.setHospCode(request.getHospCode())
				.build(); 
		
		OcsoServiceProto.OUTSANGPatientDiseaseResponse response = submit(session, req, 0L);
		PatientServiceProto.GetPatientDiseaseResponse.Builder rp = PatientServiceProto.GetPatientDiseaseResponse.newBuilder();
		if(response != null){
			rp.setHospName(response.getHospName());
			List<OcsoModelProto.PatientDiseaseInfo> diseaseList = response.getPatientDiseaseList();
			for (OcsoModelProto.PatientDiseaseInfo info : diseaseList) {
				PatientModelProto.PatientDiseaseInfo.Builder disease = PatientModelProto.PatientDiseaseInfo.newBuilder();
				BeanUtils.copyProperties(info, disease, Language.JAPANESE.toString());
				rp.addPatientDisease(disease);
			}
		}
		
		return rp.build();
	}

	@Override
	public PatientServiceProto.GetPatientMedicineResponse getPatientMedicine(RpcApiSession session, PatientServiceProto.GetPatientMedicineRequest request) {
		OcsoServiceProto.OcsoPatientMedicineRequest req = OcsoServiceProto.OcsoPatientMedicineRequest.newBuilder()
				.setPatientCode(request.getPatientCode())
				.setHospCode(request.getHospCode())
				.build();
		
		OcsoServiceProto.OcsoPatientMedicineResponse response = submit(session, req, 10000L);
		PatientServiceProto.GetPatientMedicineResponse.Builder rp = PatientServiceProto.GetPatientMedicineResponse.newBuilder(); 
		if(response != null){
			rp.setHospName(response.getHospName());
			List<OcsoModelProto.OcsoPatientMedicineInfo> medicineList = response.getPatientMedicineList();
			for (OcsoModelProto.OcsoPatientMedicineInfo info : medicineList) {
				PatientModelProto.PatientMedicineInfo.Builder medicine = PatientModelProto.PatientMedicineInfo.newBuilder();
				BeanUtils.copyProperties(info, medicine, Language.JAPANESE.toString());
				rp.addPatientMedicine(medicine);
			}
		}
		
		return rp.build();
	}

	@Override
	public OrderServiceProto.UpdatePaidOrderResponse updatePaidOrder(RpcApiSession session, UpdatePaidOrderRequest request) {
		OcsoServiceProto.OcsoUpdatePaidOrderRequest req = OcsoServiceProto.OcsoUpdatePaidOrderRequest.newBuilder()
				.setHospCode(request.getHospCode())
				.setReceptionDate(request.getReceptionDate())
				.addAllReceptRefId(request.getReceptRefIdList())
				.build(); 
		
		OcsoServiceProto.OcsoUpdatePaidOrderResponse response = submit(session, req, 10000L);
		OrderServiceProto.UpdatePaidOrderResponse.Builder rp = OrderServiceProto.UpdatePaidOrderResponse.newBuilder();
		if(response == null){
			rp.setResult(false);
			return rp.build();
		}
		
		rp.setResult(response.getResult());
		rp.setMessage(response.getMessage() == null ? "" : response.getMessage());
		return rp.build();
	}

}






























