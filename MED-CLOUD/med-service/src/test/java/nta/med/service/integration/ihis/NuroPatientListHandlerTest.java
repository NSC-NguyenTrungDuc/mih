package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;


public class NuroPatientListHandlerTest extends MessageRequestTest{

    @Test
    public void testNuroPatientListRequest() throws Exception {
        NuroServiceProto.NuroPatientListRequest request = NuroServiceProto.NuroPatientListRequest.newBuilder()
        	    .setHospitalCode("K01")
        		.setComingDate("2016/01/12")
                .setDepartmentCode("01")
                .setDoctorCode("")
                .setPatientCode("")
                .setReceptionType("")
                .setExamStatus("N")
                .setComingStatus("Y")
                .setCurrentSystemId("OUTS")
                .build();
        


        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
