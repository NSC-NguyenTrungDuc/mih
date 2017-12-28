package nta.med.kcck.api.adapter;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.OrderServiceProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;

/**
 * @author dainguyen.
 */
public interface OcsoAdapter {

	PatientServiceProto.GetPatientDiseaseResponse getPatientDisease(RpcApiSession session, PatientServiceProto.GetPatientDiseaseRequest request);
	
	PatientServiceProto.GetPatientMedicineResponse getPatientMedicine(RpcApiSession session, PatientServiceProto.GetPatientMedicineRequest request);
	
	OrderServiceProto.UpdatePaidOrderResponse updatePaidOrder(RpcApiSession session, OrderServiceProto.UpdatePaidOrderRequest request);
}
