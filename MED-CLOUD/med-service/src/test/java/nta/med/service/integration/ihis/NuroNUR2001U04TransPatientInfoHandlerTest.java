package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NuroNUR2001U04TransPatientInfoHandlerTest extends MessageRequestTest {
    @Test
    public void testCheckUserLogin() throws InterruptedException {

    	NuroServiceProto.NuroNUR2001U04TransPatientInfoRequest request = NuroServiceProto.
        		NuroNUR2001U04TransPatientInfoRequest.newBuilder()
        		.setPkout1001("1948")
        		.build();

        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}