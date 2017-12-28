package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NuroNUR2001U04ComingStatusTest extends MessageRequestTest{

	@Test
	public void nuroNUR2001U04ComingStatusTest() throws InterruptedException {
		NuroServiceProto.NuroNUR2001U04ComingStatusRequest request = NuroServiceProto.NuroNUR2001U04ComingStatusRequest
				.newBuilder()  
				.setPatientCode("000001734")
				.setComingDate("2016/01/12")
				.setDepartmentCode("01")
				.setDoctorCode("0111111")
				.setComingType("0")
//				.setOldReceptionNo("1")
				.setExamStatus("1")
				.build();    
		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
