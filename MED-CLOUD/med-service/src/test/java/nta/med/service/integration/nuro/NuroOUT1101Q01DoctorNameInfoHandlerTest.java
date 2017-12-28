package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NuroOUT1101Q01DoctorNameInfoHandlerTest extends MessageRequestTest {
    @Test
    public void testNuroOUT1101Q01DoctorNameInfoHandlerTest() throws InterruptedException {

    	NuroServiceProto.NuroOUT1101Q01DoctorNameInfoRequest request = NuroServiceProto.
    			NuroOUT1101Q01DoctorNameInfoRequest.newBuilder()
                .setGwa("%")
                .setDoctor("1111")
                .build();

        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
